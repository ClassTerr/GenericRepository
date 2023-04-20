namespace GenericRepository.Common.Models.Repositories;

/// <summary>
/// Represents an object for storing strings that can be formatted using parameters.
/// </summary>
/// <param name="Template">The string template.</param>
/// <param name="Args">The string arguments.</param>
public record TemplateString(string Template, params object[] Args)
{
    /// <summary>
    /// Converts a <see cref="TemplateString" /> to <see cref="string" />.
    /// </summary>
    /// <param name="str">The source <see cref="TemplateString" />.</param>
    /// <returns>A string with applied arguments using <see cref="string.Format(System.IFormatProvider?,string,object?)" />.</returns>
    public static implicit operator string(TemplateString str)
    {
        return string.Format(str.Template, str.Args);
    }

    /// <summary>
    /// Converts a <see cref="string" /> to <see cref="TemplateString" />.
    /// </summary>
    /// <param name="str">The source <see cref="string" />.</param>
    /// <returns>A <see cref="TemplateString" /> with no arguments.</returns>
    public static explicit operator TemplateString(string str)
    {
        return new(str);
    }
}
