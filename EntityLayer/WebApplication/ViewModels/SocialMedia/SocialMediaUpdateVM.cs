using EntityLayer.WebApplication.ViewModels.AboutVM;

namespace EntityLayer.WebApplication.ViewModels.SocialMedia
{
    public class SocialMediaUpdateVM
    {
        public int Id { get; set; }
        public string? UpdatedDate { get; set; }
        public byte[] RowVersion { get; set; } = null!;
        public string Twitter { get; set; } = null!;
        public string Linkedin { get; set; } = null!;
        public string Facebook { get; set; } = null!;
        public string Instagram { get; set; } = null!;
        public AboutUpdateVM AboutUsPage { get; set; } = null!;
    }
}
