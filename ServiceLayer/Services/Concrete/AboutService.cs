using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.AboutVM;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public AboutService( IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<List<AboutListVM>> GetAllListAsync()
        {
            var aboutListVM = await _uniteOfWork.GetGenericRepository<AboutUsPage>().GetAllEntityList().
                ProjectTo<AboutListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return aboutListVM; 
        }
        public async Task AddAboutAsync(AboutAddVM model)
        {
            var aboutEntity = _mapper.Map<AboutUsPage>(model);
            await _uniteOfWork.GetGenericRepository<AboutUsPage>().AddEntityAsync(aboutEntity);
            await _uniteOfWork.CommitAsync();
        }
        public async Task DeleteAboutAsync(int id)
        {
            var aboutEntity = await _uniteOfWork.GetGenericRepository<AboutUsPage>().GetEntityByIdAsync(id);
            if (aboutEntity != null)
            {
                _uniteOfWork.GetGenericRepository<AboutUsPage>().DeleteEntity(aboutEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
        public async Task<AboutUpdateVM> GetAboutById(int id)
        {
            var about = await _uniteOfWork.GetGenericRepository<AboutUsPage>().Where(x => x.Id == id).
                ProjectTo<AboutUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return about;
        }
        //public async Task UpdateAboutAsync(AboutUpdateVM model)
        //{
        //    var aboutEntity = await _uniteOfWork.GetGenericRepository<AboutUsPage>().GetEntityByIdAsync(model.Id);
        //    if (aboutEntity != null)
        //    {
        //        _mapper.Map(model, aboutEntity);
        //        _uniteOfWork.GetGenericRepository<AboutUsPage>().UpdateEntity(aboutEntity);
        //        await _uniteOfWork.CommitAsync();
        //    }
        //}
        public async Task UpdateAboutAsync(AboutUpdateVM model)
        {
            var about = _mapper.Map<AboutUsPage>(model);
            _uniteOfWork.GetGenericRepository<AboutUsPage>().UpdateEntity(about);
            await _uniteOfWork.CommitAsync();
        }

    }
}
