namespace GenericRepository.Common.Common.AutoAuditing;

/// <summary>
/// Indicates that this entity should store data about latest modification author and timestamp.
/// </summary>
public interface IAutoAuditModified : IAutoAuditModifiedBy,
    IAutoAuditModifiedAt { }
