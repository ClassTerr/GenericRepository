using GenericRepository.Common.Common;
using GenericRepository.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GenericRepository.Extensions;

/// <summary>
/// Extensions for simplify work with <see cref="IQueryable{T}" />.
/// </summary>
public static class QueryExtensions
{
    /// <summary>
    /// Includes all navigation properties to the query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="propertiesToInclude">A list of property selectors to include.</param>
    /// <typeparam name="T">The query type.</typeparam>
    /// <returns>The source query with included properties.</returns>
    /// <exception cref="ArgumentNullException">The source query was null.</exception>
    public static IQueryable<T> IncludeProperties<T>(
        this IQueryable<T> query,
        IEnumerable<Expression<Func<T, object>>>? propertiesToInclude)
        where T : class
    {
        if (query == null) throw new ArgumentNullException(nameof(query));

        if (propertiesToInclude is null)
            return query;

        return propertiesToInclude.Aggregate(query, (current, expression) => current.Include(expression));
    }

    /// <summary>
    /// Includes all navigation properties to the query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="propertiesToInclude">A list of property selectors to include.</param>
    /// <typeparam name="T">The query type.</typeparam>
    /// <returns>The source query with included properties.</returns>
    /// <exception cref="ArgumentNullException">The source query was null.</exception>
    public static IQueryable<T> IncludeProperties<T>(
        this IQueryable<T> query,
        params Expression<Func<T, object>>[] propertiesToInclude)
        where T : class
    {
        return IncludeProperties(query, propertiesToInclude.AsEnumerable());
    }

    /// <summary>
    /// Applies filtering by id of provided query.
    /// </summary>
    /// <param name="query">The source query.</param>
    /// <param name="ids">An id of the desired entity.</param>
    /// <typeparam name="TEntity">Type of the entity.</typeparam>
    /// <typeparam name="TPrimaryKey">A type of entity's primary key.</typeparam>
    /// <returns>A new query with applied filter by id.</returns>
    public static IQueryable<TEntity> FilterById<TEntity, TPrimaryKey>(this IQueryable<TEntity> query,
        params TPrimaryKey[] ids)
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        if (!ids.Any()) throw new ArgumentException("Provide at least one id.");

        switch (ids)
        {
            // TODO: consider batching in some way or throw if there are too many ids.
            case IEntityCompositePrimaryKey<TEntity>[] compositeIds:
            {
                var expr = compositeIds[0].GetFilterById();
                expr = compositeIds.Skip(1).Aggregate(expr, (accum, id) => accum.OrElse(id.GetFilterById()));

                return query.Where(expr);
            }
            default:
                return query.Where(x => ids.Contains(x.Id));
        }
    }

    /// <summary>
    /// Performs query ordering using provided <see cref="SortingDirectionEnum" />.
    /// </summary>
    /// <param name="source">The source query.</param>
    /// <param name="keySelector">An order expression selector.</param>
    /// <param name="sortingDirection">An order direction.</param>
    /// <typeparam name="TSource">The type of entity.</typeparam>
    /// <typeparam name="TKey">The type of order expression selector.</typeparam>
    /// <returns>A query with applied sorting.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when provided <paramref name="sortingDirection" /> is not valid.</exception>
    public static IQueryable<TSource> OptionalOrderBy<TSource, TKey>(
        this IQueryable<TSource>? source,
        Expression<Func<TSource, TKey>>? keySelector,
        SortingDirectionEnum sortingDirection)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));

        if (keySelector is null) return source;

        return sortingDirection switch
        {
            SortingDirectionEnum.NotSet => source,
            SortingDirectionEnum.Asc => source.OrderBy(keySelector),
            SortingDirectionEnum.Desc => source.OrderByDescending(keySelector),
            _ => throw new ArgumentOutOfRangeException(nameof(sortingDirection), sortingDirection, null)
        };
    }
}
