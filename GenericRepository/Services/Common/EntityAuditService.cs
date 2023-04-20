using GenericRepository.Common.Common;
using GenericRepository.Common.Common.AutoAuditing;
using GenericRepository.Common.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Services.Common;

/// <inheritdoc />
public class EntityAuditService : IEntityAuditService
{
    private readonly IDateTime _dateTime;

    /// <summary>
    /// Initializes a new instance of the <see cref="EntityAuditService" /> class.
    /// </summary>
    /// <param name="dateTime">The DateTime service.</param>
    public EntityAuditService(IDateTime dateTime)
    {
        _dateTime = dateTime;
    }

    /// <inheritdoc />
    public void ApplyAuditRules(DbContext context, IUser? user = null)
    {
        var now = _dateTime.NowUtc;

        foreach (var entry in context.ChangeTracker.Entries().Where(x => x.State is EntityState.Modified or EntityState.Added))
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity is IAutoAuditCreatedAt autoAuditCreatedAt) autoAuditCreatedAt.CreatedAt = now;

                if (entry.Entity is IAutoAuditCreatedBy autoAuditCreatedBy) autoAuditCreatedBy.CreatedBy = user?.UserId ?? Guid.Empty;
            }

            if (entry.Entity is IAutoAuditModifiedAt autoAuditUpdatedAt &&
                (entry.State == EntityState.Modified || entry.Entity is not IAutoAuditCreatedAt))
                autoAuditUpdatedAt.LastModifiedAt = now;

            if (entry.Entity is IAutoAuditModifiedBy autoAuditUpdatedBy &&
                (entry.State == EntityState.Modified || entry.Entity is not IAutoAuditCreatedBy))
                autoAuditUpdatedBy.LastModifiedBy = user?.UserId;
        }
    }
}
