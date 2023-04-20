namespace GenericRepository.Common.Common.AutoAuditing;

/// <summary>
/// Gets or sets value of last entity modification author.
/// </summary>
public interface IAutoAuditModifiedBy
{
    /// <summary>
    /// Gets or sets entity editor id.
    /// </summary>
    Guid? LastModifiedBy { get; set; }
}
