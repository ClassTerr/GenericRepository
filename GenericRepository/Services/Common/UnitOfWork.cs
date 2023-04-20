using GenericRepository.Common.Contracts;
using GenericRepository.Common.Contracts.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Services.Common;

/// <inheritdoc />
public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
{
    private readonly TContext _context;

    private readonly ICurrentUserService _currentUserService;
    private readonly IEntityAuditService _entityAuditService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork{TContext}" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="entityAuditService">Service for handling automatic entity auditing.</param>
    /// <param name="currentUserService">A service for retrieving information about user who performs operation.</param>
    public UnitOfWork(TContext context, IEntityAuditService entityAuditService, ICurrentUserService currentUserService)
    {
        _context = context;
        _entityAuditService = entityAuditService;
        _currentUserService = currentUserService;
    }

    /// <inheritdoc />
    public async Task SaveChangesAsync(CancellationToken token = default)
    {
        var user = await _currentUserService.GetUserAsync(token);
        _entityAuditService.ApplyAuditRules(_context, user);
        await _context.SaveChangesAsync(token);
        DetachAll();
    }

    /// <inheritdoc />
    public void Rollback()
    {
        DetachAll();
    }

    private void DetachAll()
    {
        _context.ChangeTracker.Clear();
    }
}
