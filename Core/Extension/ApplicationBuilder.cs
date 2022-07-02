using Core.Abstract;
using Core.ExceptionHandler;
using Core.IoC;
using Core.Middleware;
using Entities.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Core.Extension
{
    public static class ApplicationBuilder
    {
        public static IApplicationBuilder ConfigSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WhatsDis Api v1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                c.DefaultModelsExpandDepth(0);
            });

            app.UseCors(builder => builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin());

            return app;
        }

        public static IApplicationBuilder AddCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<AutofacScope>();
            app.UseMiddleware<HttpLogging>();
            app.UseMiddleware<Localization>();
            app.UseMiddleware<Response>();
            app.ConfigureException();
            app.UseMiddleware<Authentication>();
            app.UseMiddleware<DbContextHandler>();

            return app;
        }

        public static IApplicationBuilder ConfigureException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions() { ExceptionHandler = CustomException, AllowStatusCode404Response = true });

            return app;
        }

        private static async Task CustomException(HttpContext context)
        {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                var loggerService = Provider.Resolve<ILoggerService>();
                switch (contextFeature.Error)
                {
                    case AppException exception:
                        {
                            loggerService.LogError(contextFeature.Error.Message);
                            context.Response.StatusCode = exception.ExceptionType.ToInt();
                            break;
                        }
                    case DbUpdateException exception:
                        {
                            loggerService.LogError(exception.InnerException.Message);
                            context.Response.StatusCode = ExceptionTypes.InternalServerError.GetValue().ToInt();
                            break;
                        }
                    default:
                        {
                            loggerService.LogException(contextFeature.Error, contextFeature.Error.Message);
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            break;
                        }
                }

                context.Items["ExceptionOccured"] = true;

                var response = new ExceptionResponse()
                {
                    StatusCode = context.Response.StatusCode,
                    CorrelationId = context.Items["CorrelationId"].ToString(),
                    Message = contextFeature.Error.Message
                }.ToString();

                await context.Response.WriteAsync(response);
            }
        }
    }
}
