using GenericRepository.Common.Contracts.Exceptions;
using System.Net;

namespace GenericRepository.Common.Exceptions;

/// <summary>
/// A custom exception for letting know that some action cannot be performed as it is not implemented in derived types.
/// </summary>
public class ValidationDomainException : DomainException,
    IModelStateSource
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationDomainException" /> class.
    /// </summary>
    /// <param name="localizedMessage">The error message.</param>
    /// <param name="localizedTitle">The error title.</param>
    /// <param name="modelState">The model state. Keys are property names and values are error messages.</param>
    /// <param name="isUserFriendly">Indicating whether the data of object with this interface should be shown to end user.</param>
    public ValidationDomainException(
        string localizedMessage,
        string localizedTitle,
        IDictionary<string, string[]> modelState,
        bool isUserFriendly = true)
        : base(localizedMessage, localizedTitle, HttpStatusCode.BadRequest, isUserFriendly)
    {
        ModelState = modelState ?? throw new ArgumentNullException(nameof(modelState));
    }

    /// <inheritdoc />
    public IDictionary<string, string[]> ModelState { get; }
}
