namespace Json2SharpLib.Enums;

/// <summary>
/// Represents the Java nullability annotations supported by Json2Sharp.
/// </summary>
public enum JavaNullabilityAnnotation : byte
{
    /// <summary>
    /// No annotation.
    /// </summary>
    NoAnnotation,

    /// <summary>
    /// Jakarta validation annotations.
    /// </summary>
    Jakarta,

    /// <summary>
    /// JSpecify nullability annotations.
    /// </summary>
    JSpecify,

    /// <summary>
    /// JetBrains nullability annotations.
    /// </summary>
    JetBrains,

    /// <summary>
    /// Lombok nullability annotations.
    /// </summary>
    Lombok,

    /// <summary>
    /// FindBugs nullability annotations.
    /// </summary>
    FindBugs
}