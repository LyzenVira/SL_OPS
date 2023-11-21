using Domain.Common;

namespace Domain.Entities
{
    public class Rating : AuditableEntity
    {
        public double Mark { get; set; }
        public Guid BlogId { get; set; } 
        public Blog Blog { get; set; } = null!;
    }
}
