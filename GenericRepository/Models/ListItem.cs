using GenericRepository.Common.Models.Repositories;

namespace GenericRepository.Models;

/// <summary>
/// The representation of entity used for lists such as autocomplete.
/// </summary>
/// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
public class ListItem<TPrimaryKey> : IListItem<TPrimaryKey>
    where TPrimaryKey : IEquatable<TPrimaryKey>
{
    /// <summary>
    /// Gets an id of the entity.
    /// </summary>
    public TPrimaryKey Id { get; set; } = default!;

    /// <summary>
    /// Gets a name of the user.
    /// </summary>
    public string Title { get; set; } = null!;
}
