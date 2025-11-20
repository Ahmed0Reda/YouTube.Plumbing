using CoreLayer.BaseEntities;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.Abstract
{
    public interface IGenericRepositories<T> where T : class, IBaseEntity
    {
        Task AddEntityAsync(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        IQueryable<T> GetAllEntityList();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<T> GetEntityByIdAsync(int id);
    }
}
