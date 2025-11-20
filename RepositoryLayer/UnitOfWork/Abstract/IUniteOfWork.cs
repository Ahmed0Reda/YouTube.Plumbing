using CoreLayer.BaseEntities;
using RepositoryLayer.Repositories.Abstract;

namespace RepositoryLayer.UnitOfWork.Abstract
{
    public interface IUniteOfWork
    {
        void Commit();
        Task CommitAsync();
        IGenericRepositories<T> GetGenericRepository<T>() where T : class, IBaseEntity, new();
        ValueTask DisposeAsync();
    }
}
