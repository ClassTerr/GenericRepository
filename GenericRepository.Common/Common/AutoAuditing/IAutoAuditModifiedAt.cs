namespace GenericRepository.Common.Common.AutoAuditing;

/// <summary>
/// Gets or sets last entity modification timestamp.
/// </summary>
public interface IAutoAuditModifiedAt
{
    /// <summary>
    /// Gets or sets last entity modification timestamp.
    /// </summary>
    DateTime? LastModifiedAt { get; set; }
}
