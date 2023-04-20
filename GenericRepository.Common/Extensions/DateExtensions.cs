namespace GenericRepository.Common.Extensions;

/// <summary>
/// Extensions for simplify work with <see cref="DateTimeOffset" />.
/// </summary>
public static class DateExtensions
{
    /// <summary>
    /// Converts <see cref="DateTime" /> object into a timestamp.
    /// </summary>
    /// <param name="date"><see cref="DateTime" /> object.</param>
    /// <returns>A timestamp.</returns>
    public static long ToTimestamp(this DateTime date)
    {
        return new DateTimeOffset(date).ToTimestamp();
    }

    /// <summary>
    /// Converts timestamp into an instance of <see cref="DateTime" /> in UTC timezone.
    /// </summary>
    /// <param name="timestamp">A timestamp value.</param>
    /// <returns>An instance of <see cref="DateTime" /> in UTC timezone.</returns>
    public static DateTime ToDateTime(this long timestamp)
    {
        return ToDateTimeOffset(timestamp).UtcDateTime;
    }

    /// <summary>
    /// Converts <see cref="DateTimeOffset" /> object into a timestamp.
    /// </summary>
    /// <param name="date"><see cref="DateTimeOffset" /> object.</param>
    /// <returns>A timestamp.</returns>
    public static long ToTimestamp(this DateTimeOffset date)
    {
        return date.ToUnixTimeSeconds();
    }

    /// <summary>
    /// Converts timestamp into an instance of <see cref="DateTimeOffset" />.
    /// </summary>
    /// <param name="timestamp">A timestamp value.</param>
    /// <returns>An instance of <see cref="DateTimeOffset" />.</returns>
    public static DateTimeOffset ToDateTimeOffset(this long timestamp)
    {
        return DateTimeOffset.FromUnixTimeSeconds(timestamp);
    }
}
