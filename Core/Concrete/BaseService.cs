using Core.Abstract;
using Core.IoC;

namespace Core.Concrete
{
    public class BaseService<TBaseEntity> : IBaseService<TBaseEntity> where TBaseEntity : class
    {
        public T Resolve<T>() => Provider.Resolve<T>();
        public T CreateInstance<T>() => (T)Activator.CreateInstance(typeof(T));
    }
}
