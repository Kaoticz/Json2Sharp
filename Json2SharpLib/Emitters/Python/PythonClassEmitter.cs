using Json2SharpLib.Common;
using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using Json2SharpLib.Models.LanguageOptions;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Emitters.Python;

/// <summary>
/// Parses JSON data into a Python type declaration.
/// </summary>
internal sealed class PythonClassEmitter : CodeEmitter
{
    private int _stackCounter;
    private readonly bool _addTypeHint;
    private readonly string _indentationPadding;

    /// <summary>
    /// Creates an object that parses JSON data into a Python type declaration.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal PythonClassEmitter(Json2SharpPythonOptions options)
    {
        _addTypeHint = options.AddTypeHints;
        _indentationPadding = new string(
            options.IndentationPaddingCharacter is IndentationCharacterType.Space ? ' ' : '\t',
            options.IndentationCharacterAmount
        );
    }

    /// <inheritdoc />
    public override string Parse(string objectName, JsonElement jsonElement)
    {
        objectName = J2SUtils.SanitizeObjectName(objectName);
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        _stackCounter++;

        var stringBuilder = BuildConstructorSignature(objectName, properties, out var extraTypes);

        // Build the body of the constructor
        foreach (var property in properties)
            stringBuilder.AppendIndentedLine($"self.{property.JsonName} = {property.JsonName}", _indentationPadding, 2);

        // Add extra classes above the root class
        AddCustomTypes(stringBuilder, extraTypes);

        // Add the imports
        if (--_stackCounter == default && _addTypeHint && stringBuilder.Contains("Optional["))
            stringBuilder.Insert(0, "from typing import Optional" + Environment.NewLine + Environment.NewLine + Environment.NewLine);

        return stringBuilder.ToStringAndClear();
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        var propertyType = (_addTypeHint)
            ? ": " + GetObjectTypeName(property, Language.Python)
            : string.Empty;

        return $"{property.JsonName}{propertyType},";
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var propertyType = (IsArrayOfNullableType(property, Language.Python, childrenTypes, out typeName))
            ? $"Optional[{typeName}]"
            : typeName;

        return $"{property.JsonName}{((_addTypeHint) ? $": list[{propertyType}]" : string.Empty)},";
    }

    /// <summary>
    /// Builds the signature of the constructor.
    /// </summary>
    /// <param name="objectName">The name of the class.</param>
    /// <param name="properties">The properties of the class.</param>
    /// <param name="extraTypes">Types that this class depends on.</param>
    /// <returns>A <see cref="StringBuilder"/> with the constructor's signature in it. </returns>
    private StringBuilder BuildConstructorSignature(string objectName, IReadOnlyList<ParsedJsonProperty> properties, out List<string> extraTypes)
    {
        var stringBuilder = new StringBuilder();
        extraTypes = [];

        // Class declaration
        stringBuilder.AppendLine($"class {objectName}:");

        // Build the signature of the constructor
        stringBuilder.AppendIndentedLine("def __init__(", _indentationPadding, 1);

        foreach (var property in properties)
        {
            var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

            if (HandleCustomType(property, stringBuilder, extraTypes))
                continue;

            var type = (_addTypeHint && J2SUtils.TryGetAliasName(property.BclType, Language.Python, out var aliasName))
                ? ": " + ((isNullable) ? $"Optional[{aliasName}]" : aliasName)
                : string.Empty;

            stringBuilder.AppendIndentedLine($"{property.JsonName}{type},", _indentationPadding, 2);
        }

        stringBuilder.Remove(stringBuilder.Length - (Environment.NewLine.Length + 1), 1);   // Remove the last comma
        stringBuilder.AppendIndentedLine($"){((_addTypeHint) ? " -> None" : string.Empty)}:", _indentationPadding, 1);

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
    /// <param name="extraTypes">The list that contains the definitions of custom types in the JSON data.</param>
    /// <returns><see langword="true"/> if <paramref name="property"/> was parsed, <see langword="false"/> otherwise.</returns>
    private bool HandleCustomType(ParsedJsonProperty property, StringBuilder stringBuilder, List<string> extraTypes)
    {
        switch (property.JsonElement.ValueKind)
        {
            case JsonValueKind.Object:
                stringBuilder.AppendIndentedLine(ParseCustomType(property), _indentationPadding, 2);
                extraTypes.Add(Parse(J2SUtils.ToPascalCase(property.JsonName!), property.JsonElement));

                return true;
            case JsonValueKind.Array:
                var childrenTypes = J2SUtils.GetArrayTypes(property);

                if (childrenTypes.Count is 0)
                    return false;

                stringBuilder.AppendIndentedLine(ParseArrayType(property, childrenTypes, out var typeName), _indentationPadding, 2);

                if (!typeName.Equals(J2SUtils.GetAliasName(typeof(object), Language.Python), StringComparison.Ordinal))
                    extraTypes.Add(Parse(typeName, childrenTypes[0].JsonElement));

                return true;
            default:
                return false;
        };
    }
}