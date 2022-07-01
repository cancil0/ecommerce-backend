using Infrastructure.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class GenericDal<T> : IGenericDal<T> where T : class
    {
        protected Context context;
        internal DbSet<T> dbSet;

        public GenericDal(Context context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return dbSet.Find(id);
        }
        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbSet.FindAsync(new object[] {id}, cancellationToken);
        }

        public T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.Where(expression);
            return includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).FirstOrDefault();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            return await includes.Aggregate(dbSet.Where(expression), (currrent, includeProperty) => currrent.Include(includeProperty)).FirstOrDefaultAsync(cancellationToken);
        }

        public T GetAsNoTracking(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            return includes.Aggregate(dbSet.AsNoTracking().Where(expression), (currrent, includeProperty) => 
                            currrent.Include(includeProperty)).FirstOrDefault();
        }
        public async Task<T> GetAsNoTrackingAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            return await includes.Aggregate(dbSet.AsNoTracking().Where(expression), (currrent, includeProperty) => 
                                  currrent.Include(includeProperty)).FirstOrDefaultAsync(cancellationToken);
        }

        public List<T> GetMany(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.Where(expression);
            return includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).ToList();
        }
        public async Task<List<T>> GetManyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            return await includes.Aggregate(dbSet.Where(expression), (currrent, includeProperty) => currrent.Include(includeProperty)).ToListAsync(cancellationToken);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }
        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await dbSet.ToListAsync(cancellationToken);
        }

        public List<T> GetAllWithInclude(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;
            return includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).ToList();
        }
        public async Task<List<T>> GetAllWithIncludeAsync(CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;
            return await includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).ToListAsync(cancellationToken);
        }

        public void Insert(T item)
        {
            dbSet.Add(item);
        }
        public void InsertAsync(T item, CancellationToken cancellationToken = default)
        {
            dbSet.AddAsync(item, cancellationToken);
        }

        public void InsertBulk(List<T> item)
        {
            dbSet.AddRange(item);
        }
        public void InsertBulkAsync(IEnumerable<T> item, CancellationToken cancellationToken = default)
        {
            dbSet.AddRangeAsync(item, cancellationToken);
        }

        public void Update(T item)
        {
            dbSet.Update(item);
        }
        public void UpdateBulk(List<T> item)
        {
            dbSet.UpdateRange(item);
        }

        public void Delete(T item)
        {
            dbSet.Remove(item);
        }
        public void DeleteBulk(List<T> item)
        {
            dbSet.RemoveRange(item);
        }
        
    }
}
