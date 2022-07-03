using Infrastructure.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

        public T GetById(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }
        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await dbSet.FindAsync(new object[] {id}, cancellationToken);
        }

        public T Get(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = false)
        {

            IQueryable<T> query = dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query.FirstOrDefault();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = false, CancellationToken cancellationToken = default)
        {

            IQueryable<T> query = dbSet;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
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
            return includes.Aggregate(dbSet.Where(expression), (currrent, includeProperty) => currrent.Include(includeProperty)).ToList();
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
        public List<T> GetAllWithIncludes(Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
        {
            IQueryable<T> query = dbSet;
            query = include(query);
            return query.ToList();
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
        public async void InsertAsync(T item, CancellationToken cancellationToken = default)
        {
            await dbSet.AddAsync(item, cancellationToken);
        }

        public void InsertBulk(List<T> item)
        {
            dbSet.AddRange(item);
        }
        public async void InsertBulkAsync(IEnumerable<T> item, CancellationToken cancellationToken = default)
        {
            await dbSet.AddRangeAsync(item, cancellationToken);
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
