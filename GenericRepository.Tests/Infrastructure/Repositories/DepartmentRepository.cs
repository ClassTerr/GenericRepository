using GenericRepository.Common.Enums;
using GenericRepository.Common.Models.Repositories;
using GenericRepository.Extensions;
using GenericRepository.Repositories.CrudBase;
using GenericRepository.Tests.BLL.Contracts.Models.Department;
using GenericRepository.Tests.BLL.Contracts.Repositories;
using GenericRepository.Tests.Infrastructure.Entities;
using System.Linq.Expressions;

namespace GenericRepository.Tests.Infrastructure.Repositories;

public class DepartmentRepository :
    UnitOfWorkEntityRepositoryBase<Department, int, TestsDbContext, IListItem<Guid>, DepartmentQueryParams>, IDepartmentRepository
{
    public DepartmentRepository(TestsDbContext context, RepositoryCommonDependencies<Department> dependencies)
        : base(context, dependencies) { }

    protected override Func<string, Expression<Func<Department, bool>>> SearchPredicate =>
        query => x => x.Name.Contains(query);

    protected override Func<string, Expression<Func<Department, bool>>> TypeaheadPredicate =>
        query => x => x.Name.StartsWith(query);

    protected override SortingDirectionEnum DefaultSortingDirection => SortingDirectionEnum.Desc;

    protected override Expression<Func<Department, object?>> DefaultSortingSelector { get; } = x => x.CreatedAt;

    protected override IReadOnlyDictionary<string, Expression<Func<Department, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<Department, object?>>>(StringComparer.OrdinalIgnoreCase)
        {
            [nameof(Department.Id)] = x => x.Id,
            [nameof(Department.Name)] = x => x.Name,
            [nameof(Department.CreatedBy)] = x => x.CreatedBy,
            [nameof(Department.CreatedAt)] = x => x.CreatedAt,
            [nameof(Department.LastModifiedBy)] = x => x.LastModifiedBy,
            [nameof(Department.LastModifiedAt)] = x => x.LastModifiedAt
        };

    protected override async Task<IQueryable<Department>> ApplyFilteringAsync(IQueryable<Department> query,
        DepartmentQueryParams? request,
        CancellationToken token = default)
    {
        if (request is null)
            return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        query = query.ApplyStringPropertyFilter(x => x.Name, request.Filters?.Name);

        return query;
    }
}
