using AutoMapper;
using GenericRepository.Common.Common;
using GenericRepository.Common.Contracts.QueryParams;
using GenericRepository.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GenericRepository.Extensions;

/// <summary>
/// A set of extension methods to work with pagination of <see cref="IQueryable" />.
/// </summary>
public static class QueryablePaginationExtensions
{
    /// <summary>
    /// Performs pagination of <paramref name="source"></paramref>.
    /// </summary>
    /// <param name="source">Data to paginate.</param>
    /// <param name="pageNumber">Desired page number.</param>
    /// <param name="pageSize">Desired page size.</param>
    /// <typeparam name="T">A type of data elements.</typeparam>
    /// <returns><see cref="PagedResult{T}" /> instance with paginated data.</returns>
    /// <param name="token">A cancellation token.</param>
    public static async Task<PagedResult<T>> PaginateAsync<T>(
        this IQueryable<T> source,
        int pageNumber,
        int pageSize,
        CancellationToken token = default)
    {
        var skip = (pageNumber - 1) * pageSize;

        var dataQuery = source;

        // Avoiding Skip/Take warning when ordering is not specified.
        if (skip != 0 || pageSize != int.MaxValue) dataQuery = dataQuery.Skip(skip).Take(pageSize);

        var resultCollection = await dataQuery.ToListAsync(token).ConfigureAwait(false);

        int totalRecordsCount;

        if ((resultCollection.Count > 0 || skip == 0) && resultCollection.Count < pageSize)
            // in this case we can omit additional request for counting database entries
            totalRecordsCount = skip + resultCollection.Count;
        else totalRecordsCount = await source.CountAsync(token).ConfigureAwait(false);

        var result = new PagedResult<T>(pageNumber, pageSize, resultCollection, totalRecordsCount);

        return result;
    }

    /// <summary>
    /// Performs pagination of <paramref name="source"></paramref>.
    /// </summary>
    /// <param name="source">Data to paginate.</param>
    /// <param name="parameters">Desired pagination parameters.</param>
    /// <typeparam name="T">A type of data elements.</typeparam>
    /// <returns><see cref="PagedResult{T}" /> instance with paginated data.</returns>
    /// <param name="token">A cancellation token.</param>
    public static async Task<PagedResult<T>> PaginateAsync<T>(
        this IQueryable<T> source,
        IPagedQueryParams? parameters,
        CancellationToken token = default)
    {
        return await source.PaginateAsync(parameters?.PageNumber ?? IPagedQueryParams.DefaultPageNumber,
            parameters?.PageSize ?? IPagedQueryParams.DefaultPageSize,
            token).ConfigureAwait(false);
    }

    /// <summary>
    /// Performs pagination of <paramref name="source"></paramref> and maps data to <typeparamref name="TResult" /> type.
    /// </summary>
    /// <param name="source">Data to paginate.</param>
    /// <param name="pageNumber">Desired page number.</param>
    /// <param name="pageSize">Desired page size.</param>
    /// <param name="mapper">The automapper used to convert types.</param>
    /// <typeparam name="TSource">A type of data elements.</typeparam>
    /// <typeparam name="TResult">A type to map resulting objects.</typeparam>
    /// <returns><see cref="PagedResult{T}" /> instance with paginated data.</returns>
    /// <param name="token">A cancellation token.</param>
    public static async Task<PagedResult<TResult>> PaginateAsync<TSource, TResult>(
        this IQueryable<TSource> source,
        int pageNumber,
        int pageSize,
        IMapper mapper,
        CancellationToken token = default)
    {
        var originalResult = await source.PaginateAsync(pageNumber, pageSize, token).ConfigureAwait(false);
        var mappedResults = mapper.MapSelfIgnored<List<TResult>>(originalResult.Results);
        return new(originalResult.PageNumber, originalResult.PageSize, mappedResults, originalResult.ItemsCount);
    }

    /// <summary>
    /// Performs pagination of <paramref name="source"></paramref> and maps data to <typeparamref name="TResult" /> type.
    /// </summary>
    /// <param name="source">Data to paginate.</param>
    /// <param name="parameters">Desired pagination parameters.</param>
    /// <param name="mapper">The automapper used to convert types.</param>
    /// <typeparam name="TSource">A type of data elements.</typeparam>
    /// <typeparam name="TResult">A type to map resulting objects.</typeparam>
    /// <returns><see cref="PagedResult{T}" /> instance with paginated data.</returns>
    /// <param name="token">A cancellation token.</param>
    public static async Task<PagedResult<TResult>> PaginateAsync<TSource, TResult>(
        this IQueryable<TSource> source,
        IPagedQueryParams parameters,
        IMapper mapper,
        CancellationToken token = default)
    {
        return await source.PaginateAsync<TSource, TResult>(parameters.PageNumber, parameters.PageSize, mapper, token)
            .ConfigureAwait(false);
    }
}
