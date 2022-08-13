using Autofac;

namespace Core.IoC
{
    public static class Provider
    {
        public static ILifetimeScope LifetimeScope { get; set; }
        public static T Resolve<T>() => (T)LifetimeScope.Resolve<T>();
    }
}
