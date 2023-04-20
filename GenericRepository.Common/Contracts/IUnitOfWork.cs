namespace GenericRepository.Common.Contracts;

/// <summary>
/// Represents an object that used to perform multiple changes atomically.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Saves all changes made in this unit of work to the database.
    /// </summary>
    /// <param name="token">A cancellation token.</param>
    /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
    Task SaveChangesAsync(CancellationToken token = default);

    /// <summary>
    /// Discards all changes made in this unit of work.
    /// </summary>
    void Rollback();
}
