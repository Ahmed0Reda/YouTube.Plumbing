using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration
{
    public class HomePageConfig : IEntityTypeConfiguration<HomePage>
    {
        public void Configure(EntityTypeBuilder<HomePage> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.Header).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.VideoLink).IsRequired();
            builder.HasData(new HomePage
            {
                Id = 1,
                Header = "Welcome to Our Website",
                Description = "Discover a world of innovation and creativity with us. We are dedicated to providing top-notch services and solutions to meet your needs.",
                VideoLink = "https://www.example.com/intro-video",
                
            });
        }
    }
}
