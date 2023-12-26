using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using Json2SharpLib.Models.LanguageOptions;

namespace Json2SharpApp.Handlers;

/// <summary>
/// Contains methods that handle parsing of <see cref="Json2SharpOptions"/>.
/// </summary>
internal sealed class ConfigHandler
{
    /// <summary>
    /// Parses configuration options into a <see cref="Json2SharpOptions"/>.
    /// </summary>
    /// <param name="options">The command-line configuration options.</param>
    /// <returns>The parsed options.</returns>
    public static Json2SharpOptions Handle(IReadOnlyList<string> options)
    {
        var targetLanguage = ParseLanguage(options);

        return (options.Count is 0)
            ? new Json2SharpOptions()
            : new Json2SharpOptions()
            {
                TargetLanguage = targetLanguage,
                CSharpOptions = (targetLanguage is Language.CSharp) ? ParseCSharpOptions(options) : new(),
                PythonOptions = (targetLanguage is Language.Python) ? ParsePythonOptions(options) : new(),
            };
    }

    /// <summary>
    /// Parse the language to convert to.
    /// </summary>
    /// <param name="configOptions">The command-line configuration options.</param>
    /// <returns>The language to convert to.</returns>
    private static Language ParseLanguage(IReadOnlyList<string> configOptions)
    {
        if (configOptions.Any(x => x is "py" or "python"))
            return Language.Python;

        return Language.CSharp;
    }

    /// <summary>
    /// Parse the C# options.
    /// </summary>
    /// <param name="configOptions">The command-line configuration options.</param>
    /// <returns>The parsed C# options.</returns>
    private static Json2SharpCSharpOptions ParseCSharpOptions(IReadOnlyList<string> configOptions)
    {
        return new()
        {
            TargetType = (configOptions.Any(x => x is "class")) ? CSharpObjectType.Class
                : (configOptions.Any(x => x is "struct")) ? CSharpObjectType.Struct
                : CSharpObjectType.Record,

            AccessibilityLevel = (configOptions.Any(x => x is "protected")) ? CSharpAccessibilityLevel.Protected
                : (configOptions.Any(x => x is "internal")) ? CSharpAccessibilityLevel.Internal
                : (configOptions.Any(x => x is "protectedinternal")) ? CSharpAccessibilityLevel.ProtectedInternal
                : (configOptions.Any(x => x is "privateprotected")) ? CSharpAccessibilityLevel.PrivateProtected
                : (configOptions.Any(x => x is "private")) ? CSharpAccessibilityLevel.Private
                : CSharpAccessibilityLevel.Public,

            SerializationAttribute = (configOptions.Any(x => x is "noatt" or "noattribute")) ? CSharpSerializationAttribute.NoAttribute
                : (configOptions.Any(x => x is "ntj" or "newtonsoft" or "newtonsoftjson")) ? CSharpSerializationAttribute.NewtonsoftJson
                : CSharpSerializationAttribute.SystemTextJson,

            SetterType = (configOptions.Any(x => x is "set"))
                ? CSharpSetterType.Set
                : CSharpSetterType.Init,

            IsSealed = !configOptions.Any(x => x is "notsealed"),

            IndentationPadding = (configOptions.Any(x => x is "tab"))
                ? "\t"
                : "    ",
        };
    }

    /// <summary>
    /// Parse the Python options.
    /// </summary>
    /// <param name="configOptions">The command-line configuration options.</param>
    /// <returns>The parsed Python options.</returns>
    private static Json2SharpPythonOptions ParsePythonOptions(IReadOnlyList<string> configOptions)
    {
        var indentationAmountOption = configOptions.FirstOrDefault(x => x.StartsWith("ind:"))?[4..];

        return new()
        {
            AddTypeHints = !configOptions.Any(x => x is "nth" or "notypehints"),

            IndentationCharacterAmount = (int.TryParse(indentationAmountOption, out var indentationAmount))
                ? indentationAmount
                : 4,

            IndentationPaddingCharacter = (configOptions.Any(x => x is "tab"))
                ? Json2SharpLib.IndentationCharacterType.Tab
                : Json2SharpLib.IndentationCharacterType.Space
        };
    }
}