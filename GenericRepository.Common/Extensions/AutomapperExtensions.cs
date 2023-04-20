using AutoMapper;
using AutoMapper.Internal;
using System.Collections;

namespace GenericRepository.Common.Extensions;

/// <summary>
/// Extensions for simplify work with <see cref="IMapper" />.
/// </summary>
public static class AutomapperExtensions
{
    /// <summary>
    /// Checks if <paramref name="mapper" /> contains a mapping from <typeparamref name="TSource" /> to <typeparamref name="TDestination" />.
    /// </summary>
    /// <param name="mapper">The automapper used to convert types.</param>
    /// <typeparam name="TSource">Source type.</typeparam>
    /// <typeparam name="TDestination">Destination type.</typeparam>
    /// <returns>Boolean value corresponding whether mapping exists or not.</returns>
    public static bool IsMappingExists<TSource, TDestination>(this IMapper mapper)
    {
        var rule = mapper.ConfigurationProvider.Internal().FindTypeMapFor<TSource, TDestination>();

        return rule != null;
    }

    /// <summary>
    /// Checks if <paramref name="mapper" /> contains a self-mapping of type <typeparamref name="T" />.
    /// </summary>
    /// <param name="mapper">The automapper used to convert types.</param>
    /// <typeparam name="T">The type for checking.</typeparam>
    /// <returns>Boolean value corresponding whether mapping exists or not.</returns>
    public static bool IsSelfMappingExists<T>(this IMapper mapper)
    {
        return IsMappingExists<T, T>(mapper);
    }

    /// <summary>
    /// Converts all collection items to different type using a provided <paramref name="mapper" />.
    /// </summary>
    /// <param name="mapper">The automapper used to convert types.</param>
    /// <param name="value">A collection to be mapped.</param>
    /// <typeparam name="T">Destination type.</typeparam>
    /// <returns>A list of mapped objects.</returns>
    public static List<T> MapCollectionTo<T>(this IMapper mapper, IEnumerable value)
    {
        return mapper.Map<List<T>>(value);
    }

    /// <summary>
    /// Executes a mapping from the source object to a new destination object. The source type is inferred from the source object.
    /// If <paramref name="source" /> of type <typeparamref name="TDestination" /> no mapping is performed.
    /// </summary>
    /// <param name="mapper">The automapper used to convert types.</param>
    /// <param name="source">The object to be mapped.</param>
    /// <typeparam name="TDestination">A type to map to.</typeparam>
    /// <returns>A mapped object.</returns>
    public static TDestination MapSelfIgnored<TDestination>(this IMapper mapper, object source)
    {
        if (source is TDestination destination) return destination;

        return mapper.Map<TDestination>(source);
    }

    /// <summary>
    /// Ignores all members.
    /// </summary>
    /// <param name="expression">The mapping configuration expression.</param>
    /// <typeparam name="TSource">A map from type.</typeparam>
    /// <typeparam name="TDest">A map to type.</typeparam>
    /// <returns><see cref="expression" /> instance.</returns>
    public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(
        this IMappingExpression<TSource, TDest> expression)
    {
        expression.ForAllMembers(opt => opt.Ignore());
        return expression;
    }
}
