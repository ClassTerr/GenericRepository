using GenericRepository.Common.Common;

namespace GenericRepository.Common.Models.Repositories.Result;

/// <summary>
/// Represents a result of create operation of <see cref="IEntityRepository{TEntity}" />.
/// </summary>
/// <param name="Entity">The created entity.</param>
/// w
/// <param name="ValueAccessor">The accessor for created entity primary key.</param>
/// <typeparam name="TEntity">Type of the entity.</typeparam>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
public record CreateEntityResult<TEntity, TPrimaryKey>(TEntity Entity, ValueAccessor<TPrimaryKey> ValueAccessor);
