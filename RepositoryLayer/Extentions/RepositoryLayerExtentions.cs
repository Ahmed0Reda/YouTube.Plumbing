using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Contexts;
using RepositoryLayer.Repositories.Abstract;
using RepositoryLayer.Repositories.Concrete;
using RepositoryLayer.UnitOfWork.Abstract;
using RepositoryLayer.UnitOfWork.Concrete;

namespace RepositoryLayer.Extentions
{
    public static class RepositoryLayerExtentions
    {
        public static IServiceCollection LoadRepositoryLayerExtenstions(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("sqlConnection")));
            services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));
            services.AddScoped<IUniteOfWork, UniteOfWork>();
            return services;
        }

    }
}
