using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperLandscapes_Blog.Domain.Entities;

namespace SuperLandscapes_Blog.Persistence.Context.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.Property(e => e.Fullname).HasMaxLength(50);
            builder.Property(e => e.Employment).HasMaxLength(50);

            builder
                .HasMany(x => x.Blogs)
                .WithOne(x => x.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

        }
    }
}
