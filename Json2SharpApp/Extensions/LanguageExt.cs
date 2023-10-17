using Json2SharpLib.Enums;
using System.Diagnostics;

namespace Json2SharpApp.Extensions;

internal static class LanguageExt
{
    public static string GetLanguageFileExtension(this Language language)
    {
        return language switch
        {
            Language.CSharp => ".cs",
            _ => throw new UnreachableException($"Extension for language {language} has not been implemented."),
        };
    }
}