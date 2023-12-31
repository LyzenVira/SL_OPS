﻿using SuperLandscapes_Blog.Domain.Common;

namespace SuperLandscapes_Blog.Domain.Entities
{
    public class Paragraph : AuditableEntity
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Position { get; set; }
        public Guid? BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
