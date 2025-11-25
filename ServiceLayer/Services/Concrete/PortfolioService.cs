using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.HomePage;
using EntityLayer.WebApplication.ViewModels.Portfolio;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public PortfolioService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<List<PortfolioListVM>> GetAllListAsync()
        {
            var PortfolioListVM = await _uniteOfWork.GetGenericRepository<HomePage>().GetAllEntityList().
                ProjectTo<PortfolioListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return PortfolioListVM;
        }
        public async Task AddPortfolioAsync(PortfolioAddVM model)
        {
            var PortfolioEntity = _mapper.Map<Portfolio>(model);
            await _uniteOfWork.GetGenericRepository<Portfolio>().AddEntityAsync(PortfolioEntity);
            await _uniteOfWork.CommitAsync();
        }
        public async Task DeletePortfolioAsync(int id)
        {
            var PortfolioEntity = await _uniteOfWork.GetGenericRepository<Portfolio>().GetEntityByIdAsync(id);
            if (PortfolioEntity != null)
            {
                _uniteOfWork.GetGenericRepository<Portfolio>().DeleteEntity(PortfolioEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
        public async Task<PortfolioUpdateVM> GetPortfolioById(int id)
        {
            var PortfolioEntity = await _uniteOfWork.GetGenericRepository<Portfolio>().Where(x => x.Id == id).
                ProjectTo<PortfolioUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return PortfolioEntity;
        }
        //public async Task UpdatePortfolioAsync(PortfolioUpdateVM model)
        //{
        //    var PortfolioEntity = await _uniteOfWork.GetGenericRepository<Portfolio>().GetEntityByIdAsync(model.Id);
        //    if (PortfolioEntity != null)
        //    {
        //        _mapper.Map(model, PortfolioEntity);
        //        _uniteOfWork.GetGenericRepository<Portfolio>().UpdateEntity(PortfolioEntity);
        //        await _uniteOfWork.CommitAsync();
        //    }
        //}
        public async Task UpdatePortfolioAsync(PortfolioUpdateVM model)
        {
            var about = _mapper.Map<Portfolio>(model);
            _uniteOfWork.GetGenericRepository<Portfolio>().UpdateEntity(about);
            await _uniteOfWork.CommitAsync();
        }
    }
}
