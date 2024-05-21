using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Common;

/// <summary>
/// Json2Sharp utility methods.
/// </summary>
internal static class J2SUtils
{
    private static readonly FrozenDictionary<Type, string> _emptyAliasTypes = new Dictionary<Type, string>(0).ToFrozenDictionary();

    /// <summary>
    /// Removes illegal characters from a object name.
    /// </summary>
    /// <param name="objectName">The name of the object.</param>
    /// <param name="replacement">The string to replace bad characters with.</param>
    /// <returns>The sanitized object name.</returns>
    /// <exception cref="ArgumentNullException">Occurs when <paramref name="replacement"/> is <see langword="null"/>.</exception>
    [return: NotNullIfNotNull(nameof(objectName))]
    internal static string? SanitizeObjectName(string? objectName, string replacement = "")
    {
        ArgumentNullException.ThrowIfNull(replacement, nameof(replacement));

        if (string.IsNullOrWhiteSpace(objectName))
            return objectName;

        var stringBuilder = new StringBuilder();
        var hasInvalidChar = false;

        foreach (var letter in objectName.AsSpan())
        {
            if (char.IsLetterOrDigit(letter))
                stringBuilder.Append(letter);
            else
            {
                hasInvalidChar = true;
                stringBuilder.Append(replacement);
            }
        }

        if (hasInvalidChar)
            return stringBuilder.ToStringAndClear();

        stringBuilder.Clear();
        return objectName;
    }

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

        var textSpan = text.AsSpan();
        var result = new StringBuilder();
        var isNewWord = true;

        for (var index = 0; index < textSpan.Length; index++)
        {
            var currentChar = textSpan[index];

            if (!char.IsLetterOrDigit(currentChar))
            {
                isNewWord = true;
                continue;
            }

            if (isNewWord)
            {
                result.Append(char.ToUpperInvariant(currentChar));
                isNewWord = false;
            }
            else
            {
                result.Append(
                    (index < text.Length - 1 && char.IsUpper(currentChar) && char.IsLower(text[index + 1]))
                        ? currentChar
                        : char.ToLowerInvariant(currentChar)
                );
            }

            isNewWord &= index < text.Length - 1 && char.IsLower(text[index]) && char.IsUpper(text[index + 1]);
        }

        return result.ToStringAndClear();
    }

    /// <summary>
    /// Converts a string to the "snake_case" format.
    /// </summary>
    /// <param name="text">This string.</param>
    /// <param name="joinSpaces"><see langword="true"/> to convert all empty spaces to underlines, <see langword="false"/> to leave them alone.</param>
    /// <returns>This <see cref="string"/> converted to snake_case.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public static string? ToSnakeCase(string? text, bool joinSpaces = true)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        text = SanitizeObjectName(text, "_");
        var textSpan = text.AsSpan();
        var buffer = new StringBuilder();

        for (var index = 0; index < textSpan.Length; index++)
        {
            var chainLength = UpperChainLength(textSpan, index);

            if (chainLength <= 0)
            {
                buffer.Append(char.ToLowerInvariant(textSpan[index]));
                continue;
            }

            buffer.Append('_');

            foreach (var upperLetter in textSpan.Slice(index, chainLength))
                buffer.Append(char.ToLowerInvariant(upperLetter));

            index += chainLength - 1;
        }

        while (buffer[0] is '_')
            buffer.Remove(0, 1);

        while (buffer[^1] is '_')
            buffer.Remove(buffer.Length - 1, 1);

        buffer.Replace(" _", " ")
            .Replace("_ ", "_");

        if (joinSpaces)
            buffer.Replace(' ', '_');

        buffer.ReplaceAll("__", "_");

        return buffer.ToStringAndClear();
    }

    /// <summary>
    /// Gets the alias for the given <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type to get the alias name from.</param>
    /// <param name="language">The programming language to get the alias from.</param>
    /// <returns>The alias name of <paramref name="type"/>.</returns>
    /// <exception cref="InvalidOperationException">Occurs when the alias is not found.</exception>
    internal static string GetAliasName(Type type, Language language)
    {
        return (TryGetAliasName(type, language, out var aliasName))
            ? aliasName
            : throw new InvalidOperationException($"There is no alias associated with the {type.Name} BCL type for the {language} language.");
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
        var aliases = language switch
        {
            Language.CSharp => TypeAliases.CSharpAliasTypes,
            Language.Python => TypeAliases.PythonAliasTypes,
            _ => _emptyAliasTypes
        };

        return aliases.TryGetValue(type, out aliasName);
    }

    /// <summary>
    /// Checks if the specified <paramref name="jsonElement"/> can be <see langword="null"/>.
    /// </summary>
    /// <param name="jsonElement">The Json element to check.</param>
    /// <returns><see langword="true"/> if <paramref name="jsonElement"/> can be <see langword="null"/>, <see langword="false"/> otherwise.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsPropertyNullable(JsonElement jsonElement)
    {
        if (jsonElement.ValueKind is JsonValueKind.Null)
            return true;
        else if (jsonElement.ValueKind is JsonValueKind.Array)
        {
            using var jsonEnumerator = jsonElement.EnumerateArray();
            return jsonEnumerator.Any(x => x.ValueKind is JsonValueKind.Null);
        }

        return false;
    }

    /// <summary>
    /// Gets the unique types in the specified array <paramref name="property"/>.
    /// </summary>
    /// <param name="property">The property to get the types from.</param>
    /// <returns>The unique types of properties in this Json array, or an empty collection if this property is not an array or empty.</returns>
    internal static IReadOnlyList<ParsedJsonProperty> GetArrayTypes(ParsedJsonProperty property)
    {
        return (property.BclType != typeof(object[]) || property.Children.Count is 0)
            ? []
            : property.Children
                .DistinctBy(x => x.JsonElement.ValueKind)
                .ToArray();
    }

    /// <summary>
    /// Returns the length of an "ALL CAPS" substring in the specified span.
    /// </summary>
    /// <param name="text">The span to check.</param>
    /// <param name="startIndex">The index where the substring starts.</param>
    /// <returns>The length of the substring.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Occurs when <paramref name="startIndex"/> is greater than the length of the span.</exception>
    private static int UpperChainLength(ReadOnlySpan<char> text, int startIndex)
    {
        if (startIndex > text.Length - 1)
            throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, "Start index cannot be greater than length of the span.");
        else if (text.Length is 0)
            return 0;
        else if (startIndex < 0)
            startIndex = 0;

        var result = 0;

        for (var count = startIndex; count < text.Length; count++)
        {
            if (!char.IsLetter(text[count]) || char.IsLower(text[count]))
                break;

            result++;
        }

        return result;
    }
}