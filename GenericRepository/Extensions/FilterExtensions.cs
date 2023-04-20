using GenericRepository.Common.Models.Filters;
using System.Linq.Expressions;

namespace GenericRepository.Extensions;

public static class FilterExtensions
{
    public static IQueryable<T> ApplyStringPropertyFilter<T>(
        this IQueryable<T> query,
        Expression<Func<T, string>> propertySelector,
        StringPropertyFilter? filter)
    {
        if (filter is null)
            return query;

        if (!string.IsNullOrEmpty(filter.Contains))
        {
            var containsFilter = Expression.Call(
                propertySelector.Body,
                typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!,
                Expression.Constant(filter.Contains));

            query = query.Where(Expression.Lambda<Func<T, bool>>(containsFilter, propertySelector.Parameters));
        }

        if (!string.IsNullOrEmpty(filter.ExactMatch))
        {
            var exactMatchFilter = Expression.Equal(
                propertySelector.Body,
                Expression.Constant(filter.ExactMatch));

            query = query.Where(Expression.Lambda<Func<T, bool>>(exactMatchFilter, propertySelector.Parameters));
        }

        if (!string.IsNullOrEmpty(filter.NotContains))
        {
            var notContainsFilter = Expression.Not(
                Expression.Call(
                    propertySelector.Body,
                    typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) })!,
                    Expression.Constant(filter.NotContains)));

            query = query.Where(Expression.Lambda<Func<T, bool>>(notContainsFilter, propertySelector.Parameters));
        }

        if (!string.IsNullOrEmpty(filter.StartsWith))
        {
            var startsWithFilter = Expression.Call(
                propertySelector.Body,
                typeof(string).GetMethod(nameof(string.StartsWith), new[] { typeof(string) })!,
                Expression.Constant(filter.StartsWith));

            query = query.Where(Expression.Lambda<Func<T, bool>>(startsWithFilter, propertySelector.Parameters));
        }

        return query;
    }
}
