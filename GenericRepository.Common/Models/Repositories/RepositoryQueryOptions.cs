namespace GenericRepository.Common.Models.Repositories;

/// <summary>
/// A type that represents options for repository request.
/// </summary>
public record RepositoryQueryOptions(
    bool? LoadDetailedViewIncludes = null,
    bool? LoadCommonIncludes = null,
    bool? LoadOwnedProperties = null,
    bool Required = false,
    bool AccessPolicyDisabled = false)
{
    /// <summary>
    /// Gets an instance of <see cref="RepositoryQueryOptions" /> configured for retrieving only parent entity. No additional includes
    /// performed.
    /// </summary>
    public static RepositoryQueryOptions BareView => new(false, false, false);

    /// <summary>
    /// Gets an instance of <see cref="RepositoryQueryOptions" /> configured for default view. Only owned properties are loaded.
    /// </summary>
    public static RepositoryQueryOptions Default => new(false, false, true);

    /// <summary>
    /// Gets options best fitting for detailed view for entity.
    /// </summary>
    public static RepositoryQueryOptions DetailedView => new(true, true, true);

    /// <summary>
    /// Gets an instance of <see cref="RepositoryQueryOptions" /> configured for list view for entity.
    /// </summary>
    public static RepositoryQueryOptions ListView => new(false, true, true);

    /// <summary>
    /// Gets a copy of current <see cref="RepositoryQueryOptions" /> with configured ThrowIfNoResult property.
    /// </summary>
    /// <param name="required">Boolean value indicating if this query should throw a NotFoundException if nothing is found.</param>
    /// <returns>An instance of <see cref="RepositoryQueryOptions" /> with configured ThrowIfNoResult property.</returns>
    public RepositoryQueryOptions SetRequired(bool required = true)
    {
        return this with
        {
            Required = required
        };
    }

    /// <summary>
    /// Gets a copy of current <see cref="RepositoryQueryOptions" /> with configured AccessPolicyDisabled property.
    /// </summary>
    /// <param name="disable">Boolean value indicating if this query should ignore access rights policy.</param>
    /// <returns>An instance of <see cref="RepositoryQueryOptions" /> with configured AccessPolicyDisabled property.</returns>
    public RepositoryQueryOptions DisableAccessPolicyFilter(bool disable = true)
    {
        return this with
        {
            AccessPolicyDisabled = disable
        };
    }
}
