using System.Net;

namespace GenericRepository.Common.Exceptions;

/// <summary>
/// A custom exception for letting know that a conflict has been occured.
/// </summary>
public class DomainConflictException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainConflictException" /> class.
    /// </summary>
    /// <param name="localizedMessage">The error message.</param>
    /// <param name="localizedTitle">The error title.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    public DomainConflictException(string? localizedMessage, string localizedTitle, bool isUserFriendly = true)
        : base(localizedMessage, localizedTitle, HttpStatusCode.Conflict, isUserFriendly) { }
}
