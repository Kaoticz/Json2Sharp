using Json2SharpLib.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Common;

/// <summary>
/// Json2Sharp utility methods.
/// </summary>
internal static class J2SUtils
{
    /// <summary>
    /// Converts a string to the PascalCase format.
    /// </summary>
    /// <param name="text">The string to be converted.</param>
    /// <returns>The <paramref name="text"/> in PascalCase format.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    internal static string? ToPascalCase(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        var stringBuilder = new StringBuilder(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text))
            .Replace("_", string.Empty);

        var result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }

    /// <summary>
    /// Attempts to get the alias for the given <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type to get the alias name from.</param>
    /// <param name="language">The programming language to get the alias from.</param>
    /// <param name="aliasName">The alias name of <paramref name="type"/>.</param>
    /// <returns><see langword="true"/> if the alias was successfully found, <see langword="false"/> otherwise.</returns>
    internal static bool TryGetAliasName(Type type, Language language, [MaybeNullWhen(false)] out string aliasName)
    {
        if ((language is Language.CSharp && TypeAliases.CSharpAliasTypes.TryGetValue(type, out aliasName))
            || (language is Language.Python && TypeAliases.PythonAliasTypes.TryGetValue(type, out aliasName)))
            return true;

        aliasName = default;
        return false;
    }

    /// <summary>
    /// Checks if the specified <paramref name="jsonElement"/> can be <see langword="null"/>.
    /// </summary>
    /// <param name="jsonElement">The Json element to check.</param>
    /// <returns><see langword="true"/> if <paramref name="jsonElement"/> can be <see langword="null"/>, <see langword="false"/> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsPropertyNullable(JsonElement jsonElement)
        => (jsonElement.ValueKind is JsonValueKind.Null
            || (jsonElement.ValueKind is JsonValueKind.Array && jsonElement.EnumerateArray().Any(x => x.ValueKind is JsonValueKind.Null)));
}