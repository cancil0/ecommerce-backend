using Core.ExceptionHandler;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text;

namespace Core.Middleware
{
    public class Response : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stream responseBody = context.Response.Body;
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;
            await next(context);

            memoryStream.Position = 0;
            string responseString = new StreamReader(memoryStream).ReadToEnd();
            string wrappedResponse = Wrap(responseString, context);
            byte[] responseBytes = Encoding.UTF8.GetBytes(wrappedResponse);
            context.Response.Body = responseBody;
            await context.Response.Body.WriteAsync(responseBytes);
        }

        private static string Wrap(string originalBody, HttpContext context)
        {
            /*
             * Check an exception is thrown. 
             * If it is true, we get response from Exception Middleware
             */
            var exceptionOccured = context.Items["ExceptionOccured"];
            if (exceptionOccured != null)
                return originalBody;

            object response;

            if ((context.Request.Method == "POST" || context.Request.Method == "PUT")
                && originalBody.Contains("validation errors"))
            {
                var returnObject = JObject.Parse(originalBody);
                response = returnObject.Property("errors").ToString(Formatting.None);
                response = JsonConvert.DeserializeObject("{" + response + "}");
            }
            else
            {
                //Json DeserializeObject
                if (originalBody.StartsWith("{") || originalBody.StartsWith("["))
                {
                    response = JsonConvert.DeserializeObject(originalBody, new JsonSerializerSettings()
                    {
                        ObjectCreationHandling = ObjectCreationHandling.Replace,
                        Formatting = Formatting.Indented,
                        Culture = CultureInfo.CurrentCulture,
                        StringEscapeHandling = StringEscapeHandling.EscapeHtml,
                    });
                }
                else
                {
                    response = originalBody;
                }
            }

            var wrapper = new SuccessResponse()
            {
                IsSuccessful = true,
                StatusCode = context.Response.StatusCode,
                CorrelationId = context.Items["CorrelationId"].ToString(),
                Message = "success",
                Data = response
            };

            var wrapperResponse = wrapper.ToString();
            context.Response.ContentLength = wrapperResponse.Length;

            return wrapperResponse;
        }
    }
}
