using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IGenericDal<T> where T : class
    {
        //Get
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        T GetAsNoTracking(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

        //Get as List
        List<T> GetAll();
        List<T> GetAllWithInclude(params Expression<Func<T, object>>[] includes);
        List<T> GetMany(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetManyAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);

        //Insert
        void Insert(T item);
        Task InsertAsync(T item);
        void InsertBulk(List<T> item);
        Task InsertBulkAsync(T item);

        //Delete
        void Delete(T item);
        void DeleteBulk(List<T> item);

        //Update
        void Update(T item);
        void UpdateBulk(List<T> item);
    }
}
