using EntityLayer.WebApplication.ViewModels.SocialMedia;

namespace ServiceLayer.Services.Abstract
{
    public interface ISocialMediaService
    {
        Task<List<SocialMediaListVM>> GetAllListAsync();
        Task AddSocialMediaAsync(SocialMediaAddVM model);
        Task DeleteSocialAsync(int id);
        Task<SocialMediaUpdateVM> GetSocialById(int id);
        Task UpdateSocialAsync(SocialMediaUpdateVM model);
    }
}
