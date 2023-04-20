using GenericRepository.Common.Common.AutoAuditing;
using GenericRepository.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Services.Common;

/// <summary>
/// Handles automatic entity auditing. Affects entities marked with interfaces:
/// <see cref="IAutoAudit" />, <see cref="IAutoAuditCreated" />, <see cref="IAutoAuditCreatedAt" />, <see cref="IAutoAuditCreatedBy" />,
/// <see cref="IAutoAuditModified" />, <see cref="IAutoAuditModifiedAt" />, <see cref="IAutoAuditModifiedBy" />.
/// </summary>
public interface IEntityAuditService
{
    /// <summary>
    /// Applies rules to entities tracked in the <paramref name="context" /> parameter.
    /// </summary>
    /// <param name="context">The context with tracked entities.</param>
    /// <param name="user">A user who performs this operation.</param>
    void ApplyAuditRules(DbContext context, IUser? user = null);
}
