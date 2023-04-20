namespace GenericRepository.Common.Common.AutoAuditing;

/// <summary>
/// Indicates that this entity should store data about when it was created.
/// </summary>
public interface IAutoAuditCreatedAt
{
    /// <summary>
    /// Gets or sets value of entity creation timestamp.
    /// </summary>
    DateTime CreatedAt { get; set; }
}
