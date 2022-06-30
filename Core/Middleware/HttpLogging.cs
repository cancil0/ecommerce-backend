using Core.Abstract;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Core.Middleware
{
    public class HttpLogging : IMiddleware
    {
        private readonly ILoggerService loggerService;
        public HttpLogging()
        {
            loggerService = Provider.Resolve<ILoggerService>();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            string correlationId = Guid.NewGuid().ToString("N");
            context.Items.Add("CorrelationId", correlationId);
            NLog.ScopeContext.PushProperty("CorrelationId", correlationId);

            context.Response.OnStarting(() =>
            {
                stopwatch.Stop();

                context.Response.Headers["duration"] = stopwatch.ElapsedMilliseconds.ToString();

                var properties = new List<KeyValuePair<string, object>>()
                {
                    new("UserName", context.Items["UserName"] ?? "defaultuser"),
                    new("StatusCode", context.Response.StatusCode),
                    new("HttpMethod", context.Request.Method),
                    new("ServiceName", context.Request.Path.Value.Split("/")[3]),
                    new("RouteUrl", context.Request.Path),
                    new("Duration", stopwatch.ElapsedMilliseconds),
                };

                NLog.ScopeContext.PushProperties(properties);
                loggerService.LogToFile("Logging.HttpServiceFinished", stopwatch.ElapsedMilliseconds.ToString());
                loggerService.LogToDatabase();

                return Task.CompletedTask;
            });

            await next(context);
        }
    }
}
