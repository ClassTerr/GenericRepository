namespace GenericRepository.Common.Common.AutoAuditing;

/// <summary>
/// Indicates that this entity should store data about it's author.
/// </summary>
public interface IAutoAuditCreatedBy
{
    /// <summary>
    /// Gets or sets entity author id.
    /// </summary>
    Guid? CreatedBy { get; set; }
}
