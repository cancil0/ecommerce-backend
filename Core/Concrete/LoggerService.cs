using Core.Abstract;
using Core.Attributes;
using Core.Extension;
using Entities.Concrete;
using Entities.EntityAttributes;
using Infrastructure.Concrete;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using NLog.Targets;
using System.Reflection;

namespace Core.Concrete
{
    public class LoggerService : ILoggerService
    {
        /**
         * You can check loglevel's rules in nlog.config
         * If you want to watch logs in files and console but not in database, use LogDebug method
         * If you want to watch logs in database and console, use LogInfo method
         */

        private readonly ILocalizerService localizerService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger logger;
        private readonly Context dbContext;

        public LoggerService(ILocalizerService localizerService, IHttpContextAccessor httpContextAccessor, Context dbContext)
        {
            this.localizerService = localizerService;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
            logger = LogManager.GetCurrentClassLogger();
        }

        public void LogInfo(string key, params string[] args) => logger.Info(localizerService.GetResource(key, args));
        public void LogDebug(string key, params string[] args) => logger.Debug(localizerService.GetResource(key, args));
        public void LogWarn(string key, params string[] args) => logger.Warn(localizerService.GetResource(key, args));
        public void LogError(string key, params string[] args) => logger.Error(localizerService.GetResource(key, args));
        public void LogException(Exception exception, string message) => logger.Error(exception, message);

        public void Logger(object requestData, object responseData)
        {
            var context = httpContextAccessor.HttpContext;
            DatabaseTarget target = new()
            {
                Name = "DatabaseLogger",
                DBProvider = "Npgsql.NpgsqlConnection, Npgsql",
                ConnectionString = ContextConfiguration.ConnectionString,
                CommandText = "INSERT INTO system.apilog " +
                                 "(apilogid, username, statuscode, method, servicename, routeurl, request, response, duration, createddate, createdtime)" +
                                 "VALUES(GUID, USER_NAME, STATUS_CODE, METHOD, SERVICE_NAME, ROUTE_URL, REQUEST, RESPONSE, DURATION, CREATED_DATE, CREATED_TIME)",

                KeepConnection = true
            };

            target.Parameters.Add(new DatabaseParameterInfo("GUID", Guid.NewGuid().ToString()));
            target.Parameters.Add(new DatabaseParameterInfo("USER_NAME", "default" ?? context.Items["UserName"].ToString()));
            target.Parameters.Add(new DatabaseParameterInfo("STATUS_CODE", context.Response.StatusCode.ToString()));
            target.Parameters.Add(new DatabaseParameterInfo("METHOD", context.Request.Path.Value.Split("/")[3]));
            target.Parameters.Add(new DatabaseParameterInfo("SERVICE_NAME", context.Request.Path.Value.Split("/")[2]));
            target.Parameters.Add(new DatabaseParameterInfo("ROUTE_URL", context.Request.Path.Value));
            target.Parameters.Add(new DatabaseParameterInfo("REQUEST", requestData.ToString()));
            target.Parameters.Add(new DatabaseParameterInfo("RESPONSE", responseData.ToString()));
            target.Parameters.Add(new DatabaseParameterInfo("DURATION", context.Response.Headers["duration"].ToString()));
            target.Parameters.Add(new DatabaseParameterInfo("CREATED_DATE", DateTime.Now.ToString("yyyyMMdd")));
            target.Parameters.Add(new DatabaseParameterInfo("CREATED_TIME", DateTime.Now.ToString("HHmmss")));

            NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);

            Logger logger = LogManager.GetLogger("DatabaseLogger");
            logger.Debug("Logged to db");
        }

        public void LogToApiCallLog(HttpContext context, string request, string response)
        {
            var controller = ApplicationBuilder.GetController(context);
            var loggerController = controller.MethodInfo.GetCustomAttribute<LoggerAttribute>();
            var controllerReturnType = controller.MethodInfo.ReturnType;
            if (loggerController != null)
            {
                var isRequestLoggable = loggerController.IsRequestLoggable;
                var isResponseLoggable = loggerController.IsResponseLoggable;
                var correlationId = context.Items["CorrelationId"].ToString();
                var apiId = new Guid(correlationId);
                dbContext.Set<ApiLog>().Add(new ApiLog()
                {
                    ApiLogId = apiId,
                    Request = isRequestLoggable ? request : null,
                    Response = isResponseLoggable ? HidePropertyInLog(response, controllerReturnType) : null,
                    StatusCode = context.Response.StatusCode,
                    ServiceName = context.Request.Path.Value.Split("/")[3],
                    RouteUrl = context.Request.Path,
                    Method = context.Request.Method,
                    Duration = context.Items["Duration"].ToString().ToLong(),
                    UserName = context.Items["UserName"]?.ToString() ?? Environment.MachineName,
                    CreatedDate = DateTime.Now.DateToInt(),
                    CreatedTime = DateTime.Now.TimeToInt(),
                });
                dbContext.SaveChanges(true);
            }
        }

        private static string HidePropertyInLog(string response, Type responseType)
        {
            var properties = responseType.GetProperties().LastOrDefault()?.PropertyType.GetProperties();
            if(properties == null || !properties.Any())
            {
                return response;
            }
            var jsonResponse = JObject.Parse(response);
            JToken jToken = jsonResponse.GetValue("Data");

            if (jToken == null)
            {
                return response;
            }
            var res = new JObject();

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<NotLoggablePropertyAttribute>() != null)
                {
                    res.Add(property.Name, "******");
                }
                else
                {
                    res.Add(property.Name, jToken[property.Name]);
                }
            }
            return res.ToString(Formatting.None);
        } 
    }
}
