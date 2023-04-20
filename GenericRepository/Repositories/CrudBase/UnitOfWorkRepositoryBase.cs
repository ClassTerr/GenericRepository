using AutoMapper;
using AutoMapper.QueryableExtensions;
using GenericRepository.Common.Common;
using GenericRepository.Common.Contracts.ExceptionFactories;
using GenericRepository.Common.Contracts.QueryParams;
using GenericRepository.Common.Contracts.Repositories.Base;
using GenericRepository.Common.Enums;
using GenericRepository.Common.Exceptions;
using GenericRepository.Common.Extensions;
using GenericRepository.Common.Models.Repositories;
using GenericRepository.Extensions;
using GenericRepository.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Linq.Expressions;
using DynamicQueryableExtensions = System.Linq.Dynamic.Core.DynamicQueryableExtensions;

namespace GenericRepository.Repositories.CrudBase;

/// <summary>
/// Base class for generic repository.
/// </summary>
/// <typeparam name="TEntity">The type of data to work with.</typeparam>
/// <typeparam name="TContext">The context type.</typeparam>
/// <typeparam name="TQueryParams">A model used to specify custom filters or other criteria for querying.</typeparam>
public abstract class UnitOfWorkRepositoryBase<TEntity, TContext, TQueryParams> : IQueryableRepository<TEntity, TQueryParams>
    where TContext : DbContext where TEntity : class where TQueryParams : IQueryParams
{
    private IReadOnlyList<IProperty>? _keyProperties;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWorkRepositoryBase{TEntity,TContext,TQueryParams}" /> class.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="dependencies">The common dependencies.</param>
    protected UnitOfWorkRepositoryBase(TContext context, RepositoryCommonDependencies<TEntity> dependencies)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));

        (Mapper, LoggerFactory, ExceptionFactory) = dependencies;
        Logger = dependencies.LoggerFactory.CreateLogger(GetType());

        Set = context.Set<TEntity>();
    }

    /// <summary>
    /// Gets default properties to include in all queries.
    /// </summary>
    protected virtual IReadOnlyList<Expression<Func<TEntity, object>>> CommonIncludes => null!;

    /// <summary>
    /// Gets the DbContext.
    /// </summary>
    protected TContext Context { get; }

    /// <summary>
    /// Gets default order direction for sorting.
    /// </summary>
    protected virtual SortingDirectionEnum DefaultSortingDirection => SortingDirectionEnum.Asc;

    /// <summary>
    /// Gets default parameter for sorting. This parameter have to be overriden in order to get predictable pagination behaviour.
    /// </summary>
    protected abstract Expression<Func<TEntity, object?>> DefaultSortingSelector { get; }

    /// <summary>
    /// Gets properties to include in queries of one single entity.
    /// </summary>
    protected virtual IReadOnlyList<Expression<Func<TEntity, object>>> DetailedViewIncludes => null!;

    /// <summary>
    /// Gets the exception factory.
    /// </summary>
    protected virtual IRepositoryExceptionFactory<TEntity> ExceptionFactory { get; }

    /// <summary>
    /// Gets a key properties of <typeparamref name="TEntity" />.
    /// </summary>
    protected IReadOnlyList<IProperty> KeyProperties =>
        _keyProperties ??= Context.GetPrimaryKeyProperties<TEntity>() ?? throw new NotSupportedException("Can't handle keyless entities.");

    /// <summary>
    /// Gets the logger.
    /// </summary>
    protected virtual ILogger Logger { get; }

    /// <summary>
    /// Gets the logger factory.
    /// </summary>
    protected virtual ILoggerFactory LoggerFactory { get; }

    /// <summary>
    /// Gets the automapper used to convert types.
    /// </summary>
    protected virtual IMapper Mapper { get; }

    /// <summary>
    /// Gets owned properties of <typeparamref name="TEntity" />.
    /// Owned property is a property which can't be separated from parent entity. Considered as part of parent entity.
    /// </summary>
    protected virtual IReadOnlyList<Expression<Func<TEntity, object>>>? OwnedProperties => null;

    /// <summary>
    /// Gets predicate that used for records filtering with <see cref="IQueryParams" />.
    /// </summary>
    protected virtual Func<string, Expression<Func<TEntity, bool>>>? SearchPredicate => null;

    /// <summary>
    /// Gets a <see cref="DbSet{TEntity}" /> object of <typeparamref name="TContext" />.
    /// </summary>
    protected DbSet<TEntity> Set { get; }

    /// <summary>
    /// Gets a dictionary with allowed sorting parameters. The key is parameter name, the value is property selector.
    /// </summary>
    protected virtual IReadOnlyDictionary<string, Expression<Func<TEntity, object?>>>? SortingConfiguration => null;

    /// <summary>
    /// Gets predicate that used for records filtering with <see cref="IQueryParams" />.
    /// </summary>
    protected virtual Func<string, Expression<Func<TEntity, bool>>>? TypeaheadPredicate => null;

    /// <inheritdoc />
    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(RepositoryQueryOptions? options = null, CancellationToken token = default)
    {
        var baseQuery = await GetBaseQueryAsync(options, token);
        var result = await baseQuery.ToListAsync(token);

        if (options?.Required == true) EnsureAny(result);

        return result;
    }

    /// <inheritdoc />
    public virtual async Task<PagedResult<TEntity>> GetAsync(TQueryParams request, RepositoryQueryOptions? options = null,
        CancellationToken token = default)
    {
        options = (options ?? RepositoryQueryOptions.DetailedView) with
        {
            LoadDetailedViewIncludes = options?.LoadDetailedViewIncludes ?? true
        };

        var query = await GetBaseQueryAsync(options, token);
        var result = await GetDataByRepositoryRequestAsync(query, request, token);

        if (options.Required) EnsureAny(result.Results);

        return result;
    }

    /// <inheritdoc />
    public virtual async Task<bool> AnyAsync(TQueryParams? request, RepositoryQueryOptions? options = null,
        CancellationToken token = default)
    {
        options = (options ?? RepositoryQueryOptions.BareView) with
        {
            LoadDetailedViewIncludes = false,
            LoadCommonIncludes = false,
            LoadOwnedProperties = false
        };

        var query = await GetBaseQueryAsync(options, token);
        query = await ApplyFilteringAsync(query, request, token);
        var any = await query.AnyAsync(token);

        if (options.Required && !any) throw ExceptionFactory.NoRecordsFound();

        return any;
    }

    /// <inheritdoc />
    public virtual async Task<int> CountAsync(TQueryParams? request, RepositoryQueryOptions? options = null,
        CancellationToken token = default)
    {
        options = (options ?? RepositoryQueryOptions.BareView) with
        {
            LoadDetailedViewIncludes = false,
            LoadCommonIncludes = false,
            LoadOwnedProperties = false
        };

        var query = await GetBaseQueryAsync(options, token);
        query = await ApplyFilteringAsync(query, request, token);
        var count = await query.CountAsync(token);

        if (options.Required && count <= 0) throw ExceptionFactory.NoRecordsFound();

        return count;
    }

    /// <inheritdoc />
    public virtual async Task<PagedResult<T>> GetProjectedAsync<T>(TQueryParams? request, RepositoryQueryOptions? options = null,
        CancellationToken token = default)
    {
        options = (options ?? RepositoryQueryOptions.BareView) with
        {
            LoadDetailedViewIncludes = false,
            LoadCommonIncludes = false,
            LoadOwnedProperties = false
        };

        var query = await GetBaseQueryAsync(options, token);

        SearchGuard(request);
        TypeaheadGuard(request);
        SortGuard(request);

        query = await ApplyRepositoryRequestAsync(query, request, token);

        var projectedQuery = await HandleProjectionAsync<T>(query);

        var result = await ApplyPagination(projectedQuery, request, token);

        if (options.Required) EnsureAny(result.Results);

        return result;
    }

    /// <inheritdoc />
    public virtual Task<TEntity> CreateAsync(TEntity entity, CancellationToken token = default)
    {
        // Shallow creation operation. Navigation properties will be handled by next steps.
        var entry = Context.Attach(entity);
        entry.State = EntityState.Added;
        entry.CurrentValues.SetValues(entity);

        // Ensure the data are not contradictory
        Context.ChangeTracker.DetectChanges();

        return Task.FromResult(entry.Entity);
    }
    //
    // protected virtual Task<TEntity> PrepareForSaving(TEntity entity, CancellationToken token = default)
    // {
    //     var mapped = Mapper.Map<TEntity>(entity);
    //     return Task.FromResult();
    // }

    /// <inheritdoc />
    public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token = default)
    {
        // Here we need to ensure we are updating only owned properties.
        var dbEntity = await Context.GetFilteredByIdQuery(entity).IncludeProperties(OwnedProperties).SingleOrDefaultAsync(token);

        if (dbEntity == null) throw ExceptionFactory.NoRecordsFound();

        var entry = Set.Entry(entity);
        entry.State = EntityState.Modified;
        entry.CurrentValues.SetValues(entity);

        // Ensure the data are not contradictory
        Context.ChangeTracker.DetectChanges();

        return dbEntity;
    }

    /// <inheritdoc />
    public virtual Task DeleteAsync(TEntity entity, CancellationToken token = default)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        Context.Remove(entity);

        return Task.CompletedTask;
    }

    protected ValueTask<IQueryable<T>> HandleProjectionAsync<T>(IQueryable<TEntity> query)
    {
        if (!Mapper.IsMappingExists<TEntity, T>())
            throw ExceptionFactory.NotImplemented($"Projections are not available for repository {GetType().Name}.\n" +
                                                  "In order to fix this you can try next solutions:\n" +
                                                  "1. Define EF translatable map in automapper:\n" +
                                                  $"  CreateMap<{typeof(TEntity).Name}, {typeof(T).Name}>();\n" +
                                                  $"2. Override {nameof(HandleProjectionAsync)} method and handle this error manually.");

        return new(query.ProjectTo<T>(Mapper.ConfigurationProvider));
    }

    /// <summary>
    /// Checks if repository implements all required for request functions.
    /// </summary>
    /// <param name="request">The request to be applied.</param>
    /// <exception cref="NotImplementedDomainException">Thrown if some function not implemented.</exception>
    protected virtual void SortGuard(TQueryParams? request)
    {
        if (!string.IsNullOrEmpty(request?.SortBy) && SortingConfiguration == null)
            throw ExceptionFactory.NotImplemented(
                $"Ordering is not supported for this entity. To enable support you can override {nameof(SortingConfiguration)}.");
    }

    /// <summary>
    /// Checks if repository implements all required for request functions.
    /// </summary>
    /// <param name="request">The request to be applied.</param>
    /// <exception cref="NotImplementedDomainException">Thrown if some function not implemented.</exception>
    protected virtual void SearchGuard(TQueryParams? request)
    {
        if (!string.IsNullOrEmpty(request?.Search) && SearchPredicate == null)
            throw ExceptionFactory.NotImplemented(
                $"Querying is not supported for this entity. To enable support you can override {nameof(SearchPredicate)}.");
    }

    /// <summary>
    /// Checks if repository implements all required for request functions.
    /// </summary>
    /// <param name="request">The request to be applied.</param>
    /// <exception cref="NotImplementedDomainException">Thrown if some function not implemented.</exception>
    protected virtual void TypeaheadGuard(TQueryParams? request)
    {
        if (!string.IsNullOrEmpty(request?.Typeahead) && TypeaheadPredicate == null)
            throw ExceptionFactory.NotImplemented(
                $"Typeahead is not supported for this entity. To enable support you can override {nameof(SearchPredicate)}.");
    }

    /// <summary>
    /// Applies includes, filtering, search and ordering to provided query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="request">The request to be applied.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A new instance of query but with repository request parameters applied.</returns>
    protected virtual async Task<IQueryable<TEntity>> ApplyRepositoryRequestAsync(IQueryable<TEntity> query, TQueryParams? request,
        CancellationToken token = default)
    {
        query = await ApplyFilteringAsync(query, request, token);
        query = await ApplySearchAsync(query, request, SearchPredicate, token);
        query = await ApplyTypeaheadAsync(query, request, TypeaheadPredicate, token);
        query = await ApplySortingAsync(query, request, SortingConfiguration, DefaultSortingSelector, DefaultSortingDirection, token);
        return query;
    }

    /// <summary>
    /// Applies filtering to provided query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="request">The request to be applied.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A new instance of query but filtering applied.</returns>
    protected virtual Task<IQueryable<TEntity>> ApplyFilteringAsync(IQueryable<TEntity> query, TQueryParams? request,
        CancellationToken token = default)
    {
        // override this method if additional filtering options are needed.
        return Task.FromResult(query);
    }

    /// <summary>
    /// Applies search to provided query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="request">The request to be applied.</param>
    /// <param name="typeaheadPredicate">A predicate that used for records filtering.</param>
    /// <param name="token">A cancellation token.</param>
    /// <typeparam name="T">An underlying type of the query.</typeparam>
    /// <exception cref="NotImplementedException">This repository has no defined <see cref="typeaheadPredicate" />.</exception>
    /// <returns>A new instance of query but search applied.</returns>
    protected virtual ValueTask<IQueryable<T>> ApplyTypeaheadAsync<T>(IQueryable<T> query, TQueryParams? request,
        Func<string, Expression<Func<T, bool>>>? typeaheadPredicate, CancellationToken token = default)
    {
        if (query is null) throw new ArgumentNullException(nameof(query));

        if (string.IsNullOrEmpty(request?.Typeahead)) return new(query);

        if (typeaheadPredicate == null) throw ExceptionFactory.NotImplemented("Typeahead is not supported.");

        var expr = typeaheadPredicate.Invoke(request.Typeahead);

        query = query.Where(expr);

        return new(query);
    }

    /// <summary>
    /// Applies search to provided query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="request">The request to be applied.</param>
    /// <param name="searchPredicate">A predicate that used for records filtering.</param>
    /// <param name="token">A cancellation token.</param>
    /// <typeparam name="T">An underlying type of the query.</typeparam>
    /// <exception cref="NotImplementedException">This repository has no defined <see cref="searchPredicate" />.</exception>
    /// <returns>A new instance of query but search applied.</returns>
    protected virtual ValueTask<IQueryable<T>> ApplySearchAsync<T>(IQueryable<T> query, TQueryParams? request,
        Func<string, Expression<Func<T, bool>>>? searchPredicate, CancellationToken token = default)
    {
        if (query is null) throw new ArgumentNullException(nameof(query));

        if (string.IsNullOrEmpty(request?.Search)) return new(query);

        var queryRequestQuery = request.Search;
        var searchTokens = SearchInputTokenizer.TokenizeSearch(queryRequestQuery);

        if (searchPredicate == null) throw ExceptionFactory.NotImplemented("Searching is not supported.");

        if (!searchTokens.Any()) return new(query);

        var expr = searchPredicate.Invoke(searchTokens[0]);
        expr = searchTokens.Skip(1).Aggregate(expr, (accum, searchToken) => accum.AndAlso(searchPredicate.Invoke(searchToken)));

        query = query.Where(expr);

        return new(query);
    }

    /// <summary>
    /// Applies dynamic (by properties) sorting to provided query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="orderBy">A name of property to sort by.</param>
    /// <param name="sortingDirection">The sorting direction.</param>
    /// <typeparam name="T">An underlying type of the query.</typeparam>
    /// <returns>A new instance of query but sorting applied.</returns>
    protected virtual ValueTask<IQueryable<T>> ApplyDynamicSortingAsync<T>(IQueryable<T> query, string? orderBy,
        SortingDirectionEnum sortingDirection)
    {
        if (string.IsNullOrWhiteSpace(orderBy)) return new(query);

        if (sortingDirection == SortingDirectionEnum.Desc) orderBy += " DESC";

        return new(DynamicQueryableExtensions.OrderBy(query, orderBy));
    }

    /// <summary>
    /// Applies sorting to provided query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="request">The request to be applied.</param>
    /// <param name="sortingConfiguration">A dictionary with allowed sorting parameters. The key is parameter name, the value is property selector.</param>
    /// <param name="defaultSortingSelector">The default parameter for sorting.</param>
    /// <param name="defaultSortingDirection">The default order direction for sorting.</param>
    /// <param name="token">A cancellation token.</param>
    /// <typeparam name="T">An underlying type of the query.</typeparam>
    /// <typeparam name="TSelector">A type of sort selector expression.</typeparam>
    /// <returns>A new instance of query but sorting applied.</returns>
    protected virtual ValueTask<IQueryable<T>> ApplySortingAsync<T, TSelector>(IQueryable<T> query, TQueryParams? request,
        IReadOnlyDictionary<string, Expression<Func<T, TSelector?>>>? sortingConfiguration = null,
        Expression<Func<T, TSelector?>>? defaultSortingSelector = null,
        SortingDirectionEnum defaultSortingDirection = SortingDirectionEnum.Asc, CancellationToken token = default)
    {
        var sortBy = ToUpperCamelCase(request?.SortBy);
        var sortDirection = request?.SortDirection ?? defaultSortingDirection;

        var hasOrderingProperty = !string.IsNullOrEmpty(sortBy);

        if (hasOrderingProperty && sortingConfiguration?.Any() != true)
            return ApplyDynamicSortingAsync(query, sortBy, sortDirection.DefaultIfNotSet(defaultSortingDirection));

        var sortingSelector = hasOrderingProperty ? GetSortingSelector(sortBy, sortingConfiguration) : defaultSortingSelector;

        return ApplySortingAsync(query, sortingSelector, sortDirection, defaultSortingSelector, defaultSortingDirection, token);
    }

    private static string? ToUpperCamelCase(string? str)
    {
        return str is null ? null : $"{str[0].ToString().ToUpper()}{str[1..]}";
    }

    /// <summary>
    /// Applies sorting to provided query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="sortingSelector">The selector to sort by.</param>
    /// <param name="sortingDirection">The sorting direction.</param>
    /// <param name="defaultSortingSelector">The default parameter for sorting.</param>
    /// <param name="defaultSortingDirection">The default order direction for sorting.</param>
    /// <param name="token">A cancellation token.</param>
    /// <typeparam name="T">An underlying type of the query.</typeparam>
    /// <typeparam name="TSelector">A type of sort selector expression.</typeparam>
    /// <returns>A new instance of query but sorting applied.</returns>
    protected virtual ValueTask<IQueryable<T>> ApplySortingAsync<T, TSelector>(IQueryable<T> query,
        Expression<Func<T, TSelector>>? sortingSelector, SortingDirectionEnum? sortingDirection = null,
        Expression<Func<T, TSelector>>? defaultSortingSelector = null,
        SortingDirectionEnum defaultSortingDirection = SortingDirectionEnum.Asc, CancellationToken token = default)
    {
        sortingDirection = sortingDirection.DefaultIfNotSet(defaultSortingDirection);

        sortingSelector ??= defaultSortingSelector;

        query = query.OptionalOrderBy(sortingSelector, sortingDirection.Value);

        return new(query);
    }

    /// <summary>
    /// Retrieves a sorting selector from <see cref="SortingConfiguration" />. If not found throws an error.
    /// </summary>
    /// <param name="fieldName">A name of property to sort by.</param>
    /// <param name="sortingConfiguration">A dictionary with allowed sorting parameters. The key is parameter name, the value is property selector.</param>
    /// <typeparam name="T">An underlying type of the query.</typeparam>
    /// <typeparam name="TSelector">A type of sort selector expression.</typeparam>
    /// <returns>A selector for sorting by provided field.</returns>
    /// <exception cref="ArgumentException">A requested sorting parameter was not found.</exception>
    protected virtual Expression<Func<T, TSelector?>> GetSortingSelector<T, TSelector>(string? fieldName,
        IReadOnlyDictionary<string, Expression<Func<T, TSelector?>>>? sortingConfiguration)
    {
        if (fieldName == null) throw new ArgumentNullException(nameof(fieldName));

        if (sortingConfiguration == null) throw new ArgumentNullException(nameof(sortingConfiguration));

        if (sortingConfiguration.ContainsKey(fieldName)) return sortingConfiguration[fieldName];

        throw ExceptionFactory.NotImplemented(GetSortingOptionNotSupportedErrorMessage(fieldName, sortingConfiguration.Keys));
    }

    /// <summary>
    /// Returns a message that appears when provided sorting parameter is not supported.
    /// </summary>
    /// <param name="parameterName">A parameter name.</param>
    /// <param name="supportedSortingOptions">A list of supported sorting options.</param>
    /// <returns>The error message.</returns>
    protected virtual string GetSortingOptionNotSupportedErrorMessage(string parameterName, IEnumerable<string> supportedSortingOptions)
    {
        if (supportedSortingOptions == null) throw new ArgumentNullException(nameof(supportedSortingOptions));

        return $"Sorting parameter \"{parameterName}\" is not supported!\n" +
               "Supported parameters: " +
               string.Join(", ", supportedSortingOptions.OrderBy(x => x));
    }

    /// <summary>
    /// Applies includes, filtering, search, ordering and pagination to provided query and retrieves data.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="request">The request to be applied.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>An instance of <see cref="PagedResult{T}" /> with data of query.</returns>
    protected virtual async Task<PagedResult<TEntity>> GetDataByRepositoryRequestAsync(IQueryable<TEntity> query, TQueryParams? request,
        CancellationToken token = default)
    {
        SearchGuard(request);
        SortGuard(request);

        query = await ApplyRepositoryRequestAsync(query, request, token);

        return await ApplyPagination(query, request, token);
    }

    protected virtual async Task<PagedResult<T>> ApplyPagination<T>(IQueryable<T> query, TQueryParams? request, CancellationToken token)
    {
        return await query.PaginateAsync(request, token);
    }

    /// <summary>
    /// Applies includes to provided query. Applies to all request operations.
    /// Uses <see cref="CommonIncludes" />.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <returns>A new instance of query with includes applied.</returns>
    protected virtual IQueryable<TEntity> ApplyCommonIncludes(IQueryable<TEntity> query)
    {
        // override this method to apply includes using query
        return query.IncludeProperties(CommonIncludes);
    }

    /// <summary>
    /// Applies includes to provided query. Should be used for detailed views, when needed a lot of data.
    /// Uses <see cref="DetailedViewIncludes" />.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <returns>A new instance of query with includes applied.</returns>
    protected virtual IQueryable<TEntity> ApplyDetailedViewIncludes(IQueryable<TEntity> query)
    {
        // override this method to apply includes using query
        return query.IncludeProperties(DetailedViewIncludes);
    }

    /// <summary>
    /// Applies filtering of provided query based on access rights of selected user.
    /// Uses <see cref="DetailedViewIncludes" />.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A new instance of query with includes applied.</returns>
    protected virtual ValueTask<IQueryable<TEntity>> ApplyAccessRightsPolicy(IQueryable<TEntity> query, CancellationToken token = default)
    {
        return ValueTask.FromResult(query);
    }

    /// <summary>
    /// Returns a base query to use in all requests within this repository. Disables tracking. Can be overriden to add some logic.
    /// Calls <see cref="ApplyCommonIncludes" />. Includes all <see cref="OwnedProperties" />.
    /// </summary>
    /// <param name="options">An options for the query.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A query to use in further queries.</returns>
    protected virtual async Task<IQueryable<TEntity>> GetBaseQueryAsync(RepositoryQueryOptions? options = null,
        CancellationToken token = default)
    {
        var query = Set.AsNoTracking();

        // true by default
        if (options?.LoadOwnedProperties ?? true) query = query.IncludeProperties(OwnedProperties);

        // true by default
        if (options?.LoadCommonIncludes ?? true) query = ApplyCommonIncludes(query);

        // false by default
        if (options?.LoadDetailedViewIncludes ?? false) query = ApplyDetailedViewIncludes(query);

        // false by default
        if (options?.AccessPolicyDisabled != true) query = await ApplyAccessRightsPolicy(query, token);

        return query;
    }

    /// <summary>
    /// Throws <see cref="NotFoundDomainException" /> if resulting collection is empty.
    /// </summary>
    /// <param name="result">The resulting collection.</param>
    /// <typeparam name="T">A resulting collection type.</typeparam>
    /// <exception cref="NotFoundDomainException">Thrown if collection is empty.</exception>
    protected virtual void EnsureAny<T>(ICollection<T>? result)
    {
        if (result?.Any() != true) throw ExceptionFactory.NoRecordsFound();
    }
}
