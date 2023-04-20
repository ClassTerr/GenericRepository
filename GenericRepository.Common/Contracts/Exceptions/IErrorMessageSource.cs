namespace GenericRepository.Common.Contracts.Exceptions;

/// <summary>
/// A marker interface to indicate that error message can be exposed to the end user.
/// </summary>
public interface IErrorMessageSource
{
    /// <summary>
    /// Gets the error title.
    /// </summary>
    string Message { get; }
}
