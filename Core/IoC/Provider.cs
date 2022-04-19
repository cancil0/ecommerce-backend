using Autofac;
using System.Reflection;

namespace Core.IoC
{
    public static class Provider
    {
        public static IContainer Container { get; set; }

        public static T Resolve<T>() => Container.Resolve<T>();

        public static Assembly ServiceAssembly { get; set; }

        public static Assembly GenericDalAssembly { get; set; }
    }
}
