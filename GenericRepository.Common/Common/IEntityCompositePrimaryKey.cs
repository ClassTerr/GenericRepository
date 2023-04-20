using System.Linq.Expressions;

namespace GenericRepository.Common.Common;

/// <summary>
/// An interface for entity composite key model.
/// </summary>
/// <typeparam name="TEntity">A type of the entity.</typeparam>
public interface IEntityCompositePrimaryKey<TEntity>
{
    /// <summary>
    /// Gets an expression that performs a filtering by id of this entity.
    /// </summary>
    /// <returns>An expression for filtering.</returns>
    Expression<Func<TEntity, bool>> GetFilterById(); // TODO: think how this can be handled automatically
}
