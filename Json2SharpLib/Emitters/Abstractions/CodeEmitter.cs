using Json2SharpLib.Common;
using Json2SharpLib.Enums;
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
        typeName = (typeAmount is 1 && J2SUtils.TryGetAliasName(childrenTypes[0].BclType, language, out var aliasName))
            ? (aliasName.Equals(J2SUtils.GetAliasName(typeof(object), language), StringComparison.Ordinal))  // CustomType or language alias
                ? className
                : aliasName
            : (typeAmount is 1)    // CustomType or any
                ? className
                : J2SUtils.GetAliasName(typeof(object), language);

        return childrenTypes.Any(x => x.JsonElement.ValueKind is JsonValueKind.Null);
    }
}