using Domain.Common;

namespace Domain.Entities
{
    public class Technology : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<BlogTechnology> BlogTechnologies { get; set; } = null!;
    }
}
