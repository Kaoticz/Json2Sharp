using Json2SharpLib.Common;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using System.Text.Json;

namespace Json2SharpLib.Emitters.Abstractions;

/// <summary>
/// Represents a language code emitter. 
/// </summary>
internal abstract class CodeEmitter : ICodeEmitter
{
    /// <inheritdoc />
    public abstract string Parse(string objectName, JsonElement jsonElement);

    /// <summary>
    /// Parses a Json object.
    /// </summary>
    /// <param name="property">The Json property to be parsed.</param>
    /// <returns>The parsed Json <paramref name="property"/>.</returns>
    /// <exception cref="ArgumentException">Occurs when <paramref name="property"/> is not a Json object.</exception>
    protected abstract string ParseCustomType(ParsedJsonProperty property);

    /// <summary>
    /// Parses a Json array.
    /// </summary>
    /// <param name="property">The Json property to be parsed.</param>
    /// <param name="childrenTypes">The unique types present in the array.</param>
    /// <param name="typeName">The type of array that got parsed.</param>
    /// <returns>The parsed Json <paramref name="property"/>.</returns>
    /// <exception cref="ArgumentException">Occurs when <paramref name="childrenTypes"/> is empty.</exception>
    protected abstract string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName);

    /// <summary>
    /// Gets the type name of the specified Json object.
    /// </summary>
    /// <param name="property">The Json property to be parsed.</param>
    /// <param name="language">The target language for the type name.</param>
    /// <returns>The type name.</returns>
    /// <exception cref="InvalidOperationException">Occurs when <paramref name="property"/> is not of type <see cref="JsonValueKind.Object"/>.</exception>
    protected static string GetObjectTypeName(ParsedJsonProperty property, Language language)
    {
        using var jsonEnumerator = property.JsonElement.EnumerateObject();
        return (jsonEnumerator.Any())
            ? J2SUtils.ToPascalCase(property.JsonName!)
            : J2SUtils.GetAliasName(typeof(object), language);
    }

    /// <summary>
    /// Checks if the array property contains <see langword="null"/> elements and returns its <paramref name="typeName"/>. 
    /// </summary>
    /// <param name="property">The property to be checked.</param>
    /// <param name="language">The target language for the type name.</param>
    /// <param name="childrenTypes">The unique types present in the array.</param>
    /// <param name="typeName">The type of array that got parsed.</param>
    /// <returns><see langword="true"/> if the array contains <see langword="null"/> elements, <see langword="false"/> otherwise.</returns>
    /// <exception cref="ArgumentException">Occurs when <paramref name="childrenTypes"/> is empty.</exception>
    /// <exception cref="InvalidOperationException">Occurs when <paramref name="property"/> is not of type <see cref="JsonValueKind.Array"/>.</exception>
    protected static bool IsArrayOfNullableType(ParsedJsonProperty property, Language language, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        if (childrenTypes.Count is 0)
            throw new ArgumentException("Collection cannot be empty.", nameof(childrenTypes));

        var className = J2SUtils.ToPascalCase(property.JsonName!);
        var typeAmount = childrenTypes.Count(x => x.JsonElement.ValueKind is not JsonValueKind.Null);

        // If there is more than 1 type in the array
        typeName = (typeAmount > 1 || IsArrayOfMultipleObjects(property))
            ? J2SUtils.GetAliasName(typeof(object), language)   // Array type is object language type
            : (
                TypeAmount: typeAmount,
                HasLanguageAlias: J2SUtils.TryGetAliasName(
                    (childrenTypes.FirstOrDefault(x => x.JsonElement.ValueKind is not JsonValueKind.Null) ?? childrenTypes[0]).BclType,
                    language,
                    out var aliasName
                ),
                IsCustomType: aliasName?.Equals(J2SUtils.GetAliasName(typeof(object), language), StringComparison.Ordinal)
            ) switch    // Else
            {
                (1, true, true) => className,   // Array type is custom type
                (1, true, false) => aliasName,  // Array type is non-object language type
                (1, false, _) => className,     // Array type is custom type
                _ => J2SUtils.GetAliasName(typeof(object), language),   // Array type is object language type
            };

        return childrenTypes.Any(x => x.JsonElement.ValueKind is JsonValueKind.Null);
    }

    /// <summary>
    /// Checks if the specified <paramref name="property"/> is an array that contains objects of different types.
    /// </summary>
    /// <param name="property">The Json property.</param>
    /// <returns><see langword="true"/> if there are objects of different types, <see langword="false"/> otherwise.</returns>
    private static bool IsArrayOfMultipleObjects(ParsedJsonProperty property)
    {
        if (property.JsonElement.ValueKind is not JsonValueKind.Array)
            return false;

        var objectTypes = property.Children
            .Where(x => x.JsonElement.ValueKind is JsonValueKind.Object and not JsonValueKind.Null)
            .ToArray();

        return objectTypes.Length is not 0 && !objectTypes.All(x => objectTypes.Where(y => y != x).All(y => y.JsonElement.SameTypeAs(x.JsonElement)));
    }
}