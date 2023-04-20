namespace GenericRepository.Extensions;

/// <summary>
/// Extensions for simplify work with <see cref="Type" />.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// The same method as <see cref="Type.IsAssignableFrom" />, but works also for generic types.
    /// </summary>
    /// <param name="genericType">The type to compare with <paramref name="givenType" />.</param>
    /// <param name="givenType">The type to check.</param>
    /// <returns>True if a <paramref name="givenType" /> is assignable from <paramref name="genericType" /> and false otherwise.</returns>
    public static bool IsAssignableFromGenericType(this Type genericType, Type givenType)
    {
        var interfaceTypes = givenType.GetInterfaces();

        if (interfaceTypes.Any(it => (it.IsGenericType && it.GetGenericTypeDefinition() == genericType) || it == genericType))
            return true;

        if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType) return true;

        var baseType = givenType.BaseType;
        if (baseType == null) return false;

        return IsAssignableFromGenericType(genericType, baseType);
    }
}
