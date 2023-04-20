namespace GenericRepository.Common.Models.Filters;

public class StringPropertyFilter
{
    public string? Contains { get; set; }

    public string? ExactMatch { get; set; }

    public string? NotContains { get; set; }

    public string? StartsWith { get; set; }
}
