using GenericRepository.Common.Enums;

namespace GenericRepository.Common.Contracts.QueryParams;

/// <summary>
/// A request that supports ordering.
/// </summary>
public interface ISortedQueryParams
{
    /// <summary>
    /// The field by which the sorting is performed.
    /// </summary>
    public string? SortBy { get; set; }

    /// <summary>
    /// Sorting direction.
    /// </summary>
    public SortingDirectionEnum? SortDirection { get; set; }
}
