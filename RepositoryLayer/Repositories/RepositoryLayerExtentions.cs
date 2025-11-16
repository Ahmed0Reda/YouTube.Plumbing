using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Contexts;

namespace RepositoryLayer.Repositories
{
    public static class RepositoryLayerExtentions
    {
        public static IServiceCollection LoadRepositoryLayerExtenstions(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("sqlConnection")));
            return services;
        }
    }
}
