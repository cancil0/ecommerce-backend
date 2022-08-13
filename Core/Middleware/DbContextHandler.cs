using Autofac;
using Core.IoC;
using Infrastructure.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Middleware
{
    public class DbContextHandler : IMiddleware
    {
        private readonly Context dbContext;
        public DbContextHandler(Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Provider.LifetimeScope = (ILifetimeScope)context.RequestServices.GetService(typeof(ILifetimeScope));

            await next(context);

            if (dbContext.Database.CurrentTransaction != null)
            {
                await dbContext.Database.CommitTransactionAsync();
                await dbContext.Database.CurrentTransaction.DisposeAsync();
            }
        }
    }
}