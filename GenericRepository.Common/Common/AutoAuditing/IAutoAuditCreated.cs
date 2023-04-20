namespace GenericRepository.Common.Common.AutoAuditing;

/// <summary>
/// Indicates that this entity should store data about the author and when it was created.
/// </summary>
public interface IAutoAuditCreated : IAutoAuditCreatedBy,
    IAutoAuditCreatedAt { }
