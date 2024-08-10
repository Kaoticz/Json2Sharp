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
/// Parses JSON data into a Python class.
/// </summary>
internal sealed class PythonClassEmitter : CodeEmitter
{
    private readonly bool _addTypeHint;
    private readonly string _indentationPadding;
    private readonly string _typeHintNoneTemplate;

    /// <summary>
    /// Creates an object that parses JSON data into a Python class.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal PythonClassEmitter(Json2SharpPythonOptions options)
    {
        _addTypeHint = options.AddTypeHints;
        _indentationPadding = new string(
            options.IndentationPaddingCharacter is IndentationCharacterType.Space ? ' ' : '\t',
            options.IndentationCharacterAmount
        );

        _typeHintNoneTemplate = (options.UseOptional)
            ? "Optional[{0}]"
            : "{0} | None";
    }

    /// <inheritdoc />
    public override string Parse(string objectName, JsonElement jsonElement)
        => InternalParse(objectName, jsonElement, true);

    /// <summary>
    /// Parse JSON data into a Python class.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <param name="emitHeaders"><see langword="true"/> to include the "imports" at the beginning, <see langword="false"/> otherwise.</param>
    /// <returns>The Python class.</returns>
    private string InternalParse(string objectName, JsonElement jsonElement, bool emitHeaders)
    {
        objectName = objectName.ToPascalCase();
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var stringBuilder = BuildConstructorSignature(objectName, properties, out var extraTypes);

        // Build the body of the constructor
        foreach (var property in properties)
        {
            var sanitizedJsonName = property.JsonName.ToSnakeCase();
            stringBuilder.AppendIndentedLine($"self.{sanitizedJsonName} = {sanitizedJsonName}", _indentationPadding, 2);
        }

        // Add extra classes above the root class
        AddCustomTypes(stringBuilder, extraTypes);

        // Add the imports
        if (emitHeaders && _addTypeHint)
        {
            var hasUuid = stringBuilder.Contains(": uuid");
            var hasDatetime = stringBuilder.Contains(": datetime");
            var hasOptional = stringBuilder.Contains("Optional[");

            if (hasUuid || hasDatetime || hasOptional)
                stringBuilder.Insert(0, Environment.NewLine + Environment.NewLine);

            if (hasUuid)
                stringBuilder.Insert(0, "import uuid" + Environment.NewLine);

            if (hasDatetime)
                stringBuilder.Insert(0, "from datetime import datetime" + Environment.NewLine);

            if (hasOptional)
                stringBuilder.Insert(0, "from typing import Optional" + Environment.NewLine);
        }

        return stringBuilder.ToStringAndClear();
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        var propertyType = (_addTypeHint)
            ? ": " + GetObjectTypeName(property, Language.Python)
            : string.Empty;

        return $"{property.JsonName.ToSnakeCase()}{propertyType},";
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var propertyType = (IsArrayOfNullableType(property, Language.Python, childrenTypes, out typeName))
            ? string.Format(_typeHintNoneTemplate, typeName)
            : typeName;

        return $"{property.JsonName.ToSnakeCase()}{((_addTypeHint) ? $": list[{propertyType}]" : string.Empty)},";
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
                ? ": " + ((isNullable) ? string.Format(_typeHintNoneTemplate, aliasName) : aliasName)
                : string.Empty;

            stringBuilder.AppendIndentedLine($"{property.JsonName.ToSnakeCase()}{type},", _indentationPadding, 2);
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
                extraTypes.Add(InternalParse(property.JsonName!, property.JsonElement, false));

                return true;
            case JsonValueKind.Array:
                var childrenTypes = J2SUtils.GetArrayTypes(property);

                if (childrenTypes.Count is 0)
                    return false;

                stringBuilder.AppendIndentedLine(ParseArrayType(property, childrenTypes, out var typeName), _indentationPadding, 2);

                if (!typeName.Equals(J2SUtils.GetAliasName(typeof(object), Language.Python), StringComparison.Ordinal))
                    extraTypes.Add(InternalParse(typeName, childrenTypes[0].JsonElement, false));

                return true;
            default:
                return false;
        }
    }
}