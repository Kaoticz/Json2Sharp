using Json2SharpLib.Models.LanguageOptions.Abstractions;

namespace Json2SharpLib.Models.LanguageOptions;

/// <summary>
/// The parsing options for Python types.
/// </summary>
public sealed record Json2SharpPythonOptions : BaseLanguageOptions
{
    /// <summary>
    /// Defines whether type hints should be added to the generated code. <br />
    /// Default is <see langword="true"/>.
    /// </summary>
    public bool AddTypeHints { get; init; } = true;

    /// <summary>
    /// Defines whether the emitted class should be a Python data class. <br />
    /// Default is <see langword="true"/>.
    /// </summary>
    public bool UseDataClass { get; init; } = true;

    /// <summary>
    /// Defines whether the emitted class should use "Optional" from the "typing" module. <br />
    /// Default is <see langword="false"/>.
    /// </summary>
    public bool UseOptional { get; init; }

    /// <inheritdoc />
    public override Func<string, string> TypeNameHandler { get; init; } = static propertyName => propertyName.ToPascalCase();
}