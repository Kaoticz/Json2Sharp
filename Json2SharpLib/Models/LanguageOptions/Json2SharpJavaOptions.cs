using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models.LanguageOptions.Abstractions;

namespace Json2SharpLib.Models.LanguageOptions;

/// <summary>
/// The parsing options for Java types.
/// </summary>
public sealed record Json2SharpJavaOptions : BaseLanguageOptions
{
    /// <summary>
    /// The serialization annotation to be used. <br />
    /// Default is <see cref="JavaSerializationAnnotation.Jackson"/>.
    /// </summary>
    public JavaSerializationAnnotation SerializationAnnotation { get; init; } = JavaSerializationAnnotation.Jackson;

    /// <summary>
    /// The nullability annotation to be used. <br />
    /// Default is <see cref="JavaNullabilityAnnotation.NoAnnotation"/>.
    /// </summary>
    public JavaNullabilityAnnotation NullabilityAnnotation { get; init; } = JavaNullabilityAnnotation.NoAnnotation;

    /// <summary>
    /// Defines whether the emitted class should be a Java record. <br />
    /// Default is <see langword="true"/>.
    /// </summary>
    public bool UseRecord { get; init; } = true;

    /// <summary>
    /// The character to be used for indentation. <br />
    /// Default is <see cref="IndentationCharacterType.Space"/>.
    /// </summary>
    public new IndentationCharacterType IndentationPaddingCharacter { get; init; } = IndentationCharacterType.Space;

    /// <summary>
    /// The amount of characters to be used for indentation. <br />
    /// Default is 4.
    /// </summary>
    public new int IndentationCharacterAmount { get; init; } = 4;

    /// <inheritdoc />
    public override Func<string, string> TypeNameHandler { get; init; } = static propertyName => propertyName.ToPascalCase();
}