using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Mapping;
using Core.IoC;
using DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolver.Autofac
{
    public static class AutofacRegister
    {
        public static IServiceCollection AddAutofacContainer(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericDal<>));
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterModule(new AutofacBusinessModule());
            Provider.Container = containerBuilder.Build();
            return services;
        }
    }
}
