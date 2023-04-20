using System.Net;

namespace GenericRepository.Common.Exceptions;

/// <summary>
/// A custom exception for letting know that something was not found.
/// </summary>
public class NotFoundDomainException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundDomainException" /> class.
    /// </summary>
    /// <param name="localizedMessage">The error message.</param>
    /// <param name="localizedTitle">The error title.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    public NotFoundDomainException(string localizedMessage, string? localizedTitle = null, bool isUserFriendly = true)
        : base(localizedMessage, localizedTitle ?? "Not found", HttpStatusCode.NotFound, isUserFriendly) { }
}
