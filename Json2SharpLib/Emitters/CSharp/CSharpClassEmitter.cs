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
/// Parses JSON data into a C# struct, class, or record with the base body of a class.
/// </summary>
internal sealed class CSharpClassEmitter : CodeEmitter
{
    private readonly string _accessibility;
    private readonly CSharpSerializationAttribute _serializationAttributeType;
    private readonly string _serializationAttribute;
    private readonly string _indentationPadding;
    private readonly string _objectType;
    private readonly string _setterType;
    private readonly string _propertyAccessor;

    /// <summary>
    /// Parses JSON data into a C# struct, class, or record with the base body of a class.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal CSharpClassEmitter(Json2SharpCSharpOptions options)
    {
        _accessibility = options.AccessibilityLevel.ToCode() + options.TargetType switch
        {
            CSharpObjectType.Struct when options.SetterType is CSharpSetterType.Init => " readonly",
            not CSharpObjectType.Struct when options.IsSealed => " sealed",
            _ => string.Empty
        };
    
        _serializationAttributeType = options.SerializationAttribute;
        _serializationAttribute = options.SerializationAttribute.ToCode();
        _indentationPadding = new string(
           options.IndentationPaddingCharacter is IndentationCharacterType.Space ? ' ' : '\t',
           options.IndentationCharacterAmount
        );
        _objectType = options.TargetType.ToString().ToLowerInvariant();
        _setterType = options.SetterType.ToCode();
        _propertyAccessor = "public" +
            ((options.IsPropertyRequired)
                ? " required"
                : string.Empty);
    }

    /// <inheritdoc />
    public override string Parse(string objectName, JsonElement jsonElement)
        => InternalParse(objectName, jsonElement, true);

    /// <summary>
    /// Parse JSON data into a C# struct, class, or record.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <param name="emitHeaders"><see langword="true"/> to include the "usings" at the beginning, <see langword="false"/> otherwise.</param>
    /// <returns>The C# struct, class, or record.</returns>
    private string InternalParse(string objectName, JsonElement jsonElement, bool emitHeaders)
    {
        objectName = objectName.ToPascalCase();
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var extraTypes = new List<string>();
        var stringBuilder = new StringBuilder();

        // Namespace declaration
        if (emitHeaders && _serializationAttributeType is CSharpSerializationAttribute.SystemTextJson)
            stringBuilder.AppendLine(Constants.StjUsing + Environment.NewLine);
        else if (emitHeaders && _serializationAttributeType is CSharpSerializationAttribute.NewtonsoftJson)
            stringBuilder.AppendLine(Constants.NewtonsoftUsing + Environment.NewLine);

        // Class declaration
        stringBuilder.AppendLine($"{_accessibility} {_objectType} {objectName}");
        stringBuilder.AppendLine("{");

        BuildClassMembers(stringBuilder, extraTypes, properties);

        stringBuilder.Append('}');

        // Add extra classes above the root class
        AddCustomTypes(stringBuilder, extraTypes);

        return stringBuilder.ToStringAndClear();
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        var propertyName = property.JsonName.ToPascalCase() ?? property.BclType.Name;
        var result = string.Empty;

        if (!string.IsNullOrWhiteSpace(_serializationAttribute))
            result += CreateMemberAttribute(_indentationPadding, _serializationAttribute, property.JsonName!) + Environment.NewLine;

        result += CreateMemberDeclaration(
            _indentationPadding,
            GetObjectTypeName(property, Language.CSharp),
            propertyName,
            _setterType
        ) + Environment.NewLine;

        return result;
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var propertyName = property.JsonName.ToPascalCase() ?? property.BclType.Name;
        var result = string.Empty;
        var propertyType = (IsArrayOfNullableType(property, Language.CSharp, childrenTypes, out typeName))
            ? typeName + "?[]"
            : typeName + "[]";

        if (!string.IsNullOrWhiteSpace(_serializationAttribute))
            result += CreateMemberAttribute(_indentationPadding, _serializationAttribute, property.JsonName!) + Environment.NewLine;

        result += CreateMemberDeclaration(_indentationPadding, propertyType, propertyName, _setterType) + Environment.NewLine;

        return result;
    }

