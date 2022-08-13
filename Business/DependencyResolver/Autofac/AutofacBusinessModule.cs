using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.DependencyResolver.Interceptors;
using Business.Mapping;
using Core.Abstract;
using DataAccess.Repository;
using Infrastructure.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();

            builder.Register(x => new UnitOfWorkInterceptor(x.Resolve<Context>(), x.Resolve<IHttpContextAccessor>()))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("Business"))
                .AsClosedInterfacesOf(typeof(IBaseService<>))
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(UnitOfWorkInterceptor))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("DataAccess"))
                    .AsClosedTypesOf(typeof(IGenericDal<>))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
