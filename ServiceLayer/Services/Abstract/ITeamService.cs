using EntityLayer.WebApplication.ViewModels.Team;

namespace ServiceLayer.Services.Abstract
{
    public interface ITeamService
    {
        Task<List<TeamListVM>> GetAllListAsync();
        Task AddTeamAsync(TeamAddVM model);
        Task DeleteTeamAsync(int id);
        Task<TeamUpdateVM> GetTeamById(int id);
        Task UpdateTeamAsync(TeamUpdateVM model);
    }
}
