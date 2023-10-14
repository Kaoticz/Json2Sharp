namespace Json2SharpLib.Enums;

/// <summary>
/// Represents the possible object types in the C# language.
/// </summary>
public enum CSharpObjectType : byte
{
    /// <summary>
    /// A class.
    /// </summary>
    Class,

    /// <summary>
    /// A record.
    /// </summary>
    Record,

    /// <summary>
    /// A struct.
    /// </summary>
    Struct
}