
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperLandscapes_Blog.Domain.Entities;

namespace SuperLandscapes_Blog.Persistence.Context.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public  void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Picture");
            builder.Property(e => e.Url).HasColumnType("varbinary(max)");

            builder
                .HasOne(x => x.Blog)
                .WithMany(x => x.Pictures)
                .HasForeignKey(p => p.BlogId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

        }
    }
}
