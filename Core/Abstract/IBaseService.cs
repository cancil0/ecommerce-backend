namespace Core.Abstract
{
    public interface IBaseService<TBaseEntity>
    {
        T Resolve<T>();
        T CreateInstance<T>();
    }
}
