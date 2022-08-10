using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Core.IoC
{
    public static class Provider
    {
        public static IConfiguration Configuration { get; set; }
        public static IContainer Container { get; set; }
        public static AutofacServiceProvider ServiceProvider { get; set; }
        public static T Resolve<T>() => (T)ServiceProvider.GetService(typeof(T));
    }
}
