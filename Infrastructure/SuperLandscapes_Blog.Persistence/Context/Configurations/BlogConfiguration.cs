using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperLandscapes_Blog.Domain.Entities;

namespace SuperLandscapes_Blog.Persistence.Context.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {

            builder.ToTable("Blog");
            builder.Property(e => e.Title).HasMaxLength(30);

            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
            builder
               .HasMany(x => x.Ratings)
               .WithOne(x => x. Blog)
               .HasForeignKey(x => x.BlogId)
               .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
            builder
               .HasMany(x => x.BlogTechnologies)
               .WithOne(x => x.Blog)
               .HasForeignKey(x => x.BlogId)
               .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

        }
    }
}
