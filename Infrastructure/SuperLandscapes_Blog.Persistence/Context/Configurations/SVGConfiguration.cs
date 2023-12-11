
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperLandscapes_Blog.Domain.Entities;

namespace SuperLandscapes_Blog.Persistence.Context.Configurations
{
    public class SVGConfiguration : IEntityTypeConfiguration<SVG>
    {
        public  void Configure(EntityTypeBuilder<SVG> builder)
        {
            builder.ToTable("SVG");
            builder.Property(e => e.Url).HasColumnType("varbinary(max)");

            builder
                .HasOne(x => x.Blog)
                .WithOne(x => x.SVG)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

        }
    }
}
