using Json2SharpLib.Common;
using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using Json2SharpLib.Models.LanguageOptions;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib;

/// <summary>
/// Parses JSON data into a Python data class declaration.
/// </summary>
internal sealed class PythonDataClassEmitter : ICodeEmitter
{
    private int _stackCounter;
    private readonly string _indentationPadding;

    internal PythonDataClassEmitter(Json2SharpPythonOptions options)
    {
        _indentationPadding = new string(
            options.IndentationPaddingCharacter is IndentationCharacterType.Space ? ' ' : '\t',
            options.IndentationCharacterAmount
        );
    }


    /// <inheritdoc />
    public string Parse(string objectName, JsonElement jsonElement)
    {
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        _stackCounter++;

        var stringBuilder = BuildDataClass(objectName, properties, out var extraTypes);

        // Add extra types at the top
        AddCustomTypes(stringBuilder, extraTypes);

        // Add the imports
        if (--_stackCounter == default)
        {
            stringBuilder.Insert(0, "from dataclasses import dataclass" + Environment.NewLine + Environment.NewLine + Environment.NewLine);

            if (stringBuilder.Contains("Optional["))
                stringBuilder.Insert(0, "from typing import Optional" + Environment.NewLine);
        }

        return stringBuilder.ToStringAndClear();
    }


    /// <summary>
    /// Builds the signature of the constructor.
    /// </summary>
    /// <param name="objectName">The name of the class.</param>
    /// <param name="properties">The properties of the class.</param>
    /// <param name="extraTypes">Types that this class depends on.</param>
    /// <returns>A <see cref="StringBuilder"/> with the constructor's signature in it. </returns>
    /// <exception cref="InvalidOperationException">Occurs when no suitable type alias is found.</exception>
    private StringBuilder BuildDataClass(string objectName, IReadOnlyList<ParsedJsonProperty> properties, out List<string> extraTypes)
    {
        var stringBuilder = new StringBuilder();
        extraTypes = [];

        // Class declaration
        stringBuilder.AppendLine("@dataclass");
        stringBuilder.AppendLine($"class {objectName}:");

        foreach (var property in properties)
        {
            var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

            if (HandleCustomType(property, stringBuilder, isNullable, extraTypes))
                continue;

            var type = (J2SUtils.TryGetAliasName(property.BclType, Language.Python, out var aliasName))
                ? (isNullable) ? $"Optional[{aliasName}]" : aliasName
                : throw new InvalidOperationException("Could not get alias for " + property.BclType.Name);

            stringBuilder.AppendIndentedLine($"{property.JsonName}: {type}", _indentationPadding, 1);
        }

        return stringBuilder;
    }


    /// <summary>
    /// Adds custom types at the top of the class definition.
    /// </summary>
    /// <param name="stringBuilder">The string builder with the class definition.</param>
    /// <param name="extraTypes">The types the class in <paramref name="stringBuilder"/> depends on.</param>
    /// <returns><see langword="true"/> if custom types were added, <see langword="false"/> otherwise.</returns>
    private static bool AddCustomTypes(StringBuilder stringBuilder, List<string> extraTypes)
    {
        var sanitizedExtraTypes = extraTypes
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Reverse();

        // Add the custom types at the top
        if (sanitizedExtraTypes.Any())
        {
            stringBuilder.Insert(0, Environment.NewLine + Environment.NewLine);
            stringBuilder.Insert(0, string.Join(Environment.NewLine + Environment.NewLine, sanitizedExtraTypes));

            return true;
        }

        return false;
    }

    /// <summary>
    /// Parses an <see langword="object"/> or <see langword="object[]"/> JSON <paramref name="property"/>.
    /// </summary>
    /// <param name="property">The property to be processed.</param>
    /// <param name="stringBuilder">The string builder used to build the type declaration.</param>
    /// <param name="isNullable">Determines whether the <paramref name="property"/> is nullable or not.</param>
    /// <param name="extraTypes">The list that contains the definitions of custom types in the JSON data.</param>
    /// <returns><see langword="true"/> if <paramref name="property"/> was parsed, <see langword="false"/> otherwise.</returns>
    private bool HandleCustomType(ParsedJsonProperty property, StringBuilder stringBuilder, bool isNullable, List<string> extraTypes)
    {
        if (property.BclType == typeof(object) && property.JsonElement.ValueKind is JsonValueKind.Object)
        {
            using var jsonEnumerator = property.JsonElement.EnumerateObject();
            var typeName = (jsonEnumerator.Any())
                ? J2SUtils.ToPascalCase(property.JsonName)
                : J2SUtils.GetAliasName(typeof(object), Language.Python);

            extraTypes.Add(Parse(J2SUtils.ToPascalCase(property.JsonName!), property.JsonElement));
            stringBuilder.AppendIndentedLine($"{property.JsonName}: {typeName}", _indentationPadding, 1);

            return true;
        }
        else if (property.BclType == typeof(object[]))
        {
            var childrenTypes = property.Children
                .DistinctBy(x => x.JsonElement.ValueKind)
                .ToArray();

            if (childrenTypes.Count(x => x.JsonElement.ValueKind is not JsonValueKind.Null) is 1)
            {
                var className = J2SUtils.ToPascalCase(property.JsonName!);
                var child = childrenTypes.First(x => x.JsonElement.ValueKind is not JsonValueKind.Null);
                var typeName = (childrenTypes.Length is not 1 && J2SUtils.TryGetAliasName(child.BclType, Language.Python, out var aliasName))
                    ? (aliasName.Equals(J2SUtils.GetAliasName(typeof(object), Language.Python), StringComparison.Ordinal))
                        ? className
                        : aliasName  // CustomType or alias
                    : className;     // CustomType or any

                var finalName = (isNullable)
                    ? $"Optional[{typeName}]"
                    : typeName;

                extraTypes.Add(Parse(typeName, childrenTypes[0].JsonElement));
                stringBuilder.AppendIndentedLine($"{property.JsonName}{$": list[{finalName}]"}", _indentationPadding, 1);

                return true;
            }
        }

        return false;
    }
}