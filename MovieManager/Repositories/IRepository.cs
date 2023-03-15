
using System.Linq.Expressions;

namespace MovieManager.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Delete(TEntity entityToDelete);
        Task Delete(object id);
        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetByID(object id);
        Task Insert(TEntity entity);
        Task Update(TEntity entityToUpdate);
    }
}

