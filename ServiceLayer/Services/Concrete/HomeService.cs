using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Contact;
using EntityLayer.WebApplication.ViewModels.HomePage;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class HomeService : IHomeService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public HomeService( IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<List<HomePageListVM>> GetAllListAsync()
        {
            var HomeListVM = await _uniteOfWork.GetGenericRepository<HomePage>().GetAllEntityList().
                ProjectTo<HomePageListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return HomeListVM;
        }
        public async Task AddHomeAsync(HomePageAddVM model)
        {
            var HomeEntity = _mapper.Map<HomePage>(model);
            await _uniteOfWork.GetGenericRepository<HomePage>().AddEntityAsync(HomeEntity);
            await _uniteOfWork.CommitAsync();
        }
        public async Task DeleteHomeAsync(int id)
        {
            var HomeEntity = await _uniteOfWork.GetGenericRepository<HomePage>().GetEntityByIdAsync(id);
            if (HomeEntity != null)
            {
                _uniteOfWork.GetGenericRepository<HomePage>().DeleteEntity(HomeEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
        public async Task<HomePageUpdateVM> GetHomeById(int id)
        {
            var HomeEntity = await _uniteOfWork.GetGenericRepository<HomePage>().Where(x => x.Id == id).
                ProjectTo<HomePageUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return HomeEntity;
        }
        //public async Task UpdateHomeAsync(HomePageUpdateVM model)
        //{
        //    var HomeEntity = await _uniteOfWork.GetGenericRepository<HomePage>().GetEntityByIdAsync(model.Id);
        //    if (HomeEntity != null)
        //    {
        //        _mapper.Map(model, HomeEntity);
        //        _uniteOfWork.GetGenericRepository<HomePage>().UpdateEntity(HomeEntity);
        //        await _uniteOfWork.CommitAsync();
        //    }
        //}
        public async Task UpdateHomeAsync(HomePageUpdateVM model)
        {
            var about = _mapper.Map<HomePage>(model);
            _uniteOfWork.GetGenericRepository<HomePage>().UpdateEntity(about);
            await _uniteOfWork.CommitAsync();
        }
    }
}
