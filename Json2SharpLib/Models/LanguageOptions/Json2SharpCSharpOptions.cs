using Json2SharpLib.Enums;
using Json2SharpLib.Models.LanguageOptions.Abstractions;

namespace Json2SharpLib.Models.LanguageOptions;

/// <summary>
/// The parsing options for C# types.
/// </summary>
public sealed record Json2SharpCSharpOptions : BaseLanguageOptions
{
    /// <summary>
    /// The type definition to generate in the output. <br />
    /// Default is <see cref="CSharpObjectType.Record"/>.
    /// </summary>
    public CSharpObjectType TargetType { get; init; } = CSharpObjectType.Record;

    /// <summary>
    /// The accessibility level of the type. <br />
    /// Default is <see cref="CSharpAccessibilityLevel.Public"/>.
    /// </summary>
    public CSharpAccessibilityLevel AccessibilityLevel { get; init; } = CSharpAccessibilityLevel.Public;

    /// <summary>
    /// The library serialization attribute to use. <br />
    /// Default is <see cref="CSharpSerializationAttribute.SystemTextJson"/>.
    /// </summary>
    public CSharpSerializationAttribute SerializationAttribute { get; init; } = CSharpSerializationAttribute.SystemTextJson;

    /// <summary>
    /// The type of setter to be used. <br />
    /// Default is <see cref="CSharpSetterType.Init"/>.
    /// </summary>
    public CSharpSetterType SetterType { get; init; } = CSharpSetterType.Init;

    /// <summary>
    /// Determines whether the type definitions should allow inheritance or not. <br />
    /// Default is <see langword="true"/>.
    /// </summary>
    public bool IsSealed { get; init; } = true;

    /// <summary>
    /// Determines whether the type properties should be required or not. <br />
    /// Default is <see langword="true"/>.
    /// </summary>
    public bool IsPropertyRequired { get; init; } = true;
    
    /// <inheritdoc />
    public override Func<string, string> TypeNameHandler { get; init; } = static propertyName => propertyName.ToPascalCase();
}