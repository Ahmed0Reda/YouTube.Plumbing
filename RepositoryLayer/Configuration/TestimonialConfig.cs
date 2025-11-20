using EntityLayer.WebApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RepositoryLayer.Configuration
{
    public class TestimonialConfig : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(10);
            builder.Property(x => x.UpdatedDate).HasMaxLength(10);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Comment).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.FileName).IsRequired();
            builder.Property(x => x.FileType).IsRequired();
            builder.HasData(
                new Testimonial
                {
                    Id = 1,
                    FullName = "John Doe",
                    Title = "CEO of Company",
                    Comment = "This is a great service!",
                    FileName = "Test",
                    FileType = "Test",
                },
                new Testimonial
                {
                    Id = 2,
                    FullName = "Jane Smith",
                    Title = "Marketing Manager",
                    Comment = "Highly recommend to everyone.",
                    FileName = "Test2",
                    FileType = "Test2",
                },
                new Testimonial
                {
                    Id = 3,
                    FullName = "Mike Johnson",
                    Title = "Product Owner",
                    Comment = "Exceptional quality and support.",
                    FileName = "Test3",
                    FileType = "Test3",
                }
            );
        }
    }
}
