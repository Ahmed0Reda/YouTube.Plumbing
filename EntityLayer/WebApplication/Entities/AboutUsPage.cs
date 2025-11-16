using CoreLayer.BaseEntities;

namespace EntityLayer.WebApplication.Entities
{
    public class AboutUsPage : BaseEntity
    {
        public string Header { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Clients { get; set; } = null!;
        public string Projects { get; set; } = null!;
        public string HoursOfSupport { get; set; } = null!;
        public string HardWorkers { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FileType { get; set; } = null!;
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; } = null!;

    }
}
