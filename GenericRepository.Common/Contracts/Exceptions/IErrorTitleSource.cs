namespace GenericRepository.Common.Contracts.Exceptions;

/// <summary>
/// Error object or exception with this interface is capable to carry title.
/// </summary>
public interface IErrorTitleSource
{
    /// <summary>
    /// Gets the error title.
    /// </summary>
    string? Title { get; }
}
