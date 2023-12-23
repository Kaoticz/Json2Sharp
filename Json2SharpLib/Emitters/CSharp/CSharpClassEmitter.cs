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
/// Parses JSON data into a C# type declaration with the base body of a class definition.
/// </summary>
internal sealed class CSharpClassEmitter : ICodeEmitter
{
    private int _stackCounter = 0;
    private readonly string _accessibility;
    private readonly CSharpSerializationAttribute _serializationAttributeType;
    private readonly string _serializationAttribute;
    private readonly string _indentationPadding;
    private readonly string _objectType;
    private readonly string _setterType;

    /// <summary>
    /// Creates an object that parses JSON data into a C# type declaration with the base body of a class definition.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal CSharpClassEmitter(Json2SharpCSharpOptions options)
    {
        _accessibility = options.AccessibilityLevel.ToCode() + (options.IsSealed && options.TargetType is not Enums.CSharpObjectType.Struct ? " sealed" : string.Empty);
        _serializationAttributeType = options.SerializationAttribute;
        _serializationAttribute = options.SerializationAttribute.ToCode();
        _indentationPadding = options.IndentationPadding;
        _objectType = options.TargetType.ToString().ToLowerInvariant();
        _setterType = options.SetterType.ToCode();
    }

    /// <inheritdoc />
    public string Parse(string objectName, JsonElement jsonElement)
    {
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

        // Class declaration
        stringBuilder.AppendLine($"{_accessibility} {_objectType} {objectName}");
        stringBuilder.AppendLine("{");

        BuildClassMembers(stringBuilder, extraTypes, properties);

        stringBuilder.Append('}');

        AddCustomTypes(stringBuilder, extraTypes);

        _stackCounter--;

        return stringBuilder.ToStringAndClear();
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
            var bclTypeName = (J2SUtils.TryGetAliasName(property.BclType, Language.CSharp, out var aliasName))
                ? aliasName
                : property.BclType.Name;

            var nullableAnnotation = (J2SUtils.IsPropertyNullable(property.JsonElement))
                ? "?"
                : string.Empty;

            if (HandleCustomType(property, stringBuilder, bclTypeName, nullableAnnotation, extraTypes))
                continue;

            if (!string.IsNullOrWhiteSpace(_serializationAttribute))
                stringBuilder.AppendLine(CreateMemberAttribute(_indentationPadding, _serializationAttribute, property.JsonName!));

            stringBuilder.AppendLine(
                CreateMemberDeclaration(
                    _indentationPadding,
                    (property.JsonElement.ValueKind is not JsonValueKind.Array)
                        ? bclTypeName + nullableAnnotation
                        : (string.IsNullOrWhiteSpace(nullableAnnotation)) ? bclTypeName : bclTypeName.Insert(bclTypeName.Length - 2, nullableAnnotation),
                    J2SUtils.ToPascalCase(property.JsonName!),
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
    /// <param name="bclTypeName">The name of the equivalent type in C#.</param>
    /// <param name="nullableAnnotation">The symbol for null annotations.</param>
    /// <param name="extraTypes">The list that contains the definitions of custom types in the JSON data.</param>
    /// <returns><see langword="true"/> if <paramref name="property"/> was parsed, <see langword="false"/> otherwise.</returns>
    private bool HandleCustomType(ParsedJsonProperty property, StringBuilder stringBuilder, string bclTypeName, string nullableAnnotation, List<string> extraTypes)
    {
        if (property.BclType == typeof(object) && property.JsonElement.ValueKind is JsonValueKind.Object)
        {
            var finalName = J2SUtils.ToPascalCase(property.JsonName);

            extraTypes.Add(Parse(finalName ?? property.BclType.Name, property.JsonElement));

            if (!string.IsNullOrWhiteSpace(_serializationAttribute))
                stringBuilder.AppendLine(CreateMemberAttribute(_indentationPadding, _serializationAttribute, property.JsonName!));

            stringBuilder.AppendLine(CreateMemberDeclaration(_indentationPadding, finalName!, finalName!, _setterType));
            stringBuilder.AppendLine();

            return true;
        }
        else if (property.BclType == typeof(object[]))
        {
            var childrenTypes = property.Children
                .DistinctBy(x => x.JsonElement.ValueKind)
                .ToArray();

            if (childrenTypes.Count(x => x.JsonElement.ValueKind is not JsonValueKind.Null) is 1)
            {
                var finalName = J2SUtils.ToPascalCase(property.JsonName!);
                var child = childrenTypes.First(x => x.JsonElement.ValueKind is not JsonValueKind.Null);
                var typeName = (childrenTypes.Length is not 1 && J2SUtils.TryGetAliasName(child.BclType, Language.CSharp, out var aliasName))
                    ? (aliasName == "object") ? finalName : aliasName  // CustomType or alias
                    : finalName ?? bclTypeName;                        // CustomType or Int32 (fallback)

                extraTypes.Add(Parse(typeName, childrenTypes[0].JsonElement));

                if (!string.IsNullOrWhiteSpace(_serializationAttribute))
                    stringBuilder.AppendLine(CreateMemberAttribute(_indentationPadding, _serializationAttribute, property.JsonName!));

                stringBuilder.AppendLine(CreateMemberDeclaration(_indentationPadding, typeName + nullableAnnotation + "[]", finalName!, _setterType));
                stringBuilder.AppendLine();

                return true;
            }
        }

        return false;
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
    /// <remarks>Example: public int Number { get; init; }</remarks>
    /// <returns>The member declaration.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateMemberDeclaration(string indentationPadding, string targetTypeName, string propertyName, string setterType)
        => $"{indentationPadding}public {targetTypeName} {propertyName} {{ get; {setterType}; }}";
}