using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration
{
    public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.HasData(
                new SocialMedia
                {
                    Id = 1,
                    Twitter = "https://twitter.com/YourProfile",
                    Linkedin = "https://www.linkedin.com/in/YourProfile",
                    Facebook = "https://www.facebook.com/YourProfile",
                    Instagram = "https://www.instagram.com/YourProfile",
                }
            );
        }
    }
}
