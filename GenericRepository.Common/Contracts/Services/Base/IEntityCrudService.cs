using GenericRepository.Common.Common;
using GenericRepository.Common.Contracts.QueryParams;
using GenericRepository.Common.Models.Repositories;

#pragma warning disable SA1402

namespace GenericRepository.Common.Contracts.Services.Base;

/// <summary>
/// A service capable to perform full set of CRUD operation.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TMapped">A model used for proxying in default methods.</typeparam>
public interface IEntityCrudService<TPrimaryKey, TMapped> : IEntityCrudService<TPrimaryKey, TMapped, TMapped>
    where TPrimaryKey : IEquatable<TPrimaryKey> { }

/// <summary>
/// A service capable to perform full set of CRUD operation.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TCommand">A model used for creating and updating entities in default methods.</typeparam>
/// <typeparam name="TResponse">A model that returned from query methods.</typeparam>
public interface IEntityCrudService<TPrimaryKey, in TCommand, TResponse> : IEntityCrudService<TPrimaryKey, TCommand,
    TCommand, TResponse, TResponse>
    where TPrimaryKey : IEquatable<TPrimaryKey> { }

/// <summary>
/// A service capable to perform full set of CRUD operations.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TCreateCommand">A model used for creating new entities in default methods.</typeparam>
/// <typeparam name="TUpdateCommand">A model used for updating exising entities in default methods.</typeparam>
/// <typeparam name="TListResponse">A model that returned from methods returning a list of entities.</typeparam>
/// <typeparam name="TDetailedResponse">A model that returned from methods returning a single, more detailed entity.</typeparam>
public interface IEntityCrudService<TPrimaryKey, in TCreateCommand, in TUpdateCommand, TListResponse, TDetailedResponse> :
    IEntityCrudService<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, IListItem<TPrimaryKey>>
    where TPrimaryKey : IEquatable<TPrimaryKey> { }

/// <summary>
/// A service capable to perform full set of CRUD operations.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TCreateCommand">A model used for creating new entities in default methods.</typeparam>
/// <typeparam name="TUpdateCommand">A model used for updating exising entities in default methods.</typeparam>
/// <typeparam name="TListResponse">A model that returned from methods returning a list of entities.</typeparam>
/// <typeparam name="TDetailedResponse">A model that returned from methods returning a single, more detailed entity.</typeparam>
/// <typeparam name="TAutocomplete">The type used for autocomplete.</typeparam>
public interface IEntityCrudService<TPrimaryKey, in TCreateCommand, in TUpdateCommand, TListResponse, TDetailedResponse,
    TAutocomplete> :
    IEntityCrudService<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete,
        IQueryParams<TPrimaryKey>>
    where TPrimaryKey : IEquatable<TPrimaryKey> { }

/// <summary>
/// A service capable to perform full set of CRUD operations.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
/// <typeparam name="TCreateCommand">A model used for creating new entities in default methods.</typeparam>
/// <typeparam name="TUpdateCommand">A model used for updating exising entities in default methods.</typeparam>
/// <typeparam name="TListResponse">A model that returned from methods returning a list of entities.</typeparam>
/// <typeparam name="TDetailedResponse">A model that returned from methods returning a single, more detailed entity.</typeparam>
/// <typeparam name="TAutocomplete">The type used for autocomplete.</typeparam>
/// <typeparam name="TQueryParams">A model used to specify custom filters or other criteria for querying.</typeparam>
public interface IEntityCrudService<TPrimaryKey, in TCreateCommand, in TUpdateCommand, TListResponse, TDetailedResponse,
    TAutocomplete, in TQueryParams> : IEntityReadonlyService<TPrimaryKey, TListResponse, TDetailedResponse, TAutocomplete,
    TQueryParams>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    /// Creates an entity <paramref name="createCommand" /> in the change tracker.
    /// </summary>
    /// <param name="createCommand">A create command model.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>
    /// An id accessor. It should be used only after IUnitOfWork.SaveChangesAsync was called.
    /// Before this point this value will be client-generated temporary value that is used only for
    /// linking entities from other repositories with the same unit of work.
    /// If <typeparamref name="TPrimaryKey" /> is <see cref="Guid" /> then value can be used even before IUnitOfWork.SaveChangesAsync.
    /// </returns>
    Task<ValueAccessor<TPrimaryKey>> CreateAsync(TCreateCommand createCommand, CancellationToken token = default);

    /// <summary>
    /// Updates an entity <paramref name="updateCommand" /> in the change tracker.
    /// </summary>
    /// <param name="id">An id of entity to be deleted.</param>
    /// <param name="updateCommand">An update command model.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task UpdateAsync(TPrimaryKey id, TUpdateCommand updateCommand, CancellationToken token = default);

    /// <summary>
    /// Returns an entity with id equal to <paramref name="id" /> if it exists.
    /// Id parameters for composite primary key have to be in the same order as defined within fluent API map.
    /// </summary>
    /// <param name="id">An id of entity to be deleted.</param>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task DeleteByIdAsync(TPrimaryKey id, CancellationToken token = default);
}
