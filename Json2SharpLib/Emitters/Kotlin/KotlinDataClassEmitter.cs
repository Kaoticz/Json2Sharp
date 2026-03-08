using Json2SharpLib.Common;
using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using Json2SharpLib.Models.LanguageOptions;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Emitters.Kotlin;

/// <summary>
/// Parses JSON data into a Kotlin data class.
/// </summary>
internal sealed class KotlinDataClassEmitter : CodeEmitter
{
    private readonly KotlinSerializationAnnotation _serializationAnnotation;
    private readonly string _indentationPadding;

    /// <summary>
    /// Parses JSON data into a Kotlin data class.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal KotlinDataClassEmitter(Json2SharpKotlinOptions options) : base(options.TypeNameHandler)
    {
        _serializationAnnotation = options.SerializationAnnotation;
        _indentationPadding = new string(
            options.IndentationPaddingCharacter is IndentationCharacterType.Space ? ' ' : '\t',
            options.IndentationCharacterAmount
        );
    }

    /// <inheritdoc />
    public override string Parse(string objectName, JsonElement jsonElement)
        => InternalParse(objectName, jsonElement, true);

    /// <summary>
    /// Parse JSON data into a Kotlin data class.
    /// </summary>
    /// <param name="objectName">The name of the class.</param>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <param name="emitHeaders"><see langword="true"/> to include the imports at the beginning, <see langword="false"/> otherwise.</param>
    /// <returns>The Kotlin data class.</returns>
    private string InternalParse(string objectName, JsonElement jsonElement, bool emitHeaders)
    {
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var extraTypes = new List<string>();
        var stringBuilder = new StringBuilder();
        var imports = new HashSet<string>();

        CollectMetadata(properties, imports);

        if (emitHeaders)
        {
            var orderedImports = imports.OrderBy(x => x).ToArray();
            foreach (var import in orderedImports)
                stringBuilder.AppendLine($"import {import}");

            if (orderedImports.Length > 0)
                stringBuilder.AppendLine();
        }

        if (_serializationAnnotation is KotlinSerializationAnnotation.Kotlinx)
            stringBuilder.AppendLine("@Serializable");
        else if (_serializationAnnotation is KotlinSerializationAnnotation.Moshi)
            stringBuilder.AppendLine("@JsonClass(generateAdapter = true)");

        stringBuilder.AppendLine($"data class {objectName}(");

        BuildClassMembers(stringBuilder, extraTypes, properties);

        stringBuilder.Append(')');

        AddCustomTypes(stringBuilder, extraTypes);

        return stringBuilder.ToStringAndClear();
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        var jsonName = property.JsonName!;
        var name = GetSafePropertyName(jsonName, Language.Kotlin);
        var type = GetObjectTypeName(property, Language.Kotlin);
        var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

        return BuildFieldDeclaration(type, name, jsonName, isNullable);
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var jsonName = property.JsonName!;
        var name = GetSafePropertyName(jsonName, Language.Kotlin);
        _ = IsArrayOfNullableType(property, Language.Kotlin, childrenTypes, out typeName);

        var isByteArr = typeName.Equals("byte", StringComparison.OrdinalIgnoreCase);
        var fullTypeName = (isByteArr) ? "ByteArray" : $"List<{typeName}>";
        var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

        return BuildFieldDeclaration(fullTypeName, name, jsonName, isNullable);
    }

    /// <summary>
    /// Builds the class members (properties in the constructor).
    /// </summary>
    /// <param name="stringBuilder">The string builder to append the members to.</param>
    /// <param name="extraTypes">A list to collect any extra types defined within the class.</param>
    /// <param name="properties">The properties to be processed.</param>
    private void BuildClassMembers(StringBuilder stringBuilder, List<string> extraTypes, IReadOnlyList<ParsedJsonProperty> properties)
    {
        foreach (var property in properties)
        {
            var jsonName = property.JsonName!;
            var fieldName = GetSafePropertyName(jsonName, Language.Kotlin);
            var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

            if (property.JsonElement.ValueKind is JsonValueKind.Object)
            {
                var fieldType = GetObjectTypeName(property, Language.Kotlin);
                extraTypes.Add(InternalParse(fieldType, property.JsonElement, false));
                stringBuilder.AppendLine($"{ParseCustomType(property)},");
            }
            else if (property.JsonElement.ValueKind is JsonValueKind.Array)
            {
                var childrenTypes = J2SUtils.GetArrayTypes(property);
                if (childrenTypes.Count is not 0)
                {
                    stringBuilder.AppendLine($"{ParseArrayType(property, childrenTypes, out var arrayElementTypeName)},");
                    var isByteArr = arrayElementTypeName.Equals("byte", StringComparison.OrdinalIgnoreCase);

                    if (arrayElementTypeName != "Any" && !isByteArr && !TypeAliases.KotlinAliasTypes.Values.Contains(arrayElementTypeName))
                        extraTypes.Add(InternalParse(arrayElementTypeName, childrenTypes[0].JsonElement, false));
                }
                else
                {
                    var fieldType = J2SUtils.GetAliasName(property.BclType, Language.Kotlin);
                    stringBuilder.AppendLine($"{BuildFieldDeclaration(fieldType, fieldName, jsonName, isNullable)},");
                }
            }
            else
            {
                var fieldType = J2SUtils.GetAliasName(property.BclType, Language.Kotlin);
                stringBuilder.AppendLine($"{BuildFieldDeclaration(fieldType, fieldName, jsonName, isNullable)},");
            }
        }

        if (properties.Count > 0)
            stringBuilder.Remove(stringBuilder.Length - (Environment.NewLine.Length + 1), Environment.NewLine.Length + 1);

        stringBuilder.Append(Environment.NewLine);
    }

