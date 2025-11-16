using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration
{
    public class ContactUsPageConfig : IEntityTypeConfiguration<ContactUsPage>
    {
        public void Configure(EntityTypeBuilder<ContactUsPage> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.Location).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Call).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Map).IsRequired();
            builder.HasData(
                new ContactUsPage
                {
                    Id = 1,
                    Location = "123 Main St, Anytown, USA",
                    Email = "website@web.com",
                    Call = "01023458935",
                    Map = "Test Map",
                });
        }
    }
}
