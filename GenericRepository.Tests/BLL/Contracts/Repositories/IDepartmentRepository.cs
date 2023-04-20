using GenericRepository.Common.Contracts.Repositories.Base;
using GenericRepository.Common.Models.Repositories;
using GenericRepository.Tests.BLL.Contracts.Models.Department;
using GenericRepository.Tests.Infrastructure.Entities;

namespace GenericRepository.Tests.BLL.Contracts.Repositories;

public interface IDepartmentRepository : IEntityRepository<Department, int, IListItem<Guid>, DepartmentQueryParams> { }
