using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Service;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class ServiceService : IServiceService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public ServiceService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<List<ServiceListVM>> GetAllListAsync()
        {
            var PortfolioListVM = await _uniteOfWork.GetGenericRepository<Service>().GetAllEntityList().
                ProjectTo<ServiceListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return PortfolioListVM;
        }
        public async Task AddServiceAsync(ServiceAddVM model)
        {
            var ServiceEntity = _mapper.Map<Service>(model);
            await _uniteOfWork.GetGenericRepository<Service>().AddEntityAsync(ServiceEntity);
            await _uniteOfWork.CommitAsync();
        }
        public async Task DeleteServiceAsync(int id)
        {
            var ServiceEntity = await _uniteOfWork.GetGenericRepository<Service>().GetEntityByIdAsync(id);
            if (ServiceEntity != null)
            {
                _uniteOfWork.GetGenericRepository<Service>().DeleteEntity(ServiceEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
        public async Task<ServiceUpdateVM> GetServiceById(int id)
        {
            var ServiceEntity = await _uniteOfWork.GetGenericRepository<Service>().Where(x => x.Id == id).
                ProjectTo<ServiceUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return ServiceEntity;
        }
        public async Task UpdateServiceAsync(ServiceUpdateVM model)
        {
            var ServiceEntity = await _uniteOfWork.GetGenericRepository<Service>().GetEntityByIdAsync(model.Id);
            if (ServiceEntity != null)
            {
                _mapper.Map(model, ServiceEntity);
                _uniteOfWork.GetGenericRepository<Service>().UpdateEntity(ServiceEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
    }
}
