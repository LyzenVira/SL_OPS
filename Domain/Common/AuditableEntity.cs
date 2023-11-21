﻿

using Domain.Common.Interfaces;

namespace Domain.Common
{
    public class AuditableEntity : BaseEntity,  IAuditableEntity
    {
        public DateTimeOffset Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public string? LastModifiedBy { get; set; }

    }
}