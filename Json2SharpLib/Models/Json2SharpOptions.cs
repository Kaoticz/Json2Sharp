using Json2SharpLib.Enums;
using Json2SharpLib.Models.LanguageOptions;

namespace Json2SharpLib.Models;

/// <summary>
/// Parsing options for Json2Sharp.
/// </summary>
public sealed record Json2SharpOptions
{
    /// <summary>
    /// The language the type declaration should be output to.
    /// Default is <see cref="Language.CSharp"/>.
    /// </summary>
    public Language TargetLanguage { get; set; } = Language.CSharp;

    /// <summary>
    /// Parsing options for the C# language.
    /// </summary>
    public Json2SharpCSharpOptions CSharpOptions { get; init; } = new();

    /// <summary>
    /// Parsing options for the Python language.
    /// </summary>
    public Json2SharpPythonOptions PythonOptions { get; init; } = new();
}