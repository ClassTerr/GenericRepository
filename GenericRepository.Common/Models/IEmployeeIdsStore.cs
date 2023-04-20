namespace GenericRepository.Common.Models;

public interface IEmployeeIdsStore
{
    public Guid[]? EmployeeIds { get; set; }
}
