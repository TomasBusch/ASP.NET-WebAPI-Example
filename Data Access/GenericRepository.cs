using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Data_Access.Database;
using WebAPI.Models;

namespace WebAPI.Data_Access
{
    public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
    {
        internal AppDbContext _dbContext;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            this.dbSet = _dbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, List<string>? includeProperties = null, int offset = 0, int count = 100)
        {
            IQueryable<TEntity> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            query = query.Skip(offset);
            query = query.Take(count);

            return query.ToList();
        }

        public virtual TEntity? GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(int id)
        {
            TEntity? entity = dbSet.Find(id);

            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
    }
}
