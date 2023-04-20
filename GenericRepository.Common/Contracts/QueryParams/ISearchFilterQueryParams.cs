namespace GenericRepository.Common.Contracts.QueryParams;

/// <summary>
/// A request that supports querying.
/// </summary>
public interface ISearchFilterQueryParams
{
    /// <summary>
    /// Text query for full-text search.
    /// </summary>
    public string? Search { get; set; }
}
