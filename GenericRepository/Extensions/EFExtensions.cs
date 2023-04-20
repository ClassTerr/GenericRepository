using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Concurrent;

namespace GenericRepository.Extensions;

/// <summary>
/// Extensions for simplify work with <see cref="string" />.
/// </summary>
public static class EfExtensions
{
    private static readonly ConcurrentDictionary<Type, IReadOnlyList<IProperty>> PrimaryKeysDict = new();

    /// <summary>
    /// Gets a list of properties that are primary key of entity with type <paramref name="entityType" />.
    /// Supports composite primary keys.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="entityType">The entity type to get key properties from.</param>
    /// <returns>A list of PK properties.</returns>
    public static IReadOnlyList<IProperty> GetPrimaryKeyProperties(this DbContext? context, Type? entityType)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (entityType == null) throw new ArgumentNullException(nameof(entityType));

        return PrimaryKeysDict.GetOrAdd(entityType,
            x =>
            {
                var typeMetadata = context.Model.FindEntityType(x) ??
                                   throw new($"There is no DbSet<{entityType.FullName}> in the {context.GetType().Name}");

                return typeMetadata.FindPrimaryKey()?.Properties!;
            });
    }

    /// <summary>
    /// Gets a list of properties that are primary key of entity with type <typeparamref name="T" />.
    /// Supports composite primary keys.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <typeparam name="T">The entity type to get key properties from.</typeparam>
    /// <returns>A list of PK properties.</returns>
    public static IReadOnlyList<IProperty> GetPrimaryKeyProperties<T>(this DbContext context)
    {
        return context.GetPrimaryKeyProperties(typeof(T));
    }

    /// <summary>
    /// Gets an enumeration of tuples of primary key property name and value of given entity.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="entity">An entity to get PK value from.</param>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <returns>An enumeration of tuples of property name and it's value.</returns>
    /// <exception cref="Exception">Thrown in case of using with keyless entity types.</exception>
    public static IEnumerable<(string Property, object? Value)> GetPrimaryKey<T>(this DbContext? context, T entity)
    {
        var pk = context?.GetPrimaryKeyProperties<T>();

        if (pk?.Any() != true) throw new("Can't handle keyless entities.");

        var keyNames = pk.Select(x => x.Name);
        var keyValues = pk.Select(x => x.PropertyInfo!.GetValue(entity));

        return keyNames.Zip(keyValues);
    }

    /// <summary>
    /// Returns a query filtered by id of given entity.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="entity">An entity to get PK value from.</param>
    /// <param name="baseQuery">A query to filter. Defaults to context.Set{T}().</param>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <returns>A filtered query.</returns>
    public static IQueryable<T> GetFilteredByIdQuery<T>(this DbContext context, T entity, IQueryable<T>? baseQuery = null)
        where T : class
    {
        return GetFilteredByIdQuery(context, context.GetPrimaryKey(entity), baseQuery);
    }

    /// <summary>
    /// Returns a query filtered by given id.
    /// </summary>
    /// <param name="context">The db context.</param>
    /// <param name="id">An enumerator of properties representing a primary key.</param>
    /// <param name="baseQuery">A query to filter. Defaults to context.Set{T}().</param>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <returns>A filtered query.</returns>
    public static IQueryable<T> GetFilteredByIdQuery<T>(
        this DbContext context,
        IEnumerable<(string Property, object? Value)> id,
        IQueryable<T>? baseQuery = null)
        where T : class
    {
        baseQuery ??= context.Set<T>();

        foreach (var (propertyName, value) in id) baseQuery = baseQuery.Where(x => EF.Property<object>(x, propertyName) == value);

        return baseQuery;
    }
}
