using GenericRepository.Common.Models.Filters;

namespace GenericRepository.Tests.BLL.Contracts.Models.Department;

public class DepartmentFilter
{
    public StringPropertyFilter Name { get; set; } = null!;
}
