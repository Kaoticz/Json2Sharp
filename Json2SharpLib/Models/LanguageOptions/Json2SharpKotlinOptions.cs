using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models.LanguageOptions.Abstractions;

namespace Json2SharpLib.Models.LanguageOptions;

/// <summary>
/// The parsing options for Kotlin types.
/// </summary>
public sealed record Json2SharpKotlinOptions : BaseLanguageOptions
{
    /// <summary>
    /// The serialization annotation to be used. <br />
    /// Default is <see cref="KotlinSerializationAnnotation.Kotlinx"/>.
    /// </summary>
    public KotlinSerializationAnnotation SerializationAnnotation { get; init; } = KotlinSerializationAnnotation.Kotlinx;

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
