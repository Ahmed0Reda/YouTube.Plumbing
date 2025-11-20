using CoreLayer.BaseEntities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Contexts;
using RepositoryLayer.Repositories.Abstract;
using System.Linq.Expressions;

namespace RepositoryLayer.Repositories.Concrete
{
    public class GenericRepositories<T> : IGenericRepositories<T> where T : class, IBaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepositories(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddEntityAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void DeleteEntity(T entity) 
        {
            _context.Set<T>().Remove(entity);
        }
        public IQueryable<T> GetAllEntityList() 
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) 
        {
            return _context.Set<T>().Where(predicate);
        }
        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
