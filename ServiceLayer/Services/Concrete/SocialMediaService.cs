using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.SocialMedia;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public SocialMediaService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<List<SocialMediaListVM>> GetAllListAsync()
        {
            var SocialMediaListVM = await _uniteOfWork.GetGenericRepository<SocialMedia>().GetAllEntityList().
                ProjectTo<SocialMediaListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return SocialMediaListVM;
        }
        public async Task AddSocialMediaAsync(SocialMediaAddVM model)
        {
            var SocialEntity = _mapper.Map<SocialMedia>(model);
            await _uniteOfWork.GetGenericRepository<SocialMedia>().AddEntityAsync(SocialEntity);
            await _uniteOfWork.CommitAsync();
        }
        public async Task DeleteSocialAsync(int id)
        {
            var SocialEntity = await _uniteOfWork.GetGenericRepository<SocialMedia>().GetEntityByIdAsync(id);
            if (SocialEntity != null)
            {
                _uniteOfWork.GetGenericRepository<SocialMedia>().DeleteEntity(SocialEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
        public async Task<SocialMediaUpdateVM> GetSocialById(int id)
        {
            var SocialEntity = await _uniteOfWork.GetGenericRepository<SocialMedia>().Where(x => x.Id == id).
                ProjectTo<SocialMediaUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return SocialEntity;
        }
        public async Task UpdateSocialAsync(SocialMediaUpdateVM model)
        {
            var SocialEntity = await _uniteOfWork.GetGenericRepository<SocialMedia>().GetEntityByIdAsync(model.Id);
            if (SocialEntity != null)
            {
                _mapper.Map(model, SocialEntity);
                _uniteOfWork.GetGenericRepository<SocialMedia>().UpdateEntity(SocialEntity);
                await _uniteOfWork.CommitAsync();
            }
        }

    }
}
