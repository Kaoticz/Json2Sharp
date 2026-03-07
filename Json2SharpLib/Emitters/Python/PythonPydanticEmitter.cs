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
/// Parses JSON data into a Python Pydantic class.
/// </summary>
internal sealed class PythonPydanticEmitter : CodeEmitter
{
    private readonly string _indentationPadding;
    private readonly string _typeHintNoneTemplate;

    /// <summary>
    /// Creates an object that parses JSON data into a Python Pydantic class.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal PythonPydanticEmitter(Json2SharpPythonOptions options) : base(options.TypeNameHandler)
    {
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
    /// Parse JSON data into a Python Pydantic class.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <param name="emitHeaders"><see langword="true"/> to include the "imports" at the beginning, <see langword="false"/> otherwise.</param>
    /// <returns>The Python Pydantic class.</returns>
    private string InternalParse(string objectName, JsonElement jsonElement, bool emitHeaders)
    {
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var stringBuilder = BuildClassDeclaration(objectName, properties, out var extraTypes);

        // Add extra classes above the root class
        AddCustomTypes(stringBuilder, extraTypes);

        var result = stringBuilder.ToStringAndClear().TrimEnd();

        // Add the imports
        if (emitHeaders)
        {
            var hasUuid = result.Contains("UUID");
            var hasTimedelta = result.Contains("timedelta");
            var hasDatetime = result.Contains("datetime");
            var hasOptional = result.Contains("Optional[");

            var importsBuilder = new StringBuilder();
            importsBuilder.AppendLine("from pydantic import BaseModel, Field");
            importsBuilder.AppendLine("from typing import Annotated" + ((hasOptional) ? ", Optional" : string.Empty));

            if (hasTimedelta || hasDatetime)
            {
                var modules = (hasTimedelta && hasDatetime) ? "datetime, timedelta"
                    : (hasTimedelta) ? "timedelta"
                    : "datetime";

                importsBuilder.AppendLine("from datetime import " + modules);
            }

            if (hasUuid)
                importsBuilder.AppendLine("from uuid import UUID");

            stringBuilder.Append(importsBuilder);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            stringBuilder.Append(result);

            return stringBuilder.ToStringAndClear();
        }

        return result;
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        var typeName = GetObjectTypeName(property, Language.Python);
        return $"{GetSafePropertyName(property.JsonName!, Language.Python)}: Annotated[{typeName}, Field(alias='{property.JsonName}')]";
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var typeHint = GetArrayTypeHint(property, childrenTypes, out typeName);
        return $"{GetSafePropertyName(property.JsonName!, Language.Python)}: Annotated[{typeHint}, Field(alias='{property.JsonName}')]";
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
    /// Builds the class declaration.
    /// </summary>
    /// <param name="objectName">The name of the class.</param>
    /// <param name="properties">The properties of the class.</param>
    /// <param name="extraTypes">Types that this class depends on.</param>
    /// <returns>A <see cref="StringBuilder"/> with the class declaration in it. </returns>
    private StringBuilder BuildClassDeclaration(string objectName, IReadOnlyList<ParsedJsonProperty> properties, out List<string> extraTypes)
    {
        var stringBuilder = new StringBuilder();
        extraTypes = [];

        // Class declaration
        stringBuilder.AppendLine($"class {objectName}(BaseModel):");

        foreach (var property in properties)
        {
            var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

            if (HandleCustomType(property, stringBuilder, extraTypes))
                continue;

            var type = (J2SUtils.TryGetAliasName(property.BclType, Language.Python, out var aliasName))
                ? ((isNullable) ? string.Format(_typeHintNoneTemplate, aliasName) : aliasName)
                : "object";

            stringBuilder.AppendIndentedLine($"{GetSafePropertyName(property.JsonName!, Language.Python)}: Annotated[{type}, Field(alias='{property.JsonName}')]", _indentationPadding, 1);
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
                stringBuilder.AppendIndentedLine(ParseCustomType(property), _indentationPadding, 1);
                extraTypes.Add(InternalParse(GetObjectTypeName(property, Language.Python), property.JsonElement, false));

                return true;
            case JsonValueKind.Array:
                var childrenTypes = J2SUtils.GetArrayTypes(property);

                if (childrenTypes.Count is 0)
                    return false;

                stringBuilder.AppendIndentedLine(ParseArrayType(property, childrenTypes, out var typeName), _indentationPadding, 1);

                if (!typeName.Equals(J2SUtils.GetAliasName(typeof(object), Language.Python), StringComparison.Ordinal))
                    extraTypes.Add(InternalParse(typeName, childrenTypes[0].JsonElement, false));

                return true;
            default:
                return false;
        }
    }
}
