using Autofac;
using Business.Mapping;
using Core.Abstract;
using Core.Concrete;
using Core.IoC;
using Core.Middleware;
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
            builder.Register(x => new MemoryCache(new MemoryCacheOptions()))
                .As<IMemoryCache>()
                .SingleInstance();

            builder.Register(x => new Context())
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.Register(x => new HttpContextAccessor())
                .As<IHttpContextAccessor>()
                .InstancePerLifetimeScope();

            builder.Register(x => new LocalizerService(x.Resolve<IMemoryCache>()))
                .As<ILocalizerService>()
                .SingleInstance();

            builder.Register(x => new Localization(x.Resolve<ILocalizerService>()))
                .InstancePerLifetimeScope();

            builder.Register(x => new AutofacScope())
                .InstancePerLifetimeScope();

            builder.Register(x => new Authentication())
                .InstancePerLifetimeScope();

            builder.Register(x => new HttpLogging())
                .InstancePerLifetimeScope();

            builder.Register(x => new Response())
                .InstancePerLifetimeScope();

            builder.Register(x => new LoggerService())
                .As<ILoggerService>()
                .InstancePerLifetimeScope();

            builder.Register(x => new TokenService())
                .As<ITokenService>()
                .InstancePerLifetimeScope();

            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();

            builder.RegisterAssemblyTypes(Provider.ServiceAssembly)
                    .AsClosedTypesOf(typeof(IBaseService<>))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Provider.GenericDalAssembly)
                    .AsClosedTypesOf(typeof(IGenericDal<>))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
