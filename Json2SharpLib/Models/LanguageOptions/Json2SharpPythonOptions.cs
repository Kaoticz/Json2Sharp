namespace Json2SharpLib.Models.LanguageOptions;

/// <summary>
/// The parsing options for Python types.
/// </summary>
public sealed record Json2SharpPythonOptions
{
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
    /// <value></value>
    public int IndentationCharacterAmount { get; init; } = 4;

    /// <summary>
    /// Defines whether type hints should be added to the generated code.
    /// Default is <see langword="true"/>.
    /// </summary>
    public bool AddTypeHints { get; init; } = true;
}