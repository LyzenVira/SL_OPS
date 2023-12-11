
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperLandscapes_Blog.Domain.Entities;

namespace SuperLandscapes_Blog.Persistence.Context.Configurations
{
    public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public  void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.ToTable("Technology");
            builder.Property(x => x.Name).HasMaxLength(30);

            builder
                .HasMany(x => x.BlogTechnologies)
                .WithOne(x => x.Technology)
                .HasForeignKey(x=>x.TechnologyId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);
        }
    }
}
