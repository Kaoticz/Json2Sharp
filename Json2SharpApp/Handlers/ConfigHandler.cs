using Json2SharpApp.Common;
using Json2SharpLib;
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
            TargetType = CSharpStatics.ObjectTypes.GetValueOrDefault(
                configOptions.FirstOrDefault(x => CSharpStatics.ObjectTypes.ContainsKey(x)) ?? "record"
            ),

            AccessibilityLevel = CSharpStatics.AccessibilityLevels.GetValueOrDefault(
                configOptions.FirstOrDefault(x => CSharpStatics.AccessibilityLevels.ContainsKey(x)) ?? "public"
            ),

            SerializationAttribute = CSharpStatics.SerializationAttributes.GetValueOrDefault(
                configOptions.FirstOrDefault(x => CSharpStatics.SerializationAttributes.ContainsKey(x)) ?? "systemtextjson"
            ),

            SetterType = (configOptions.Contains("set"))
                ? CSharpSetterType.Set
                : CSharpSetterType.Init,

            IsSealed = !configOptions.Contains("notsealed"),

            IndentationPadding = (configOptions.Contains("tab"))
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
            UseDataClass = !configOptions.Any(x => x is "ndc" or "nodataclass"),

            IndentationCharacterAmount = (int.TryParse(indentationAmountOption, out var indentationAmount))
                ? indentationAmount
                : 4,

            IndentationPaddingCharacter = (configOptions.Contains("tab"))
                ? IndentationCharacterType.Tab
                : IndentationCharacterType.Space,
        };
    }
}