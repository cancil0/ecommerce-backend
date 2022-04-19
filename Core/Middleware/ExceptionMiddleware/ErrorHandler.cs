using Core.Base.Abstract;
using Core.Extension;
using Core.IoC;
using Infrastructure.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Core.Middleware.ExceptionMiddleware
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILocalizerService localizer;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
            localizer = Provider.Resolve<ILocalizerService>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

                ChangeBaseEntity(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                var responseMessage = string.Empty;
                switch (error)
                {
                    case AppException e:
                        {
                            if (!string.IsNullOrEmpty(e.ExceptionType))
                                response.StatusCode = e.ExceptionType.ToInt();
                            else
                                response.StatusCode = (int)HttpStatusCode.BadRequest;

                            responseMessage = error.Message;
                            break;
                        }
                    case KeyNotFoundException:
                        {
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                            responseMessage = localizer.GetTranslatedValue("HttpStatus.NotFound");
                            break;
                        }
                    case UnauthorizedAccessException:
                        {
                            response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            responseMessage = localizer.GetTranslatedValue("HttpStatus.Unauthorized");
                            break;
                        }
                    case NullReferenceException:
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            responseMessage = localizer.GetTranslatedValue("HttpStatus.InternalServerError");
                            break;
                        }
                    case DbUpdateException e:
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            responseMessage = localizer.GetTranslatedValue("HttpStatus.InternalServerError");
                            break;
                        }
                    default:
                        {
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            responseMessage = localizer.GetTranslatedValue("HttpStatus.InternalServerError");
                            break;
                        }
                }

                await response.WriteAsync(responseMessage);
            }
        }

        /*
         * If there is no error in request, all changes are committed.
         * Properties of BaseEntity are set here.
         */
        private static void ChangeBaseEntity(HttpContext context)
        {
            var dbContext = Provider.Resolve<Context>();

            var entries = dbContext.ChangeTracker.Entries();

            if(!context.Items.TryGetValue("userName", out var userName))
            {
                userName = Environment.MachineName;
            }
            
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added && entityEntry.Properties.Any(x => x.Metadata.Name == "CreatedDate"))
                {
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now.DateToInt();
                    entityEntry.Property("CreatedTime").CurrentValue = DateTime.Now.TimeToInt();
                    entityEntry.Property("CreatedBy").CurrentValue = userName;
                }
                else if (entityEntry.State == EntityState.Modified && entityEntry.Properties.Any(x => x.Metadata.Name == "UpdatedDate"))
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now.DateToInt();
                    entityEntry.Property("UpdatedTime").CurrentValue = DateTime.Now.TimeToInt();
                    entityEntry.Property("UpdatedBy").CurrentValue = userName;
                }
                else if (entityEntry.State == EntityState.Deleted && entityEntry.Properties.Any(x => x.Metadata.Name == "IsDeleted"))
                {
                    entityEntry.State = EntityState.Modified;
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now.DateToInt();
                    entityEntry.Property("UpdatedTime").CurrentValue = DateTime.Now.TimeToInt();
                    entityEntry.Property("IsDeleted").CurrentValue = true;
                    entityEntry.Property("UpdatedBy").CurrentValue = userName;
                }

            }
            //Commit all changes
            dbContext.SaveChanges();
        }
    }
}
