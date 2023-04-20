namespace GenericRepository.Common.Contracts.QueryParams;

/// <summary>
/// A request that supports pagination.
/// </summary>
public interface IIdsFilterQueryParams<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    /// The list of ids to filter by.
    /// </summary>
    TPrimaryKey[]? Ids { get; set; }
}
