using SuperLandscapes_Blog.Domain.Common;

namespace SuperLandscapes_Blog.Domain.Entities
{
    public class Picture : AuditableEntity
    {
        public string Url { get; set; } = null!;
        public int Position { get; set; }
        public Guid? BlogId { get; set; }
        public Blog? Blog { get; set; } 

    }
}
