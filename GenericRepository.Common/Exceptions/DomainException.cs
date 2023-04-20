using GenericRepository.Common.Contracts.Exceptions;
using System.Net;

namespace GenericRepository.Common.Exceptions;

/// <summary>
/// Base exception for all domain-based exceptions.
/// </summary>
public class DomainException : Exception,
    IErrorMessageSource,
    IErrorTitleSource,
    IHttpStatusCodeSource,
    IUserFriendlinessSource
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException" /> class.
    /// </summary>
    /// <param name="localizedMessage">The error message.</param>
    /// <param name="localizedTitle">The error title.</param>
    /// <param name="httpStatusCode">The http status code.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    public DomainException(
        string? localizedMessage,
        string? localizedTitle,
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError,
        bool isUserFriendly = true)
        : base(localizedMessage)
    {
        Title = localizedTitle ?? throw new ArgumentNullException(nameof(localizedTitle));
        StatusCode = httpStatusCode;
        IsUserFriendly = isUserFriendly;
    }

    /// <inheritdoc />
    public string? Title { get; }

    /// <inheritdoc />
    public HttpStatusCode StatusCode { get; }

    /// <inheritdoc />
    public bool IsUserFriendly { get; }
}
