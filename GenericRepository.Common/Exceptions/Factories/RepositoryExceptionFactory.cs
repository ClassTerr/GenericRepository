using GenericRepository.Common.Contracts.ExceptionFactories;
using System.Diagnostics.Contracts;

namespace GenericRepository.Common.Exceptions.Factories;

/// <summary>
/// Used to produce exceptions.
/// </summary>
public class RepositoryExceptionFactory<TEntity> : IRepositoryExceptionFactory<TEntity>
{
    public NotFoundDomainException NoRecordsFound()
    {
        throw new NotFoundDomainException($"No {nameof(TEntity)} is not found.");
    }

    public NotFoundDomainException EntityNotFound<TPrimaryKey>(TPrimaryKey? id)
    {
        throw new NotFoundDomainException($"{nameof(TEntity)} with id {id} is not found.");
    }

    /// <inheritdoc />
    [Pure]
    public NotImplementedDomainException NotImplemented(string? message = null)
    {
        return new(message, "Not implemented", false);
    }
}
