using RepositoryLayer.Contexts;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.Repositories.Concrete;
using RepositoryLayer.UnitOfWork.Abstract;

namespace RepositoryLayer.UnitOfWork.Concrete
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly AppDbContext _context;

        public UniteOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        IGenericRepositories<T> IUniteOfWork.GetGenericRepository<T>()
        {
            return new GenericRepositories<T>(_context);
        }
    }
}
