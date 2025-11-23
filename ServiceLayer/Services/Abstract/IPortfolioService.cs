using EntityLayer.WebApplication.ViewModels.Portfolio;

namespace ServiceLayer.Services.Abstract
{
    public interface IPortfolioService
    {
        Task<List<PortfolioListVM>> GetAllListAsync();
        Task AddPortfolioAsync(PortfolioAddVM model);
        Task DeletePortfolioAsync(int id);
        Task<PortfolioUpdateVM> GetPortfolioById(int id);
        Task UpdatePortfolioAsync(PortfolioUpdateVM model);
    }
}
