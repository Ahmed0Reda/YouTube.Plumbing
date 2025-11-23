using EntityLayer.WebApplication.ViewModels.HomePage;

namespace ServiceLayer.Services.Abstract
{
    public interface IHomeService
    {
        Task<List<HomePageListVM>> GetAllListAsync();
        Task AddHomeAsync(HomePageAddVM model);
        Task DeleteHomeAsync(int id);
        Task<HomePageUpdateVM> GetHomeById(int id);
        Task UpdateHomeAsync(HomePageUpdateVM model);
    }
}
