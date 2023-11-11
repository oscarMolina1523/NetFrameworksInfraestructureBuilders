using System;

namespace Domain.Endpoint.Entities
{
    public interface IHaveCreationData
    {
        DateTime CreatedAt { get; set; }
        Guid CreatedBy { get; set; }
    }

    public interface IHaveUpdateData
    {
        DateTime? UpdatedAt { get; set; }
        Guid? UpdatedBy { get; set; }
    }

    public interface IAuditableEntity : IHaveCreationData, IHaveUpdateData { }

    public class AuditableEntity : BaseEntity, IAuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; } // Owner Unique Id
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
