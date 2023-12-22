using Json2SharpLib.Enums;
using System.Diagnostics;

namespace Json2SharpApp.Extensions;

/// <summary>
/// Provides extension methods for <see cref="Language"/>.
/// </summary>
internal static class LanguageExt
{
    /// <summary>
    /// Gets the file extension associated with this <paramref name="language"/>.
    /// </summary>
    /// <param name="language">This language.</param>
    /// <returns>The file extension for this <paramref name="language"/>.</returns>
    /// <exception cref="UnreachableException">Occurs when a language has no file extension.</exception>
    public static string GetLanguageFileExtension(this Language language)
    {
        return language switch
        {
            Language.CSharp => ".cs",
            Language.Python => ".py",
            _ => throw new UnreachableException($"Extension for language {language} has not been implemented."),
        };
    }
}