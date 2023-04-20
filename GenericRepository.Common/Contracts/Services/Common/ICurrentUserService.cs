namespace GenericRepository.Common.Contracts.Services.Common;

/// <summary>
/// A service for retrieving information about user who performs operation.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets a current user.
    /// </summary>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A current user.</returns>
    Task<IUser> GetUserAsync(CancellationToken token = default);
}
