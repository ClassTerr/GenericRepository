namespace GenericRepository.Common.Models.Repositories;

/// <inheritdoc />
public interface IListItem : IListItem<int> { }

/// <summary>
/// The representation of entity used for lists such as autocomplete.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
public interface IListItem<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    /// Gets or sets unique identifier for entity.
    /// </summary>
    TPrimaryKey Id { get; set; }

    /// <summary>
    /// Gets a displayable title.
    /// </summary>
    public string Title { get; }
}
