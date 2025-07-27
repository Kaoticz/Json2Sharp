using Json2SharpLib.Enums;

namespace Json2SharpLib.Models.LanguageOptions.Abstractions;

/// <summary>
/// Defines the settings all language options should have.
/// </summary>
public abstract record BaseLanguageOptions
{
    private readonly int _indentationCharacterAmount = 4;

    /// <summary>
    /// Defines the character that should prepend member declarations. <br />
    /// Default is <see cref="IndentationCharacterType.Space"/>.
    /// </summary>
    public IndentationCharacterType IndentationPaddingCharacter { get; init; } = IndentationCharacterType.Space;
    
    /// <summary>
    /// Defines a handler that transforms the type name of each parsed property before it is used in generated class
    /// members. Use it to apply custom naming logic to the type name of nested objects. <br />
    /// Default is a function that returns the parsed property name in the language's default naming convention.
    /// </summary>
    public Func<string, string> TypeNameHandler { get; init; } = DefaultTypeNameHandler;

    /// <summary>
    /// Defines the amount of <see cref="IndentationPaddingCharacter"/> that should be prepended to member declarations.
    /// <br />
    /// Default is 4.
    /// </summary>
    public int IndentationCharacterAmount
    {
        get => _indentationCharacterAmount;
        init => _indentationCharacterAmount = (value >= 0)
            ? value
            : throw new ArgumentOutOfRangeException(nameof(IndentationCharacterAmount), value, "Character amount cannot be less than zero.");
    }

    /// <summary>
    /// The default handler for property type names.
    /// </summary>
    /// <param name="propertyName">The name of the parsed property.</param>
    /// <returns>The parsed property name.</returns>
    private static string DefaultTypeNameHandler(string propertyName)
        => propertyName;
}