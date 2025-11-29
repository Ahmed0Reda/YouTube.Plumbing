using EntityLayer.WebApplication.ViewModels.CategoryVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Abstract;

namespace YouTube.Plumbing.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> GetCategroyList()
        {
            var CategoryList = await _categoryService.GetAllListAsync();
            return View(CategoryList);
        }

        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryAddVM model)
        {
            await _categoryService.AddCategoryAsync(model);
            return RedirectToAction("GetCategroyList", "Category", new { Area = ("Admin") });
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateVM model)
        {
            await _categoryService.UpdateCategoryAsync(model);
            return RedirectToAction("GetCategroyList", "Category", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("GetCategroyList", "Category", new { Area = ("Admin") });
        }

    }
}
