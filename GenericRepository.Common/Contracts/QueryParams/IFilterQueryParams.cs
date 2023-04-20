namespace GenericRepository.Common.Contracts.QueryParams;

public interface IFilterQueryParams<TFilter>
{
    public TFilter? Filters { get; set; }
}
