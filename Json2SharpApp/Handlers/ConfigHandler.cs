using Json2SharpLib.Enums;
using Json2SharpLib.Models;

namespace Json2SharpApp.Handlers;

internal sealed class ConfigHandler
{
    public static Json2SharpOptions Handle(string[]? options)
    {
        return (options is null || options.Length is 0)
            ? new Json2SharpOptions()
            : new Json2SharpOptions()
            {
                TargetLanguage = ParseLanguage(options),
                CSharp = ParseCSharpOptions(options),
            };
    }

    private static Language ParseLanguage(IReadOnlyList<string> configOptions)
    {
        if (configOptions.Any(x => x is "cs" or "csharp"))
            return Language.CSharp;

        return Language.CSharp;
    }

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