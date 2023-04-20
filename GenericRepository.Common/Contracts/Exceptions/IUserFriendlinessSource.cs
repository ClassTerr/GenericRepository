namespace GenericRepository.Common.Contracts.Exceptions;

/// <summary>
/// Contains information whether the data of object with this interface should be shown to end user.
/// </summary>
public interface IUserFriendlinessSource
{
    /// <summary>Gets a value indicating whether the data of object with this interface should be shown to end user.</summary>
    public bool IsUserFriendly { get; }
}
