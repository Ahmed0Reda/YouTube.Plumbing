using CoreLayer.BaseEntities;

namespace EntityLayer.WebApplication.Entities
{
    public class Team : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Twitter { get; set; } = null!;
        public string Linkedin { get; set; } = null!;
        public string Facebook { get; set; } = null!;
        public string Instagram { get; set; } = null!;
    }
}
