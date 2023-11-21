using Domain.Common;

namespace Domain.Entities
{
    public class SVG : AuditableEntity
    {
        public string Url { get; set; } = null!;
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; } = null!;
     }
}
