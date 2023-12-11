
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperLandscapes_Blog.Domain.Entities;

namespace SuperLandscapes_Blog.Persistence.Context.Configurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public  void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating");
            builder.Property(e => e.Mark).HasColumnType("decimal(2,1)");

            builder
                .HasOne(x => x.Blog)
                .WithMany(x => x.Ratings)
                .HasForeignKey(p => p.BlogId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

        }
    }
}
