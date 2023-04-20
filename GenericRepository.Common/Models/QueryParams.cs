using GenericRepository.Common.Contracts.QueryParams;
using GenericRepository.Common.Enums;
using System.Text.Json.Serialization;

namespace GenericRepository.Common.Models;

public class QueryParams<TPrimaryKey> : IQueryParams<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    private int _pageNumber = IPagedQueryParams.DefaultPageNumber;
    private int _pageSize = IPagedQueryParams.DefaultPageSize;

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value < 1
            ? IPagedQueryParams.DefaultPageNumber
            : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value < 1
            ? IPagedQueryParams.DefaultPageSize
            : value;
    }

    public string? SortBy { get; set; }

    public SortingDirectionEnum? SortDirection { get; set; }

    public string? Search { get; set; }

    public string? Typeahead { get; set; }

    public TPrimaryKey[]? Ids { get; set; }
}

public class QueryParams<TPrimaryKey, TFilter> : QueryParams<TPrimaryKey>, IQueryParams<TPrimaryKey, TFilter>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    [JsonIgnore] public TFilter? Filters { get; set; }
}
