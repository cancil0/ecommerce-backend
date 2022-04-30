using Core.IoC;
using Infrastructure.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class GenericDal<T> : IGenericDal<T> where T : class
    {
        protected Context context;
        internal DbSet<T> dbSet;

        public GenericDal()
        {
            context = Provider.Resolve<Context>();
            dbSet = context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }
        public T Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.Where(expression);
            return includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).FirstOrDefault();
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.Where(expression);
            return await includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).FirstOrDefaultAsync();
        }
        public T GetAsNoTracking(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsNoTracking().Where(expression);
            return includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).FirstOrDefault();
        }
        public List<T> GetMany(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.Where(expression);
            return includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).ToList();
        }
        public async Task<List<T>> GetManyAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.Where(expression);
            return await includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).ToListAsync();
        }
        public List<T> GetAll()
        {
            return dbSet.ToList();
        }
        public List<T> GetAllWithInclude(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;
            return includes.Aggregate(query, (currrent, includeProperty) => currrent.Include(includeProperty)).ToList();
        }

        public void Insert(T item)
        {
            dbSet.Add(item);
        }

        public void InsertBulk(List<T> item)
        {
            dbSet.AddRange(item);
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

        public async Task InsertAsync(T item)
        {
            await dbSet.AddAsync(item);
        }

        public async Task InsertBulkAsync(T item)
        {
            await dbSet.AddRangeAsync(item);
        }

    }
}
