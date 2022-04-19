using Core.Base.Abstract;
using Core.IoC;

namespace Core.Base.Concrete
{
    public class BaseService<TBaseEntity> : IBaseService<TBaseEntity> where TBaseEntity : class
    {
        protected T Resolve<T>()
        {
            return Provider.Resolve<T>();
        }
    }
}
