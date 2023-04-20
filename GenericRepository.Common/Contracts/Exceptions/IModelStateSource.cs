namespace GenericRepository.Common.Contracts.Exceptions;

/// <summary>
/// Error object or exception with this interface is capable to carry information about error messages for properties.
/// </summary>
public interface IModelStateSource
{
    /// <summary>
    /// Gets the error model state.
    /// </summary>
    IDictionary<string, string[]> ModelState { get; }
}
