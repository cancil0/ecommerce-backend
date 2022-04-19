using Autofac;
using Business.Mapping;
using Core.Base.Abstract;
using Core.Base.Concrete;
using Core.IoC;
using Core.Middleware.LocalizationMiddleware;
using DataAccess.Repository;
using Infrastructure.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        public AutofacBusinessModule()
        {
            Provider.ServiceAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            Provider.GenericDalAssembly = System.Reflection.Assembly.GetAssembly(typeof(IGenericDal<>));
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new Context())
                .InstancePerLifetimeScope();

            builder.Register(x => new MemoryCache(new MemoryCacheOptions()))
                .As<IMemoryCache>()
                .InstancePerLifetimeScope()
                .OnRelease(x => x.Dispose());

            builder.Register(x => new HttpContextAccessor())
                .As<IHttpContextAccessor>()
                .InstancePerDependency();

            builder.Register(x => new LocalizationHandler())
                .SingleInstance();

            builder.Register(x => new LocalizerService())
                .As<ILocalizerService>()
                .SingleInstance();

            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();

            builder.RegisterAssemblyTypes(Provider.ServiceAssembly)
                    .AsClosedTypesOf(typeof(IBaseService<>))
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

            builder.RegisterAssemblyTypes(Provider.GenericDalAssembly)
                    .AsClosedTypesOf(typeof(IGenericDal<>))
                    .AsImplementedInterfaces()
                    .InstancePerDependency();

        }
    }
}
