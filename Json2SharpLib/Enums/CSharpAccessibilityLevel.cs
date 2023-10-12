namespace Json2SharpLib.Enums;

/// <summary>
/// Represents the level of accessibility a C# class member can have.
/// </summary>
public enum CSharpAccessibilityLevel : byte
{
    /// <summary>
    /// Access is not restricted.
    /// </summary>
    Public,

    /// <summary>
    /// Access is limited to the containing class or types derived from the containing class.
    /// </summary>
    Protected,

    /// <summary>
    /// Access is limited to the current assembly.
    /// </summary>
    Internal,

    /// <summary>
    /// Access is limited to the current assembly or types derived from the containing class.
    /// </summary>
    ProtectedInternal,

    /// <summary>
    /// Access is limited to the containing type.
    /// </summary>
    Private,

    /// <summary>
    /// Access is limited to the containing class or types derived from the containing class within the current assembly.
    /// </summary>
    PrivateProtected
}