using GenericRepository.Common.Models.Filters;

namespace GenericRepository.Tests.BLL.Contracts.Models.Company;

public class CompanyFilter
{
    public StringPropertyFilter Name { get; set; } = null!;
}
