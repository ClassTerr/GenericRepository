namespace GenericRepository.Common.Common;

public abstract class BaseEntity<TPrimaryKey>
    : IEntity<TPrimaryKey> where TPrimaryKey : IEquatable<TPrimaryKey>
{
    public virtual TPrimaryKey Id { get; set; } = default!;
}
