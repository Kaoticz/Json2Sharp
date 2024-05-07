using Json2SharpLib.Enums;

namespace Json2SharpLib.Models.LanguageOptions.Abstractions;

/// <summary>
/// Defines the settings all language options should have.
/// </summary>
public abstract record BaseLanguageOptions
{
    private int _indentationCharacterAmount = 4;

    /// <summary>
    /// Defines the character that should prepend member declarations.
    /// Default is <see cref="IndentationCharacterType.Space"/>.
    /// </summary>
    public IndentationCharacterType IndentationPaddingCharacter { get; init; } = IndentationCharacterType.Space;

    /// <summary>
    /// Defines the amount of <see cref="IndentationPaddingCharacter"/> that should
    /// be prepended to member declarations.
    /// Default is 4.
    /// </summary>
    public int IndentationCharacterAmount
    {
        get => _indentationCharacterAmount;
        init => _indentationCharacterAmount = (value >= 0)
            ? value
            : throw new ArgumentOutOfRangeException(nameof(IndentationCharacterAmount), value, "Character amount cannot be less than zero.");
    }
}