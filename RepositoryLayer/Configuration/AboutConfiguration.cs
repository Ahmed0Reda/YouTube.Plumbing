using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration
{
    public class AboutConfiguration : IEntityTypeConfiguration<AboutUsPage>
    {
        public void Configure(EntityTypeBuilder<AboutUsPage> builder)
        {
            builder.Property(x => x.Header).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(5000);
            builder.Property(x => x.Clients).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Projects).IsRequired().HasMaxLength(5);
            builder.Property(x => x.HoursOfSupport).IsRequired().HasMaxLength(5);
            builder.Property(x => x.HardWorkers).IsRequired().HasMaxLength(5);
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.HasData(new AboutUsPage
            {
                Id = 1,
                Header = "About Us",
                Description = "We are a leading company in our industry, committed to providing top-notch services to our clients. Our team of experts works tirelessly to ensure customer satisfaction and deliver exceptional results.",
                Clients = 150,
                Projects = 320,
                HoursOfSupport = 2400,
                HardWorkers = 50,
                FileName = "Test",
                FileType = "Test",
                SocialMediaId = 1,
            });

        }
    }
}
