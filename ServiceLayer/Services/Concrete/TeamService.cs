using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.Team;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.UnitOfWork.Abstract;
using ServiceLayer.Services.Abstract;

namespace ServiceLayer.Services.Concrete
{
    public class TeamService : ITeamService
    {
        private readonly IUniteOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public TeamService(IUniteOfWork uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }
        public async Task<List<TeamListVM>> GetAllListAsync()
        {
            var TeamListVM = await _uniteOfWork.GetGenericRepository<Team>().GetAllEntityList().
                ProjectTo<TeamListVM>(_mapper.ConfigurationProvider).ToListAsync();
            return TeamListVM;
        }
        public async Task AddTeamAsync(TeamAddVM model)
        {
            var Team = _mapper.Map<Team>(model);
            await _uniteOfWork.GetGenericRepository<Team>().AddEntityAsync(Team);
            await _uniteOfWork.CommitAsync();
        }
        public async Task DeleteTeamAsync(int id)
        {
            var TeamEntity = await _uniteOfWork.GetGenericRepository<Team>().GetEntityByIdAsync(id);
            if (TeamEntity != null)
            {
                _uniteOfWork.GetGenericRepository<Team>().DeleteEntity(TeamEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
        public async Task<TeamUpdateVM> GetTeamById(int id)
        {
            var TeamEntity = await _uniteOfWork.GetGenericRepository<Team>().Where(x => x.Id == id).
                ProjectTo<TeamUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
            return TeamEntity;
        }
        public async Task UpdateTeamAsync(TeamUpdateVM model)
        {
            var TeamEntity = await _uniteOfWork.GetGenericRepository<Team>().GetEntityByIdAsync(model.Id);
            if (TeamEntity != null)
            {
                _mapper.Map(model, TeamEntity);
                _uniteOfWork.GetGenericRepository<Team>().UpdateEntity(TeamEntity);
                await _uniteOfWork.CommitAsync();
            }
        }
    }
}
