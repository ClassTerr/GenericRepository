using GenericRepository.Common.Common;
using GenericRepository.Common.Contracts.QueryParams;
using GenericRepository.Common.Models.Repositories;
using GenericRepository.Common.Models.Repositories.Result;

namespace GenericRepository.Common.Contracts.Repositories.Base;

/// <summary>
/// Contracts for repositories for <see cref="IEntity" /> type.
/// </summary>
/// <typeparam name="TEntity">Type of the entity.</typeparam>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TAutocomplete">The type used for autocomplete.</typeparam>
/// <typeparam name="TQueryParams">A model used to specify custom filters or other criteria for querying.</typeparam>
public interface IEntityRepository<TEntity, TPrimaryKey, TAutocomplete, in TQueryParams>
    : IQueryableRepository<TEntity, TQueryParams>
    where TEntity : class, IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TQueryParams : IQueryParams<TPrimaryKey>
{
    /// <summary>
    /// Creates an entity <paramref name="entity" /> in the change tracker.
    /// </summary>
    /// <param name="entity">An entity to be created.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    new Task<CreateEntityResult<TEntity, TPrimaryKey>> CreateAsync(TEntity entity, CancellationToken token = default);

    /// <summary>
    /// Returns an entity <typeparamref name="TEntity" /> with id equal to <paramref name="id" />.
    /// </summary>
    /// <param name="id">The id of requested entity.</param>
    /// <param name="options">An options for the query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Entity <typeparamref name="TEntity" /> if it exists and null otherwise.</returns>
    Task<TEntity?> GetByIdAsync(TPrimaryKey id, RepositoryQueryOptions? options = null, CancellationToken token = default);

    /// <summary>
    /// Returns an entity <typeparamref name="TEntity" /> with id equal to <paramref name="id" /> projected to type <typeparamref name="T" />.
    /// </summary>
    /// <param name="id">The id of requested entity.</param>
    /// <param name="options">An options for the query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Entity <typeparamref name="TEntity" /> if it exists and null otherwise.</returns>
    Task<T?> GetByIdProjectedAsync<T>(TPrimaryKey id, RepositoryQueryOptions? options = null, CancellationToken token = default);

    /// <summary>
    /// Checks if an entity with provided id exists.
    /// </summary>
    /// <param name="id">The entity id.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Boolean value indicating whether entity exists or not.</returns>
    Task<bool> ExistsAsync(TPrimaryKey id, CancellationToken token = default);

    /// <summary>
    /// Checks if an entities with provided ids exists.
    /// </summary>
    /// <param name="ids">The collection of ids to check for existence.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A hashset with ids that are found.</returns>
    Task<List<TPrimaryKey>> ExistsManyAsync(ICollection<TPrimaryKey> ids, CancellationToken token = default);

    /// <summary>
    /// Checks if an entity with provided id exists. Throws exception if it's not found.
    /// </summary>
    /// <param name="id">The entity id to check.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Boolean value indicating whether entity exists or not.</returns>
    Task MustExistsAsync(TPrimaryKey id, CancellationToken token = default);

    /// <summary>
    /// The same as <see cref="IQueryableRepository{TEntity,TQueryParams}.GetAsync" /> but returns lightweight model used for search.
    /// </summary>
    /// <param name="queryRequestType"></param>
    /// <param name="token">A cancellation token.</param>
    /// <returns><see cref="PagedResult{T}" /> with data populated.</returns>
    Task<PagedResult<TAutocomplete>> AutocompleteAsync(TQueryParams? queryRequestType = default,
        CancellationToken token = default);
}
