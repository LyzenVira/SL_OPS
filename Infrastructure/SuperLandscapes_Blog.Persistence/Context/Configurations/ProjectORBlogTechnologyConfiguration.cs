
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SuperLandscapes_Blog.Domain.Entities;

namespace SuperLandscapes_Blog.Persistence.Context.Configurations
{
    public class ProjectORBlogTechnologyConfiguration : IEntityTypeConfiguration<BlogTechnology>
    {
        public void Configure(EntityTypeBuilder<BlogTechnology> builder)
        {
            builder.ToTable("ProjectORBlogTechnology");
            builder.HasKey(pt => new { pt.BlogId, pt.TechnologyId });


            builder
               .HasOne(x => x.Technology)
               .WithMany(x => x.BlogTechnologies)
               .HasForeignKey(x => x.TechnologyId)
               .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.Blog)
                .WithMany(x => x.BlogTechnologies)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        }
    }
}

