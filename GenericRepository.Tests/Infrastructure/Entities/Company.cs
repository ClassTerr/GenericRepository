using GenericRepository.Common.Common;

namespace GenericRepository.Tests.Infrastructure.Entities;

public class Company : BaseAuditableEntity<int>
{
    public string Name { get; set; } = default!;

    public string FoundedLocation { get; set; } = default!;

    public string Industry { get; set; } = default!;

    public List<Department> Departments { get; set; } = default!;
}
