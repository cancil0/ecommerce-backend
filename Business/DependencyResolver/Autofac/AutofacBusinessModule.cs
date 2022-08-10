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
        protected override void Load(ContainerBuilder builder)
        {
            /*builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("Core")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("Business")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("DataAccess")).AsImplementedInterfaces();*/
            builder.Register(x => new MemoryCache(new MemoryCacheOptions()))
                .As<IMemoryCache>()
                .SingleInstance();

            /*builder.Register(x => new Context())
                .AsSelf()
                .InstancePerLifetimeScope();*/

            builder.Register(x => new HttpContextAccessor())
                .As<IHttpContextAccessor>()
                .InstancePerLifetimeScope();

            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();

            builder.Register(x => new Localization(x.Resolve<ILocalizerService>()))
                .InstancePerLifetimeScope();

            /*builder.Register(x => new AutofacScope())
                .InstancePerLifetimeScope();*/

            builder.Register(x => new Authentication(x.Resolve<IMemoryCache>(), x.Resolve<Context>()))
                .InstancePerLifetimeScope();

            builder.Register(x => new HttpLogging(x.Resolve<ILoggerService>()))
                .InstancePerLifetimeScope();

            builder.Register(x => new Response(x.Resolve<ILoggerService>()))
                .InstancePerLifetimeScope();

            builder.Register(x => new TokenService())
                .As<ITokenService>()
                .InstancePerLifetimeScope();

            builder.Register(x => new LoggerService(x.Resolve<ILocalizerService>(), x.Resolve<IHttpContextAccessor>(), x.Resolve<Context>()))
                .As<ILoggerService>()
                .InstancePerLifetimeScope();

            builder.Register(x => new LocalizerService(x.Resolve<IMemoryCache>()))
                .As<ILocalizerService>()
                .SingleInstance();

            builder.Register(x => new TokenService())
                .As<ITokenService>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("Business"))
                    .AsClosedTypesOf(typeof(IBaseService<>))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("DataAccess"))
                    .AsClosedTypesOf(typeof(IGenericDal<>))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
