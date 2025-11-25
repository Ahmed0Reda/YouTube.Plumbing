using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.CategoryVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public CategoryService( IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<List<CategoryListVM>> GetAllListAsync()
        {
            var CategoryListVM = await _uniteOfWork.GetGenericRepository<AboutUsPage>().GetAllEntityList().
                ProjectTo<CategoryListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return CategoryListVM;
        }
        public async Task AddCategoryAsync(CategoryAddVM model)
        {
            var CategoryEntity = _mapper.Map<Category>(model);
            await _uniteOfWork.GetGenericRepository<Category>().AddEntityAsync(CategoryEntity);
            await _uniteOfWork.CommitAsync();
        }
        public async Task DeleteCategoryAsync(int id)
        {
            var CategoryEntity = await _uniteOfWork.GetGenericRepository<Category>().GetEntityByIdAsync(id);
            if (CategoryEntity != null)
            {
                _uniteOfWork.GetGenericRepository<Category>().DeleteEntity(CategoryEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
        public async Task<CategoryUpdateVM> GetCategoryById(int id)
        {
            var CategoryEntity = await _uniteOfWork.GetGenericRepository<Category>().Where(x => x.Id == id).
                ProjectTo<CategoryUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return CategoryEntity;
        }
        //public async Task UpdateCategoryAsync(CategoryUpdateVM model)
        //{
        //    var CategoryEntity = await _uniteOfWork.GetGenericRepository<Category>().GetEntityByIdAsync(model.Id);
        //    if (CategoryEntity != null)
        //    {
        //        _mapper.Map(model, CategoryEntity);
        //        _uniteOfWork.GetGenericRepository<Category>().UpdateEntity(CategoryEntity);
        //        await _uniteOfWork.CommitAsync();
        //    }
        //}
        public async Task UpdateCategoryAsync(CategoryUpdateVM model)
        {
            var about = _mapper.Map<Category>(model);
            _uniteOfWork.GetGenericRepository<Category>().UpdateEntity(about);
            await _uniteOfWork.CommitAsync();
        }

    }
}
