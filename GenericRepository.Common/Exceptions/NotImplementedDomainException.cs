using System.Net;

namespace GenericRepository.Common.Exceptions;

/// <summary>
/// A custom exception for letting know that some action cannot be performed as it is not implemented in derived types.
/// </summary>
public class NotImplementedDomainException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotImplementedDomainException" /> class.
    /// </summary>
    /// <param name="localizedMessage">The error message.</param>
    /// <param name="localizedTitle">The error title.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    public NotImplementedDomainException(string? localizedMessage, string localizedTitle, bool isUserFriendly = true)
        : base(localizedMessage, localizedTitle, HttpStatusCode.NotImplemented, isUserFriendly) { }
}
