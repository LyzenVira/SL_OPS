
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperLandscapes_Blog.Domain.Entities;

namespace SuperLandscapes_Blog.Persistence.Context.Configurations
{
    public class ParagraphConfiguration : IEntityTypeConfiguration<Paragraph>
    {
        public  void Configure(EntityTypeBuilder<Paragraph> builder)
        {
            builder.ToTable("Paragraph");
            builder.Property(e => e.Title).HasMaxLength(100);

            builder
                .HasOne(e => e.Blog)
                .WithMany(e => e.Paragraphs)
                .HasForeignKey(e => e.BlogId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);
        }
    }
}
