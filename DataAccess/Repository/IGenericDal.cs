using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public interface IGenericDal<T> where T : class
    {
        //Get
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        T GetAsNoTracking(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsNoTrackingAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
        T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

        //Get as List
        List<T> GetAll();
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        List<T> GetAllWithInclude(params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetAllWithIncludeAsync(CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
        List<T> GetMany(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<List<T>> GetManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

        //Insert
        void Insert(T item);
        void InsertAsync(T item, CancellationToken cancellationToken = default);
        void InsertBulk(List<T> item);
        void InsertBulkAsync(IEnumerable<T> item, CancellationToken cancellationToken = default);

        //Delete
        void Delete(T item);
        void DeleteBulk(List<T> item);

        //Update
        void Update(T item);
        void UpdateBulk(List<T> item);
    }
}
