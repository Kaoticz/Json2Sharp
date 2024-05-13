using Json2SharpLib.Common;
using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using Json2SharpLib.Models.LanguageOptions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Emitters.CSharp;

/// <summary>
/// Parses JSON data into a C# type declaration with the base body of a record definition using a primary constructor.
/// </summary>
internal sealed class CSharpRecordEmitter : CodeEmitter
{
    private int _stackCounter = 0;
    private readonly string _accessibility;
    private readonly CSharpSerializationAttribute _serializationAttributeType;
    private readonly string _serializationAttribute;
    private readonly string _indentationPadding;

    /// <summary>
    /// Creates an object that parses JSON data into a C# type declaration with the base body of a record definition using a primary constructor.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal CSharpRecordEmitter(Json2SharpCSharpOptions options)
    {
        _accessibility = options.AccessibilityLevel.ToCode() + (options.IsSealed ? " sealed" : string.Empty);
        _serializationAttributeType = options.SerializationAttribute;
        _serializationAttribute = (options.SerializationAttribute is CSharpSerializationAttribute.SystemTextJson)
            ? "property: " + options.SerializationAttribute.ToCode()
            : options.SerializationAttribute.ToCode();
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

        var extraTypes = new List<string>();
        var stringBuilder = new StringBuilder();

        // Namespace declaration
        if (_stackCounter is 1 && _serializationAttributeType is CSharpSerializationAttribute.SystemTextJson)
            stringBuilder.AppendLine(Constants.StjUsing + Environment.NewLine);
        else if (_stackCounter is 1 && _serializationAttributeType is CSharpSerializationAttribute.NewtonsoftJson)
            stringBuilder.AppendLine(Constants.NewtonsoftUsing + Environment.NewLine);

        stringBuilder.AppendLine($"{_accessibility} record {objectName}(");

        BuildPrimaryCtorArguments(stringBuilder, extraTypes, properties);

        stringBuilder.Append(");");

        // Add extra classes above the root class
        AddCustomTypes(stringBuilder, extraTypes);

        _stackCounter--;

        return stringBuilder.ToStringAndClear();
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        var propertyName = J2SUtils.ToPascalCase(property.JsonName) ?? property.BclType.Name;

        return CreateMemberDeclaration(
            _indentationPadding,
            _serializationAttribute,
            property.JsonName!,
            GetObjectTypeName(property, Language.CSharp),
            propertyName
        );
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var finalName = J2SUtils.ToPascalCase(property.JsonName) ?? property.BclType.Name;
        var propertyType = (IsArrayOfNullableType(property, Language.CSharp, childrenTypes, out typeName))
            ? typeName + "?[]"
            : typeName + "[]";

        return CreateMemberDeclaration(
            _indentationPadding,
            _serializationAttribute,
            property.JsonName!,
            propertyType,
            finalName
        );
    }

    /// <summary>
    /// Builds the constructor arguments in the record definition.
    /// </summary>
    /// <param name="stringBuilder">The string builder that contains the record definition.</param>
    /// <param name="extraTypes">Custom type that this record depends on.</param>
    /// <param name="properties">The properties of the record.</param>
    /// <returns><paramref name="stringBuilder"/> with the record's members added to it.</returns>
    private StringBuilder BuildPrimaryCtorArguments(StringBuilder stringBuilder, List<string> extraTypes, IReadOnlyList<ParsedJsonProperty> properties)
    {
        foreach (var property in properties)
        {
            if (HandleCustomType(property, stringBuilder, extraTypes))
                continue;

            var bclTypeName = J2SUtils.TryGetAliasName(property.BclType, Language.CSharp, out var aliasName)
                ? aliasName
                : property.BclType.Name;

            var nullableAnnotation = (J2SUtils.IsPropertyNullable(property.JsonElement))
                ? "?"
                : string.Empty;

            stringBuilder.AppendLine(
                CreateMemberDeclaration(
                    _indentationPadding,
                    _serializationAttribute,
                    property.JsonName!,
                    (property.JsonElement.ValueKind is not JsonValueKind.Array)
                        ? bclTypeName + nullableAnnotation
                        : string.IsNullOrWhiteSpace(nullableAnnotation) ? bclTypeName : bclTypeName.Insert(bclTypeName.Length - 2, nullableAnnotation),
                    J2SUtils.ToPascalCase(property.JsonName!)
                )
            );
        }

        stringBuilder.Remove(stringBuilder.Length - (Environment.NewLine.Length + 1), 1);   // Remove the last comma

        return stringBuilder;
    }

    /// <summary>
    /// Adds custom types at the bottom of the record definition.
    /// </summary>
    /// <param name="stringBuilder">The string builder with the record definition.</param>
    /// <param name="extraTypes">The types the record in <paramref name="stringBuilder"/> depends on.</param>
    /// <returns><see langword="true"/> if custom types were added, <see langword="false"/> otherwise.</returns>
    private static bool AddCustomTypes(StringBuilder stringBuilder, List<string> extraTypes)
    {
        var sanitizedExtraTypes = extraTypes.Where(x => !string.IsNullOrWhiteSpace(x));

        if (!sanitizedExtraTypes.Any())
            return false;

        stringBuilder.AppendLine(Environment.NewLine);
        stringBuilder.AppendJoin(Environment.NewLine + Environment.NewLine, sanitizedExtraTypes);

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
                var propertyName = J2SUtils.ToPascalCase(property.JsonName) ?? property.BclType.Name;
                extraTypes.Add(Parse(propertyName, property.JsonElement));
                stringBuilder.AppendLine(ParseCustomType(property));

                return true;
            case JsonValueKind.Array:
                var childrenTypes = J2SUtils.GetArrayTypes(property);

                if (childrenTypes.Count is 0)
                    return false;

                stringBuilder.AppendLine(ParseArrayType(property, childrenTypes, out var typeName));

                if (!typeName.Equals(J2SUtils.GetAliasName(typeof(object), Language.CSharp), StringComparison.Ordinal))
                    extraTypes.Add(Parse(typeName, childrenTypes[0].JsonElement));

                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// Creates a member declaration in a primary constructor.
    /// </summary>
    /// <param name="indentationPadding">Text that comes before the declaration.</param>
    /// <param name="serializationAttributeName">The name of the attribute.</param>
    /// <param name="jsonName">The name of the JSON property.</param>
    /// <param name="targetTypeName">The C# type of the property.</param>
    /// <param name="propertyName">The C# name of the property.</param>
    /// <remarks>Example: [JsonProperty("prop_name")] int PropName</remarks>
    /// <returns>The member declaration.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateMemberDeclaration(string indentationPadding, string serializationAttributeName, string jsonName, string targetTypeName, string propertyName)
        => (string.IsNullOrWhiteSpace(serializationAttributeName))
            ? $"{indentationPadding}{targetTypeName} {propertyName},"
            : $"{indentationPadding}[{serializationAttributeName}(\"{jsonName}\")] {targetTypeName} {propertyName},";
}