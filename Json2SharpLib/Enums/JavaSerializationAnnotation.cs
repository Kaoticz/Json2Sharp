namespace Json2SharpLib.Enums;

/// <summary>
/// Represents the Java serialization annotations supported by Json2Sharp.
/// </summary>
public enum JavaSerializationAnnotation : byte
{
    /// <summary>
    /// No annotation.
    /// </summary>
    NoAnnotation,

    /// <summary>
    /// Jackson serialization annotations.
    /// </summary>
    Jackson,

    /// <summary>
    /// Gson serialization annotations.
    /// </summary>
    Gson,

    /// <summary>
    /// Moshi serialization annotations.
    /// </summary>
    Moshi
}