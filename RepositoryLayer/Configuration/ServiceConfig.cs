using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);
            builder.HasData(
                new Service
                {
                    Id = 1,
                    Name = "Web Development",
                    Description = "Professional web development services using the latest technologies.",
                    Icon = "web_dev_icon.png",
                },
                new Service
                {
                    Id = 2,
                    Name = "Mobile App Development",
                    Description = "Creating user-friendly mobile applications for Android and iOS platforms.",
                    Icon = "mobile_app_icon.png",
                },
                new Service
                {
                    Id = 3,
                    Name = "Digital Marketing",
                    Description = "Comprehensive digital marketing solutions to boost your online presence.",
                    Icon = "digital_marketing_icon.png",
                }
            );
        }
    }
}
