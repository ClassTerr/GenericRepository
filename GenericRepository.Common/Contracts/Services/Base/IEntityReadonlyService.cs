using GenericRepository.Common.Common;

namespace GenericRepository.Common.Contracts.Services.Base;

/// <summary>
/// A service capable to perform read operations.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TListResponse">A model that returned from methods returning a list of entities.</typeparam>
/// <typeparam name="TDetailedResponse">A model that returned from methods returning a single, more detailed entity.</typeparam>
/// <typeparam name="TAutocomplete">The type used for autocomplete.</typeparam>
/// <typeparam name="TQueryParams">A model used to specify custom filters or other criteria for querying.</typeparam>
public interface IEntityReadonlyService<TPrimaryKey, TListResponse, TDetailedResponse, TAutocomplete, in TQueryParams>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    /// Represents a data request operation.
    /// </summary>
    /// <param name="queryParams">A custom parameters for querying.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns><see cref="PagedResult{T}" /> with data populated.</returns>
    Task<PagedResult<TListResponse>> GetAsync(TQueryParams? queryParams = default, CancellationToken token = default);

    /// <summary>
    /// Returns an entity with id equal to <paramref name="id" /> if it exists and null otherwise.
    /// Id parameters for composite primary key have to be in the same order as defined within fluent API map.
    /// </summary>
    /// <param name="id">The id of requested entity.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Entity if it exists and null otherwise.</returns>
    Task<TDetailedResponse?> GetByIdAsync(TPrimaryKey id, CancellationToken token = default)
    {
        return GetByIdAsync(id, false, token);
    }

    /// <summary>
    /// If found returns an entity with id equal to <paramref name="id" /> parameter and
    /// throws an exception otherwise.
    /// </summary>
    /// <param name="id">The id of requested entity.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Entity if it exists and null otherwise.</returns>
    Task<TDetailedResponse?> GetRequiredByIdAsync(TPrimaryKey id, CancellationToken token = default)
    {
        return GetByIdAsync(id, true, token);
    }

    /// <summary>
    /// Returns an entity with id equal to <paramref name="id" /> if it exists and null otherwise.
    /// </summary>
    /// <param name="id">The id of requested entity.</param>
    /// <param name="isRequired">If true - method throws an error if an entity was not found by specified id.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>Entity if it exists and null otherwise.</returns>
    Task<TDetailedResponse?> GetByIdAsync(TPrimaryKey id, bool isRequired, CancellationToken token = default);

    /// <summary>
    /// Checks if an entity with provided id exists.
    /// Id parameters for composite primary key have to be in the same order as defined within fluent API map.
    /// </summary>
    /// <param name="id">The entity id to check.</param>
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
    /// <param name="queryParams">A custom parameters for querying.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns><see cref="PagedResult{T}" /> with data populated.</returns>
    Task<PagedResult<TAutocomplete>> AutocompleteAsync(TQueryParams? queryParams = default, CancellationToken token = default);
}