    /// <summary>
    /// Builds the class members in the class definition.
    /// </summary>
    /// <param name="stringBuilder">The string builder that contains the class definition.</param>
    /// <param name="extraTypes">Custom type that this class depends on.</param>
    /// <param name="properties">The properties of the class.</param>
    /// <returns><paramref name="stringBuilder"/> with the class' members added to it.</returns>
    private StringBuilder BuildClassMembers(StringBuilder stringBuilder, List<string> extraTypes, IReadOnlyList<ParsedJsonProperty> properties)
    {
        foreach (var property in properties)
        {
            // Processes custom types and nullable arrays
            if (HandleCustomType(property, stringBuilder, extraTypes))
                continue;

            // Processes BCL types, non-nullable arrays, and "object?"
            var bclTypeName = (J2SUtils.TryGetAliasName(property.BclType, Language.CSharp, out var aliasName))
                ? aliasName
                : property.BclType.Name;

            var nullableAnnotation = (J2SUtils.IsPropertyNullable(property.JsonElement))
                ? "?"
                : string.Empty;

            if (!string.IsNullOrWhiteSpace(_serializationAttribute))
                stringBuilder.AppendLine(CreateMemberAttribute(_indentationPadding, _serializationAttribute, property.JsonName!));

            stringBuilder.AppendLine(
                CreateMemberDeclaration(
                    _indentationPadding,
                    (property.JsonElement.ValueKind is not JsonValueKind.Array)
                        ? bclTypeName + nullableAnnotation
                        : (string.IsNullOrWhiteSpace(nullableAnnotation)) ? bclTypeName : bclTypeName.Insert(bclTypeName.Length - 2, nullableAnnotation),
                    property.JsonName!.ToPascalCase(),
                    _setterType
                )
            );
            stringBuilder.AppendLine();
        }

        stringBuilder.Remove(stringBuilder.Length - (Environment.NewLine.Length + 1), Environment.NewLine.Length); // Remove the last newline

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
                var propertyName = property.JsonName ?? property.BclType.Name;
                extraTypes.Add(InternalParse(propertyName, property.JsonElement, false));
                stringBuilder.AppendLine(ParseCustomType(property));

                return true;
            case JsonValueKind.Array:
                var childrenTypes = J2SUtils.GetArrayTypes(property);

                if (childrenTypes.Count is 0)
                    return false;

                stringBuilder.AppendLine(ParseArrayType(property, childrenTypes, out var typeName));

                if (!typeName.Equals(J2SUtils.GetAliasName(typeof(object), Language.CSharp), StringComparison.Ordinal))
                    extraTypes.Add(InternalParse(typeName, childrenTypes[0].JsonElement, false));

                return true;
            default:
                return false;
        }
    }

    /// <summary>
    /// Creates a JSON member attribute for serialization.
    /// </summary>
    /// <param name="indentationPadding">Text that comes before the attribute.</param>
    /// <param name="serializationAttributeName">The name of the attribute.</param>
    /// <param name="jsonName">The name of the JSON property.</param>
    /// <remarks>Example: [JsonPropertyName("prop_name")]</remarks>
    /// <returns>The attribute for serialization.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateMemberAttribute(string indentationPadding, string serializationAttributeName, string jsonName)
        => $"{indentationPadding}[{serializationAttributeName}(\"{jsonName}\")]";

    /// <summary>
    /// Creates a member declaration.
    /// </summary>
    /// <param name="indentationPadding">Text that comes before the declaration.</param>
    /// <param name="targetTypeName">The C# type of the property.</param>
    /// <param name="propertyName">The C# name of the property.</param>
    /// <param name="setterType">The C# type of property setter.</param>
    /// <remarks>Example: public required int Number { get; init; }</remarks>
    /// <returns>The member declaration.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private string CreateMemberDeclaration(string indentationPadding, string targetTypeName, string propertyName, string setterType)
        => $"{indentationPadding}{_propertyAccessor} {targetTypeName} {propertyName} {{ get; {setterType}; }}";
}