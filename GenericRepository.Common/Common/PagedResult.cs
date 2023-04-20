using GenericRepository.Common.Contracts.QueryParams;
using System.Text.Json.Serialization;

namespace GenericRepository.Common.Common;

/// <summary>
/// Represents result of pagination request.
/// </summary>
/// <typeparam name="T">Underlying entity type.</typeparam>
public class PagedResult<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}" /> class.
    /// </summary>
    /// <param name="request">The pagination request.</param>
    /// <param name="results">The data to be stored in this instance of <see cref="PagedResult{T}" />.</param>
    /// <param name="itemsCount">Indicates how many items the collection contains.</param>
    public PagedResult(IPagedQueryParams request, List<T> results, int itemsCount)
        : this(request.PageNumber, request.PageSize, results, itemsCount) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}" /> class.
    /// </summary>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The current page size.</param>
    /// <param name="results">The data to be stored in this instance of <see cref="PagedResult{T}" />.</param>
    /// <param name="itemsCount">Indicates how many items the collection contains.</param>
    public PagedResult(int pageNumber, int pageSize, List<T> results, int itemsCount)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Results = results;
        ItemsCount = itemsCount;
        PageCount = (int)Math.Ceiling((double)itemsCount / pageSize);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}" /> class. Used implicitly.
    /// </summary>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageCount">The pages count.</param>
    /// <param name="pageSize">The current page size.</param>
    /// <param name="results">The data to be stored in this instance of <see cref="PagedResult{T}" />.</param>
    /// <param name="itemsCount">Indicates how many items the collection contains.</param>
    [JsonConstructor]
    public PagedResult(int pageNumber, int pageCount, int pageSize, int itemsCount, List<T> results)
    {
        if (pageCount != (int)Math.Ceiling((double)itemsCount / pageSize)) throw new("Inconsistent paged result.");

        PageNumber = pageNumber;
        PageCount = pageCount;
        PageSize = pageSize;
        ItemsCount = itemsCount;
        Results = results;
    }

    /// <summary>
    /// Gets total rows count in the database.
    /// </summary>
    public int ItemsCount { get; }

    /// <summary>
    /// Gets pages count with current <see cref="PageSize" />.
    /// </summary>
    public int PageCount { get; }

    /// <summary>
    /// Gets the current page number.
    /// </summary>
    public int PageNumber { get; }

    /// <summary>
    /// Gets number of elements on page.
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    /// Gets the paginated part of request result.
    /// </summary>
    public List<T> Results { get; }
}
