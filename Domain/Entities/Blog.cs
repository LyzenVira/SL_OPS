using Domain.Common;

namespace Domain.Entities
{
    public class Blog : AuditableEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Viewers { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;
        public ICollection<Paragraph> Paragraphs { get; set; } = null!;
        public ICollection<Picture> Pictures { get; set; } = null!;
        public ICollection<Rating> Ratings { get; set; } = null!;
        public ICollection<BlogTechnology> BlogTechnologies { get; set; } = null!;
        public SVG SVG { get; set; } = null!;

    }
}
