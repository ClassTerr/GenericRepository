using GenericRepository.Common.Exceptions;
using System.Diagnostics.Contracts;

namespace GenericRepository.Common.Contracts.ExceptionFactories;

/// <summary>
/// Used to produce exceptions.
/// </summary>
public interface IRepositoryExceptionFactory<TEntity>
{
    [Pure]
    NotFoundDomainException NoRecordsFound();

    [Pure]
    NotFoundDomainException EntityNotFound<TPrimaryKey>(TPrimaryKey? id);

    NotImplementedDomainException NotImplemented(string? message = null);
}
