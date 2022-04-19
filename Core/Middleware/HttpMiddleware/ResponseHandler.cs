using Core.Attributes;
using Core.Extension;
using Core.IoC;
using Entities.Concrete;
using Infrastructure.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace Core.Middleware.HttpMiddleware
{
    public class ResponseHandler
    {
        private readonly RequestDelegate next;

        public ResponseHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            var token = context.Request.Headers["Authorization"].FirstOrDefault();

            if (token != null)
            {
                token = token.Split(" ").Last();
                context.Request.Headers.Authorization = string.Format("Bearer {0}", token);
            }

            context.Response.ContentType = "application/json";
            Stream responseBody = context.Response.Body;
            //request
            var request = context.Request;
            //request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var requestData = Encoding.UTF8.GetString(buffer);
            if (string.IsNullOrEmpty(requestData) && (context.Request.Method == "GET" || context.Request.Method == "DELETE"))
            {
                if (context.Request.QueryString.HasValue)
                    requestData = context.Request.QueryString.Value;
                else
                    requestData = context.Request.Path.Value.Split('/').Last();
            }

            request.Body.Position = 0;

            using var newResponseBody = new MemoryStream();
            context.Response.Body = newResponseBody;

            //go to Controllers
            await next(context);

            //response
            context.Response.Body = new MemoryStream();
            newResponseBody.Seek(0, SeekOrigin.Begin);
            context.Response.Body = responseBody;
            string responseData = await new StreamReader(newResponseBody).ReadToEndAsync();

            if (string.IsNullOrEmpty(responseData) && context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                responseData = "Unauthorized user";
            }

            responseData = responseData.TurkishCharacterChange();
            //Fluent validation error response
            object validationResponse = null;
            if ((context.Request.Method == "POST" || context.Request.Method == "PUT")
                && responseData.Contains("validation errors"))
            {
                var returnObject = JObject.Parse(responseData);
                responseData = returnObject.Property("errors").ToString(Formatting.None);
                validationResponse = JsonConvert.DeserializeObject("{" + responseData + "}");
            }

            var result = JsonConvert.SerializeObject(new
            {
                statuscode = context.Response.StatusCode,
                message = context.Response.StatusCode == (int)HttpStatusCode.OK ? "success" : 
                                                                                    (validationResponse ?? responseData.Nullify()),
                result = GetResult()
            });

            string userName = null;
            var contextEndPoint = context.GetEndpoint().Metadata.Select(x => x.GetType()).FirstOrDefault(x => x.Name == "AllowAnonymousAttribute");
            if (contextEndPoint == null && context.Items.TryGetValue("userName", out var user))
            {
                userName = user.ToString();
            }

            LogToTable();

            stopwatch.Stop();

            context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
            {
                MustRevalidate = true,
                NoCache = true,
                NoStore = true
            };

            //set response contentlength to original value otherwise it gets error
            context.Response.ContentLength = result.Length;

            //if http status is No Content (204), response shows nothing so we set status to 200
            if (context.Response.StatusCode == (int)HttpStatusCode.NoContent)
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            await context.Response.WriteAsync(result);

            #region Methods
            

            object GetResult()
            {
                if (!string.IsNullOrEmpty(responseData) && context.Response.StatusCode == (int)HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject(responseData);

                return null;
            }

            void LogToTable()
            {
                var methodName = context.Request.Path.Value.Split("/")[3];
                var serviceName = string.Format("{0}Service", context.Request.Path.Value.Split("/")[2]);
                var typeOfService = Provider.ServiceAssembly.GetExportedTypes().FirstOrDefault(x => x.Name == serviceName);
                
                var attributes = typeOfService.GetAttributesOfMethod(methodName);
                var isLoggable = (LoggableAttribute)attributes.FirstOrDefault(x => x.GetType() == typeof(LoggableAttribute));

                string logRequest = null, logResponse = null;
                if(isLoggable != null)
                {
                    if (!isLoggable.IsRequestLoggable)
                    {
                        logRequest = "*******************************************";
                    }

                    if (!isLoggable.IsResponseLoggable)
                    {
                        logResponse = "*******************************************";
                    }
                }
                Context dbContext = new();

                dbContext.Set<ApiLog>().Add(new ApiLog()
                {
                    Request = logRequest ?? requestData,
                    Response = logResponse ?? responseData,
                    StatusCode = context.Response.StatusCode,
                    ServiceName = methodName,
                    RouteUrl = context.Request.Path,
                    Method = context.Request.Method,
                    Duration = stopwatch.ElapsedMilliseconds,
                    UserName = userName ?? Environment.MachineName,
                    CreatedDate = DateTime.Now.DateToInt(),
                    CreatedTime = DateTime.Now.TimeToInt(),
                });

                dbContext.SaveChanges();
                dbContext.Dispose();
            }
            #endregion
        }
    }
}
