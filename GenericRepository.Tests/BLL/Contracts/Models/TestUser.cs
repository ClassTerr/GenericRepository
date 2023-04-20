using GenericRepository.Common.Contracts;

namespace GenericRepository.Tests.BLL.Contracts.Models;

/// <summary>
/// Represents a user that came from API.
/// </summary>
public class TestUser : IUser
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TestUser" /> class.
    /// Represents a user that came from API.
    /// </summary>
    /// <param name="userId">An id of the user.</param>
    /// <param name="displayName">A name of the user.</param>
    /// <param name="claims">A user claims.</param>
    public TestUser(Guid userId, string displayName, List<KeyValuePair<string, string>> claims)
    {
        UserId = userId;
        DisplayName = displayName;
        Claims = claims;
    }

    /// <summary>An id of the user in form of string.</summary>
    public Guid UserId { get; }

    /// <summary>A name of the user.</summary>
    public string DisplayName { get; }

    /// <summary>A user claims.</summary>
    public List<KeyValuePair<string, string>> Claims { get; }
}
