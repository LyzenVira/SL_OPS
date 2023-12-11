
namespace SuperLandscapes_Blog.Domain.Entities
{
    public class BlogTechnology
    {
        public Technology Technology { get; set; } = null!;
        public Guid TechnologyId { get; set; }
        public Blog? Blog { get; set; }
        public Guid? BlogId { get; set; }
    }
}
