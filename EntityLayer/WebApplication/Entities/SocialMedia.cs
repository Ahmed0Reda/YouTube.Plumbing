using CoreLayer.BaseEntities;

namespace EntityLayer.WebApplication.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Twitter { get; set; } = null!;
        public string Linkedin { get; set; } = null!;
        public string Facebook { get; set; } = null!;
        public string Instagram { get; set; } = null!;
        public AboutUsPage AboutUsPage { get; set; } = null!;
    }
}
