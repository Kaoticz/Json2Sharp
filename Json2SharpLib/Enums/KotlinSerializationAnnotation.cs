namespace Json2SharpLib.Enums;

/// <summary>
/// Represents the Kotlin serialization annotations supported by Json2Sharp.
/// </summary>
public enum KotlinSerializationAnnotation : byte
{
    /// <summary>
    /// No annotation.
    /// </summary>
    NoAnnotation,

    /// <summary>
    /// Kotlinx serialization annotations.
    /// </summary>
    Kotlinx,

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
