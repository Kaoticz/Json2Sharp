using Json2SharpLib.Enums;

namespace Json2SharpLib.Models;

/// <summary>
/// The parsing options for C# types.
/// </summary>
public sealed class Json2SharpCSharpOptions
{
    /// <summary>
    /// The type definition to generate in the output.
    /// Default is <see cref="CSharpObjectType.Record"/>.
    /// </summary>
    public CSharpObjectType TargetType { get; init; } = CSharpObjectType.Record;

    /// <summary>
    /// The accessibility level of the type.
    /// Default is <see cref="CSharpAccessibilityLevel.Public"/>.
    /// </summary>
    public CSharpAccessibilityLevel AccessibilityLevel { get; init; } = CSharpAccessibilityLevel.Public;

    /// <summary>
    /// The library serialization attribute to use.
    /// Default is <see cref="CSharpSerializationAttribute.SystemTextJson"/>.
    /// </summary>
    public CSharpSerializationAttribute SerializationAttribute { get; init; } = CSharpSerializationAttribute.SystemTextJson;

    /// <summary>
    /// The type of setter to be used.
    /// Default is <see cref="CSharpSetterType.Init"/>.
    /// </summary>
    public CSharpSetterType SetterType { get; init; } = CSharpSetterType.Init;

    /// <summary>
    /// Determines whether the type definitions should allow inheritance or not.
    /// Default is <see langword="true"/>.
    /// </summary>
    public bool IsSealed { get; init; } = true;

    /// <summary>
    /// Defines the string that should prepend member declarations.
    /// Default is 4 spaces.
    /// </summary>
    public string IndentationPadding { get; init; } = "    ";
}