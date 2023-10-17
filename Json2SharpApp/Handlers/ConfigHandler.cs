using Json2SharpLib.Enums;
using Json2SharpLib.Models;

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
        return (options.Count is 0)
            ? new Json2SharpOptions()
            : new Json2SharpOptions()
            {
                TargetLanguage = ParseLanguage(options),
                CSharp = ParseCSharpOptions(options),
            };
    }

    /// <summary>
    /// Parse the language to convert to.
    /// </summary>
    /// <param name="configOptions">The command-line configuration options.</param>
    /// <returns>The language to convert to.</returns>
    private static Language ParseLanguage(IReadOnlyList<string> configOptions)
    {
        if (configOptions.Any(x => x is "cs" or "csharp"))
            return Language.CSharp;

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
            TargetType = configOptions.Any(x => x is "class") ? CSharpObjectType.Class
                : configOptions.Any(x => x is "struct") ? CSharpObjectType.Struct
                : CSharpObjectType.Record,

            AccessibilityLevel = configOptions.Any(x => x is "protected") ? CSharpAccessibilityLevel.Protected
                : configOptions.Any(x => x is "internal") ? CSharpAccessibilityLevel.Internal
                : configOptions.Any(x => x is "protectedinternal") ? CSharpAccessibilityLevel.ProtectedInternal
                : configOptions.Any(x => x is "privateprotected") ? CSharpAccessibilityLevel.PrivateProtected
                : configOptions.Any(x => x is "private") ? CSharpAccessibilityLevel.Private
                : CSharpAccessibilityLevel.Public,

            SerializationAttribute = configOptions.Any(x => x is "ntj" or "newtonsoft" or "newtonsoftjson")
                ? CSharpSerializationAttribute.NewtonsoftJson
                : CSharpSerializationAttribute.SystemTextJson,

            SetterType = configOptions.Any(x => x is "set")
                ? CSharpSetterType.Set
                : CSharpSetterType.Init,

            IsSealed = !configOptions.Any(x => x is "notsealed"),

            IndentationPadding = configOptions.Any(x => x is "tab")
                ? "\t"
                : "    ",
        };
    }
}