    /// <summary>
    /// Appends custom types to the end of the string builder.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append to.</param>
    /// <param name="extraTypes">The list of extra types to be appended.</param>
    private static void AddCustomTypes(StringBuilder stringBuilder, List<string> extraTypes)
    {
        var sanitizedExtraTypes = extraTypes.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        
        if (sanitizedExtraTypes.Length is 0)
            return;

        stringBuilder.AppendLine(Environment.NewLine);
        stringBuilder.AppendJoin(Environment.NewLine + Environment.NewLine, sanitizedExtraTypes);
    }

    /// <summary>
    /// Creates a serialization annotation for a Kotlin property.
    /// </summary>
    /// <param name="annotation">The serialization annotation type.</param>
    /// <param name="jsonName">The original name of the property in JSON.</param>
    /// <returns>The serialization annotation, or <see langword="null"/> if none is applicable.</returns>
    private static string? CreateSerializationAnnotation(KotlinSerializationAnnotation annotation, string jsonName)
    {
        return annotation switch
        {
            KotlinSerializationAnnotation.Kotlinx => $"@SerialName(\"{jsonName}\")",
            KotlinSerializationAnnotation.Jackson => $"@JsonProperty(\"{jsonName}\")",
            KotlinSerializationAnnotation.Gson => $"@SerializedName(\"{jsonName}\")",
            KotlinSerializationAnnotation.Moshi => $"@Json(name = \"{jsonName}\")",
            _ => null
        };
    }

    /// <summary>
    /// Builds a Kotlin property declaration string.
    /// </summary>
    /// <param name="type">The type of the property.</param>
    /// <param name="name">The name of the property.</param>
    /// <param name="jsonName">The original JSON name of the property.</param>
    /// <param name="isNullable">Whether the property is nullable.</param>
    /// <returns>A Kotlin property declaration string.</returns>
    private string BuildFieldDeclaration(string type, string name, string jsonName, bool isNullable)
    {
        var fieldStringBuilder = new StringBuilder();
        var serializationAttr = CreateSerializationAnnotation(_serializationAnnotation, jsonName);

        fieldStringBuilder.Append(_indentationPadding);

        if (!string.IsNullOrWhiteSpace(serializationAttr))
            fieldStringBuilder.Append($"{serializationAttr} ");

        var nullableIndicator = isNullable ? "?" : string.Empty;

        if (type.StartsWith("List<", StringComparison.Ordinal) && type.EndsWith('>') && isNullable)
            fieldStringBuilder.Append($"val {name}: {type.Insert(type.Length - 1, "?")}");
        else
            fieldStringBuilder.Append($"val {name}: {type}{nullableIndicator}");

        return fieldStringBuilder.ToString();
    }

    /// <summary>
    /// Collects metadata (imports) based on the properties and configuration.
    /// </summary>
    /// <param name="properties">The properties to be processed.</param>
    /// <param name="imports">The set to collect the imports into.</param>
    private void CollectMetadata(IReadOnlyList<ParsedJsonProperty> properties, HashSet<string> imports)
    {
        if (_serializationAnnotation is KotlinSerializationAnnotation.Kotlinx)
        {
            imports.Add("kotlinx.serialization.SerialName");
            imports.Add("kotlinx.serialization.Serializable");
        }
        else if (_serializationAnnotation is KotlinSerializationAnnotation.Jackson)
            imports.Add("com.fasterxml.jackson.annotation.JsonProperty");
        else if (_serializationAnnotation is KotlinSerializationAnnotation.Gson)
            imports.Add("com.google.gson.annotations.SerializedName");
        else if (_serializationAnnotation is KotlinSerializationAnnotation.Moshi)
        {
            imports.Add("com.squareup.moshi.Json");
            imports.Add("com.squareup.moshi.JsonClass");
        }

        foreach (var prop in properties)
        {
            if (prop.BclType == typeof(DateTime) || prop.BclType == typeof(DateTimeOffset))
                imports.Add("java.time.OffsetDateTime");
            else if (prop.BclType == typeof(Guid))
                imports.Add("java.util.UUID");
            else if (prop.BclType == typeof(TimeSpan))
                imports.Add("java.time.Duration");
            else if (prop.BclType == typeof(System.Numerics.BigInteger))
                imports.Add("java.math.BigInteger");

            if (prop.JsonElement.ValueKind is JsonValueKind.Object)
                CollectMetadata(Json2Sharp.ParseProperties(prop.JsonElement), imports);
            else if (prop.JsonElement.ValueKind is JsonValueKind.Array)
            {
                var childrenTypes = J2SUtils.GetArrayTypes(prop);
                if (childrenTypes.Count is not 0)
                {
                    IsArrayOfNullableType(prop, Language.Kotlin, childrenTypes, out var arrayElementTypeName);
                    var isByteArr = arrayElementTypeName.Equals("byte", StringComparison.OrdinalIgnoreCase);

                    if (arrayElementTypeName != "Any" && !isByteArr && !TypeAliases.KotlinAliasTypes.Values.Contains(arrayElementTypeName))
                        CollectMetadata(Json2Sharp.ParseProperties(childrenTypes[0].JsonElement), imports);
                }
            }
        }
    }
}
