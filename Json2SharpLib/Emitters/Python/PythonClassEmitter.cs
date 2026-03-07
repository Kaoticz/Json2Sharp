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
    internal PythonClassEmitter(Json2SharpPythonOptions options) : base(options.TypeNameHandler)
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
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var stringBuilder = BuildConstructorSignature(objectName, properties, out var extraTypes);

        // Build the body of the constructor
        foreach (var property in properties)
        {
            var sanitizedJsonName = GetSafePropertyName(property.JsonName!, Language.Python);
            var typeHint = (_addTypeHint) ? $": {GetPropertyType(property)}" : string.Empty;
            stringBuilder.AppendIndentedLine($"self.{sanitizedJsonName}{typeHint} = {sanitizedJsonName}", _indentationPadding, 2);
        }

        // Build the from_json() method
        BuildFromJsonMethod(stringBuilder, properties);

        // Add extra classes above the root class
        AddCustomTypes(stringBuilder, extraTypes);

        var result = stringBuilder.ToStringAndClear().TrimEnd();

        if (!emitHeaders)
            return result;

        // Add the imports
        var hasUuid = result.Contains("UUID");
        var hasTimedelta = result.Contains("timedelta");
        var hasDatetime = result.Contains("datetime");
        var hasOptional = result.Contains("Optional[");
        var hasAny = result.Contains("Any");
        var hasSelf = result.Contains("Self");
        var typingModules = new List<string>(3);
        
        if (hasOptional)
            typingModules.Add("Optional");
        if (hasAny)
            typingModules.Add("Any");
        if (hasSelf)
            typingModules.Add("Self");

        if (typingModules.Count > 0)
            stringBuilder.Insert(0, $"from typing import {string.Join(", ", typingModules)}" + Environment.NewLine);

        if (hasTimedelta || hasDatetime)
        {
            var modules = (hasTimedelta && hasDatetime) ? "datetime, timedelta"
                : (hasTimedelta) ? "timedelta"
                : "datetime";

            stringBuilder.AppendLine("from datetime import " + modules);
        }

        if (hasUuid)
            stringBuilder.AppendLine("from uuid import UUID");

        if (stringBuilder.Length > 0)
        {
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
        }

        stringBuilder.Append(result);
        return stringBuilder.ToStringAndClear();

    }

    /// <summary>
    /// Builds the from_json() method.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append the method to.</param>
    /// <param name="properties">The properties of the class.</param>
    private void BuildFromJsonMethod(StringBuilder stringBuilder, IReadOnlyList<ParsedJsonProperty> properties)
    {
        stringBuilder.AppendLine();
        stringBuilder.AppendIndentedLine("@classmethod", _indentationPadding, 1);

        if (_addTypeHint)
        {
            stringBuilder.AppendIndentedLine("def from_json(cls, json_dict: dict[str, Any]) -> Self:", _indentationPadding, 1);
            stringBuilder.AppendIndentedLine("data: dict[str, Any] = {", _indentationPadding, 2);
        }
        else
        {
            stringBuilder.AppendIndentedLine("def from_json(cls, json_dict):", _indentationPadding, 1);
            stringBuilder.AppendIndentedLine("data = {", _indentationPadding, 2);
        }

        foreach (var property in properties)
            stringBuilder.AppendIndentedLine($"'{GetSafePropertyName(property.JsonName!, Language.Python)}': json_dict['{property.JsonName}'],", _indentationPadding, 3);

        stringBuilder.AppendIndentedLine("}", _indentationPadding, 2);
        stringBuilder.AppendLine();
        stringBuilder.AppendIndentedLine("return cls(**data)", _indentationPadding, 2);
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        if (!_addTypeHint)
            return $"{GetSafePropertyName(property.JsonName!, Language.Python)},";

        var typeName = GetObjectTypeName(property, Language.Python);

        return $"{GetSafePropertyName(property.JsonName!, Language.Python)}: {typeName},";
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var typeHint = GetArrayTypeHint(property, childrenTypes, out typeName);
        return $"{GetSafePropertyName(property.JsonName!, Language.Python)}{((_addTypeHint) ? $": {typeHint}" : string.Empty)},";
    }

    /// <summary>
    /// Gets the type hint for an array <paramref name="property"/>.
    /// </summary>
    /// <param name="property">The property to be processed.</param>
    /// <param name="childrenTypes">The unique types present in the array.</param>
    /// <param name="typeName">The type of array that got parsed.</param>
    /// <returns>The type hint.</returns>
    private string GetArrayTypeHint(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var actualChildrenTypes = (childrenTypes.Count is 0)
            ? J2SUtils.GetArrayTypes(property)
            : childrenTypes;

        if (actualChildrenTypes.Count is 0 && property.Children.Count is not 0)
        {
            actualChildrenTypes = property.Children
                .DistinctBy(x => x.JsonElement.ValueKind)
                .ToArray();
        }

        if (actualChildrenTypes.Count is 0)
        {
            typeName = J2SUtils.GetAliasName(typeof(object), Language.Python);
            return $"list[{typeName}]";
        }

        var propertyType = (IsArrayOfNullableType(property, Language.Python, actualChildrenTypes, out typeName))
            ? string.Format(_typeHintNoneTemplate, typeName)
            : typeName;

        return $"list[{propertyType}]";
    }

    /// <summary>
    /// Gets the type hint for the specified <paramref name="property"/>.
    /// </summary>
    /// <param name="property">The property to be processed.</param>
    /// <returns>The type hint.</returns>
    private string GetPropertyType(ParsedJsonProperty property)
    {
        if (property.JsonElement.ValueKind is JsonValueKind.Object)
            return GetObjectTypeName(property, Language.Python);

        if (property.JsonElement.ValueKind is JsonValueKind.Array)
            return GetArrayTypeHint(property, Array.Empty<ParsedJsonProperty>(), out _);

        var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);
        var typeName = J2SUtils.GetAliasName(property.BclType, Language.Python);

        return (isNullable)
            ? string.Format(_typeHintNoneTemplate, typeName)
            : typeName;
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
        stringBuilder.AppendIndentedLine("self,", _indentationPadding, 2);

        foreach (var property in properties)
        {
            var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

            if (HandleCustomType(property, stringBuilder, extraTypes))
                continue;

            var type = (_addTypeHint && J2SUtils.TryGetAliasName(property.BclType, Language.Python, out var aliasName))
                ? ": " + ((isNullable) ? string.Format(_typeHintNoneTemplate, aliasName) : aliasName)
                : string.Empty;

            stringBuilder.AppendIndentedLine($"{GetSafePropertyName(property.JsonName!, Language.Python)}{type},", _indentationPadding, 2);
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
            .Reverse()
            .ToArray();

        if (sanitizedExtraTypes.Length is 0)
            return false;

        // Add the custom types at the top
        stringBuilder.Insert(0, Environment.NewLine + Environment.NewLine + Environment.NewLine);
        stringBuilder.Insert(0, string.Join(Environment.NewLine + Environment.NewLine + Environment.NewLine, sanitizedExtraTypes));

        return true;
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
                extraTypes.Add(InternalParse(GetObjectTypeName(property, Language.Python), property.JsonElement, false));

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