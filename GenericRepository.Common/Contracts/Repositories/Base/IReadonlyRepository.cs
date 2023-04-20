using GenericRepository.Common.Common;
using GenericRepository.Common.Models.Repositories;

namespace GenericRepository.Common.Contracts.Repositories.Base;

public interface IReadonlyRepository<TEntity, TPrimaryKey, TAutocomplete, in TQueryParams>
    where TEntity : class, IEntity<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    /// Returns an entity <typeparamref name="TEntity" /> with id equal to <paramref name="id" /> if it exists and null otherwise.
    /// </summary>
    /// <param name="id">The id of requested entity.</param>
    /// <param name="options">An options for the query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Entity <typeparamref name="TEntity" /> if it exists and null otherwise.</returns>
    Task<TEntity?> GetByIdAsync(TPrimaryKey id, RepositoryQueryOptions? options = null, CancellationToken token = default);

    /// <summary>
    /// Checks if an entity with provided id exists.
    /// </summary>
    /// <param name="id">The entity id.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Boolean value indicating whether entity exists or not.</returns>
    Task<bool> ExistsAsync(TPrimaryKey id, CancellationToken token = default);

    /// <summary>
    /// Checks if an entity with provided id exists. Throws exception if it's not found.
    /// </summary>
    /// <param name="id">The entity id to check.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Boolean value indicating whether entity exists or not.</returns>
    Task MustExistsAsync(TPrimaryKey id, CancellationToken token = default);

    /// <summary>
    /// The same as <see cref="GetAsync" /> but returns lightweight model used for search.
    /// </summary>
    /// <param name="queryRequestType"></param>
    /// <param name="token">A cancellation token.</param>
    /// <returns><see cref="PagedResult{T}" /> with data populated.</returns>
    Task<PagedResult<TAutocomplete>> AutocompleteAsync(TQueryParams? queryRequestType = default,
        CancellationToken token = default);

    /// <summary>
    /// Returns all entities.
    /// </summary>
    /// <param name="options">An options for the query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>List with all entities.</returns>
    /// <remarks>Use carefully as it pulls all data from database table.</remarks>
    Task<IReadOnlyList<TEntity>> GetAllAsync(RepositoryQueryOptions? options = null, CancellationToken token = default);

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
}
