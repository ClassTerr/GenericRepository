using GenericRepository.Common.Enums;
using GenericRepository.Common.Models.Repositories;
using GenericRepository.Extensions;
using GenericRepository.Repositories.CrudBase;
using GenericRepository.Tests.BLL.Contracts.Models.Company;
using GenericRepository.Tests.BLL.Contracts.Repositories;
using GenericRepository.Tests.Infrastructure.Entities;
using System.Linq.Expressions;

namespace GenericRepository.Tests.Infrastructure.Repositories;

public class CompanyRepository : UnitOfWorkEntityRepositoryBase<Company, int, TestsDbContext, IListItem<Guid>, CompanyQueryParams>,
    ICompanyRepository
{
    public CompanyRepository(TestsDbContext context, RepositoryCommonDependencies<Company> dependencies)
        : base(context, dependencies) { }

    protected override Func<string, Expression<Func<Company, bool>>> SearchPredicate =>
        query => x => x.Name.Contains(query);

    protected override Func<string, Expression<Func<Company, bool>>> TypeaheadPredicate =>
        query => x => x.Name.StartsWith(query);

    protected override SortingDirectionEnum DefaultSortingDirection => SortingDirectionEnum.Desc;

    protected override Expression<Func<Company, object?>> DefaultSortingSelector { get; } = x => x.CreatedAt;

    protected override IReadOnlyDictionary<string, Expression<Func<Company, object?>>> SortingConfiguration { get; } =
        new Dictionary<string, Expression<Func<Company, object?>>>(StringComparer.OrdinalIgnoreCase)
        {
            [nameof(Company.Id)] = x => x.Id,
            [nameof(Company.Name)] = x => x.Name,
            [nameof(Company.CreatedBy)] = x => x.CreatedBy,
            [nameof(Company.CreatedAt)] = x => x.CreatedAt,
            [nameof(Company.LastModifiedBy)] = x => x.LastModifiedBy,
            [nameof(Company.LastModifiedAt)] = x => x.LastModifiedAt
        };

    protected override async Task<IQueryable<Company>> ApplyFilteringAsync(IQueryable<Company> query,
        CompanyQueryParams? request,
        CancellationToken token = default)
    {
        if (request is null)
            return query;

        query = await base.ApplyFilteringAsync(query, request, token);

        query = query.ApplyStringPropertyFilter(x => x.Name, request.Filters?.Name);

        return query;
    }
}
