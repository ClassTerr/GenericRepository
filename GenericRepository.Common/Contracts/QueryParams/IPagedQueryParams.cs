namespace GenericRepository.Common.Contracts.QueryParams;

/// <summary>
/// A request that supports pagination.
/// </summary>
public interface IPagedQueryParams
{
    /// <summary>
    /// Default page size for this application.
    /// </summary>
    public const int DefaultPageSize = 30;

    /// <summary>
    /// Default page number. Should be 1.
    /// </summary>
    public const int DefaultPageNumber = 1;

    /// <summary>
    /// The page number. Starts from 1.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// The number of records returned per query.
    /// </summary>
    public int PageSize { get; set; }
}
