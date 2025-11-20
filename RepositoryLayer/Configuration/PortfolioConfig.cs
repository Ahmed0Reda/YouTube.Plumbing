using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration
{
    public class PortfolioConfig : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();
            builder.HasData(new Portfolio
            {
                Id = 1,
                Title = "Project Management System",
                FileName = "Test",
                FileType = "Test",
                CategoryId = 1, 
            }, new Portfolio
            {
                Id = 2,
                Title = "E-Commerce Website",
                FileName = "Test2",
                FileType = "Test2",
                CategoryId = 2, 
            }, new Portfolio
            {
                Id = 3,
                Title = "Social Media Platform",
                FileName = "Test3",
                FileType = "Test3",
                CategoryId = 3,
            }, new Portfolio
            {
                Id = 4,
                Title = "Blogging Platform",
                FileName = "Test4",
                FileType = "Test4",
                CategoryId = 2,
            });

        }
    }
}
