using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.IoC;
using DataAccess.Repository;
using Infrastructure.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolver.Autofac
{
    public static class AutofacRegister
    {
        public static IServiceCollection AddAutofacContainer(this IServiceCollection services)
        {
            services.AddLogging();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterModule(new AutofacBusinessModule());
            Provider.Container = containerBuilder.Build();
            return services;
        }

        public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericDal<>));
            return services;
        }
        public static IServiceCollection InjectDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped(provider => provider.GetService<Context>());
            return services;
        }

        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddAutofacContainer();
            //services.InjectApplicationServices();
            //services.InjectDataAccessServices();
            return services;
        }
    }
}
