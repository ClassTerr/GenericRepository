using GenericRepository.Common.Common;
using GenericRepository.Common.Extensions;

namespace GenericRepository;

/// <summary>
/// An implementation for <see cref="IDateTime" /> that works with local machine date and time.
/// </summary>
public class MachineDateTimeService : IDateTime
{
    /// <inheritdoc />
    public long Timestamp => NowUtc.ToTimestamp();

    /// <inheritdoc />
    public DateTime Now => DateTime.Now;

    /// <inheritdoc />
    public DateTime NowUtc => DateTime.UtcNow;
}
