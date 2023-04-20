using GenericRepository.Common.Common;
using GenericRepository.Common.Models.Repositories;

namespace GenericRepository.Common.Contracts.Repositories.Base;

/// <summary>
/// An interface for repositories.
/// </summary>
/// <typeparam name="TEntity">The type of entities to work with.</typeparam>
/// <typeparam name="TQueryParams">A model used to specify custom filters or other criteria for querying.</typeparam>
public interface IQueryableRepository<TEntity, in TQueryParams> : IRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    /// Represents a data request operation.
    /// </summary>
    /// <param name="request">A repository request to be executed.</param>
    /// <param name="options">An options for the query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns><see cref="PagedResult{T}" /> with data populated.</returns>
    Task<PagedResult<TEntity>> GetAsync(TQueryParams request,
        RepositoryQueryOptions? options = null,
        CancellationToken token = default);

    /// <summary>
    /// Represents a data request operation. Projects data to specified type.
    /// </summary>
    /// <param name="request">A repository request to be executed.</param>
    /// <param name="options">An options for the query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <typeparam name="T">The type to which data should be projected.</typeparam>
    /// <returns>True of false.</returns>
    Task<PagedResult<T>> GetProjectedAsync<T>(TQueryParams? request,
        RepositoryQueryOptions? options = null,
        CancellationToken token = default);

    /// <summary>
    /// Checks if at least one record corresponds to the query.
    /// </summary>
    /// <param name="request">A repository request to be executed.</param>
    /// <param name="options">An options for the query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns></returns>
    Task<bool> AnyAsync(TQueryParams? request,
        RepositoryQueryOptions? options = null,
        CancellationToken token = default);

    /// <summary>
    /// Returns number of records corresponding to the query.
    /// </summary>
    /// <param name="request">A repository request to be executed.</param>
    /// <param name="options">An options for the query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns></returns>
    Task<int> CountAsync(TQueryParams? request,
        RepositoryQueryOptions? options = null,
        CancellationToken token = default);
}
