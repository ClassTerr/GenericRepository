namespace GenericRepository.Common.Constants;

/// <summary>
/// Represents constants of maximum length of strings stored in the database.
/// </summary>
public static class StringPropertyLengthConstants
{
    /// <summary>
    /// A maximum length of property that represents an id.
    /// </summary>
    /// <remarks>Serialized GUID is of 36 characters.</remarks>
    public const int Id = 64;

    /// <summary>
    /// A maximum length of property which expected to be short length.
    /// </summary>
    public const int ShortString = 32;

    /// <summary>
    /// A maximum length of property that represents a name of something.
    /// </summary>
    public const int Name = 256;

    /// <summary>
    /// A maximum length of property that represents a user name.
    /// </summary>
    public const int UserName = 64;

    /// <summary>
    /// A maximum length of property that represents an email.
    /// </summary>
    public const int Email = 254;

    /// <summary>
    /// A maximum length of property that represents a description of something.
    /// </summary>
    public const int Description = 2048;

    /// <summary>
    /// A maximum length of property that represents a URL.
    /// </summary>
    public const int Url = 2000;

    /// <summary>
    /// A maximum possible length of json string property.
    /// </summary>
    public const int Json = MaxLength;

    /// <summary>
    /// A maximum possible length of string property.
    /// </summary>
    public const int MaxLength = 8000;

    /// <summary>
    /// A maximum possible length of string property.
    /// </summary>
    public const int Title = 2048;
}
