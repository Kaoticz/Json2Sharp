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
    /// Removes illegal characters from an object name.
    /// </summary>
    /// <param name="objectName">The name of the object.</param>
    /// <param name="replacement">The string to replace bad characters with.</param>
    /// <returns>The sanitized object name.</returns>
    /// <exception cref="ArgumentNullException">Occurs when <paramref name="replacement"/> is <see langword="null"/>.</exception>
    [return: NotNullIfNotNull(nameof(objectName))]
    public static string? SanitizeObjectName(string? objectName, string replacement = "")
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
    /// Gets the alias for the given <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type to get the alias name from.</param>
    /// <param name="language">The programming language to get the alias from.</param>
    /// <returns>The alias name of <paramref name="type"/>.</returns>
    /// <exception cref="InvalidOperationException">Occurs when the alias is not found.</exception>
    public static string GetAliasName(Type type, Language language)
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
    public static bool TryGetAliasName(Type type, Language language, [MaybeNullWhen(false)] out string aliasName)
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
    public static bool IsPropertyNullable(JsonElement jsonElement)
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
    public static IReadOnlyList<ParsedJsonProperty> GetArrayTypes(ParsedJsonProperty property)
    {
        return (property.BclType != typeof(object[]) || property.Children.Count is 0)
            ? []
            : property.Children
                .DistinctBy(x => x.JsonElement.ValueKind)
                .ToArray();
    }
}