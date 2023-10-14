namespace Json2SharpLib.Enums;

/// <summary>
/// Represents the possible setter types for a C# property.
/// </summary>
public enum CSharpSetterType : byte
{
    /// <summary>
    /// A regular setter.
    /// </summary>
    Set,

    /// <summary>
    /// An init setter.
    /// </summary>
    Init
}