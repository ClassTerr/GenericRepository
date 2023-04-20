namespace GenericRepository.Common.Common;

/// <inheritdoc />
public interface IEntity : IEntity<int> { }

/// <summary>
/// Defines interface for base entity type. Used for repositories implementation.
/// </summary>
/// <typeparam name="TPrimaryKey">Type of the primary key of the entity.</typeparam>
public interface IEntity<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    /// Gets or sets unique identifier for this entity.
    /// </summary>
    TPrimaryKey Id { get; set; }
}
