using Autofac.Extensions.DependencyInjection;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Middleware
{
    public class AutofacScope : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string rootLifetimeTag = "AutofacWebApiScope";
            var container = Provider.Container;
            using var scope = container.BeginLifetimeScope(rootLifetimeTag, b =>
            {
                b.Populate(new ServiceCollection(), rootLifetimeTag);
            });
            Provider.ServiceProvider = new AutofacServiceProvider(scope);

            await next(context);

            scope.Dispose();
        }
    }
}
