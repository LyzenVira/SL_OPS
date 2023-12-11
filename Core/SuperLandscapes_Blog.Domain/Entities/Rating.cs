using SuperLandscapes_Blog.Domain.Common;

namespace SuperLandscapes_Blog.Domain.Entities
{
    public class Rating : AuditableEntity
    {
        public double Mark { get; set; }
        public Guid BlogId { get; set; } 
        public Blog Blog { get; set; } = null!;
    }
}
