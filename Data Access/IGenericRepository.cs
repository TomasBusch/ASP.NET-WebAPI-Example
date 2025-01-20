using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Models;

namespace WebAPI.Data_Access
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public void Insert(TEntity entity);
        public TEntity? GetById(int id);
        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            List<string>? includeProperties = null,
            int offset = 0,
            int count = 100
        );
        public IEnumerable<TEntity> GetAll();
        public void Update(TEntity entity);
        public void Delete(int id);
        public void Delete(TEntity entityToDelete);
    }
}