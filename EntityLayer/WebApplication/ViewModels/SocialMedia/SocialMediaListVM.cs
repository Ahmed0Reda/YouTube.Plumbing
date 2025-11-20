using EntityLayer.WebApplication.ViewModels.AboutVM;

namespace EntityLayer.WebApplication.ViewModels.SocialMedia
{
    public class SocialMediaListVM
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; } = DateTime.UtcNow.ToString("d");
        public string? UpdatedDate { get; set; }
        public string Twitter { get; set; } = null!;
        public string Linkedin { get; set; } = null!;
        public string Facebook { get; set; } = null!;
        public string Instagram { get; set; } = null!;
        public AboutListVM AboutUsPage { get; set; } = null!;
    }
}
