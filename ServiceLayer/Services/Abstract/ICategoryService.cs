using EntityLayer.WebApplication.ViewModels.CategoryVM;

namespace ServiceLayer.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryListVM>> GetAllListAsync();
        Task AddCategoryAsync(CategoryAddVM model);
        Task DeleteCategoryAsync(int id);
        Task<CategoryUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(CategoryUpdateVM model);
    }
}
