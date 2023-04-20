namespace GenericRepository.Common.Common.AutoAuditing;

/// <summary>
/// Indicates that this entity should store data author/latest editor and creation/latest modification timestamps.
/// </summary>
public interface IAutoAudit : IAutoAuditCreated, IAutoAuditModified { }
