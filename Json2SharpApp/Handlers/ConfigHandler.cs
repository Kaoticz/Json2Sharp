using Json2SharpApp.Common;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using Json2SharpLib.Models.LanguageOptions;
using System.Diagnostics.CodeAnalysis;

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
    /// <param name="result">The parsed options or <see langword="null"/> if parsing failed.</param>
    /// <param name="exception">The exception thrown during parsing or <see langword="null"/> if parsing was successfull.</param>
    /// <returns><see langword="true"/> if the options were parsed successfully, <see langword="false"/> otherwise.</returns>
    public static bool Handle(IReadOnlyList<string> options, [MaybeNullWhen(false)] out Json2SharpOptions result, [MaybeNullWhen(true)] out Exception exception)
    {
        try
        {
            var targetLanguage = ParseLanguage(options);
            exception = null;
            result = (options.Count is 0)
                ? new Json2SharpOptions()
                : new Json2SharpOptions()
                {
                    TargetLanguage = targetLanguage,
                    CSharpOptions = (targetLanguage is Language.CSharp) ? ParseCSharpOptions(options) : new(),
                    PythonOptions = (targetLanguage is Language.Python) ? ParsePythonOptions(options) : new(),
                    JavaOptions = (targetLanguage is Language.Java) ? ParseJavaOptions(options) : new(),
                    KotlinOptions = (targetLanguage is Language.Kotlin) ? ParseKotlinOptions(options) : new(),
                };

            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            result = null;
            return false;
        }
    }

    /// <summary>
    /// Parse the language to convert to.
    /// </summary>
    /// <param name="configOptions">The command-line configuration options.</param>
    /// <returns>The language to convert to.</returns>
    private static Language ParseLanguage(IReadOnlyList<string> configOptions)
    {
        return configOptions.Any(x => x is "py" or "python") ? Language.Python
            : configOptions.Any(x => x is "java") ? Language.Java
            : configOptions.Any(x => x is "kt" or "kotlin") ? Language.Kotlin
            : Language.CSharp;
    }

    /// <summary>
    /// Parse the C# options.
    /// </summary>
    /// <param name="configOptions">The command-line configuration options.</param>
    /// <returns>The parsed C# options.</returns>
    private static Json2SharpCSharpOptions ParseCSharpOptions(IReadOnlyList<string> configOptions)
    {
        var indentationAmountOption = configOptions.FirstOrDefault(x => x.StartsWith("ind:", StringComparison.Ordinal))?[4..];

        return new()
        {
            TargetType = CSharpStatics.ObjectTypes.GetValueOrDefault(
                configOptions.FirstOrDefault(CSharpStatics.ObjectTypes.ContainsKey) ?? "record"
            ),

            AccessibilityLevel = CSharpStatics.AccessibilityLevels.GetValueOrDefault(
                configOptions.FirstOrDefault(CSharpStatics.AccessibilityLevels.ContainsKey) ?? "public"
            ),

            SerializationAttribute = CSharpStatics.SerializationAttributes.GetValueOrDefault(
                configOptions.FirstOrDefault(CSharpStatics.SerializationAttributes.ContainsKey) ?? "systemtextjson"
            ),

            SetterType = (configOptions.Contains("set"))
                ? CSharpSetterType.Set
                : CSharpSetterType.Init,

            IndentationCharacterAmount = (int.TryParse(indentationAmountOption, out var indentationAmount))
                ? indentationAmount
                : 4,

            IndentationPaddingCharacter = (configOptions.Contains("tab"))
                ? IndentationCharacterType.Tab
                : IndentationCharacterType.Space,

            IsSealed = !configOptions.Contains("notsealed"),

            IsPropertyRequired = !configOptions.Contains("notrequired")
        };
    }

    /// <summary>
    /// Parse the Python options.
    /// </summary>
    /// <param name="configOptions">The command-line configuration options.</param>
    /// <returns>The parsed Python options.</returns>
    private static Json2SharpPythonOptions ParsePythonOptions(IReadOnlyList<string> configOptions)
    {
        var indentationAmountOption = configOptions.FirstOrDefault(x => x.StartsWith("ind:", StringComparison.Ordinal))?[4..];

        return new()
        {
            AddTypeHints = !configOptions.Any(x => x is "nth" or "notypehints"),
            TargetType = configOptions.Any(x => x is "pyd" or "pydantic") ? PythonObjectType.Pydantic
                : configOptions.Any(x => x is "class" ) ? PythonObjectType.Class
                : PythonObjectType.DataClass,
            UseOptional = configOptions.Any(x => x is "opt" or "optional"),

            IndentationCharacterAmount = (int.TryParse(indentationAmountOption, out var indentationAmount))
                ? indentationAmount
                : 4,

            IndentationPaddingCharacter = (configOptions.Contains("tab"))
                ? IndentationCharacterType.Tab
                : IndentationCharacterType.Space,
        };
    }

    /// <summary>
    /// Parse the Java options.
    /// </summary>
    /// <param name="configOptions">The command-line configuration options.</param>
    /// <returns>The parsed Java options.</returns>
    private static Json2SharpJavaOptions ParseJavaOptions(IReadOnlyList<string> configOptions)
    {
        var indentationAmountOption = configOptions.FirstOrDefault(x => x.StartsWith("ind:", StringComparison.Ordinal))?[4..];

        return new()
        {
            SerializationAnnotation = JavaStatics.SerializationAnnotations.GetValueOrDefault(
                configOptions.FirstOrDefault(JavaStatics.SerializationAnnotations.ContainsKey) ?? "jackson"
            ),

            NullabilityAnnotation = JavaStatics.NullabilityAnnotations.GetValueOrDefault(
                configOptions.FirstOrDefault(JavaStatics.NullabilityAnnotations.ContainsKey) ?? "nonullability"
            ),

            UseRecord = !configOptions.Contains("class"),

            IndentationCharacterAmount = (int.TryParse(indentationAmountOption, out var indentationAmount))
                ? indentationAmount
                : 4,

            IndentationPaddingCharacter = (configOptions.Contains("tab"))
                ? IndentationCharacterType.Tab
                : IndentationCharacterType.Space,
        };
    }

    /// <summary>
    /// Parse the Kotlin options.
    /// </summary>
    /// <param name="configOptions">The command-line configuration options.</param>
    /// <returns>The parsed Kotlin options.</returns>
    private static Json2SharpKotlinOptions ParseKotlinOptions(IReadOnlyList<string> configOptions)
    {
        var indentationAmountOption = configOptions.FirstOrDefault(x => x.StartsWith("ind:", StringComparison.Ordinal))?[4..];

        return new()
        {
            SerializationAnnotation = KotlinStatics.SerializationAnnotations.GetValueOrDefault(
                configOptions.FirstOrDefault(KotlinStatics.SerializationAnnotations.ContainsKey) ?? "kotlinx"
            ),

            IndentationCharacterAmount = (int.TryParse(indentationAmountOption, out var indentationAmount))
                ? indentationAmount
                : 4,

            IndentationPaddingCharacter = (configOptions.Contains("tab"))
                ? IndentationCharacterType.Tab
                : IndentationCharacterType.Space,
        };
    }
}