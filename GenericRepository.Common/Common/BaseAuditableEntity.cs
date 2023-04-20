using GenericRepository.Common.Common.AutoAuditing;

namespace GenericRepository.Common.Common;

public abstract class BaseAuditableEntity<TPrimaryKey>
    : BaseEntity<TPrimaryKey>, IAutoAudit where TPrimaryKey : IEquatable<TPrimaryKey>
{
    public virtual Guid? CreatedBy { get; set; }

    public virtual DateTime CreatedAt { get; set; }

    public virtual Guid? LastModifiedBy { get; set; }

    public virtual DateTime? LastModifiedAt { get; set; }
}
