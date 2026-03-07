using Json2SharpLib.Common;
using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using Json2SharpLib.Models.LanguageOptions;
using System.Numerics;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Emitters.Java;

/// <summary>
/// Parses JSON data into a Java record.
/// </summary>
internal sealed class JavaRecordEmitter : CodeEmitter
{
    private readonly JavaSerializationAnnotation _serializationAnnotation;
    private readonly JavaNullabilityAnnotation _nullabilityAnnotation;
    private readonly string _indentationPadding;

    /// <summary>
    /// Parses JSON data into a Java record.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal JavaRecordEmitter(Json2SharpJavaOptions options) : base(options.TypeNameHandler)
    {
        _serializationAnnotation = options.SerializationAnnotation;
        _nullabilityAnnotation = options.NullabilityAnnotation;
        _indentationPadding = new string(
            options.IndentationPaddingCharacter is IndentationCharacterType.Space ? ' ' : '\t',
            options.IndentationCharacterAmount
        );
    }

    /// <inheritdoc />
    public override string Parse(string objectName, JsonElement jsonElement)
        => InternalParse(objectName, jsonElement, true);

    /// <summary>
    /// Parse JSON data into a Java record.
    /// </summary>
    /// <param name="objectName">The name of the record.</param>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <param name="emitHeaders"><see langword="true"/> to include the imports at the beginning, <see langword="false"/> otherwise.</param>
    /// <returns>The Java record.</returns>
    private string InternalParse(string objectName, JsonElement jsonElement, bool emitHeaders)
    {
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var extraTypes = new List<string>();
        var stringBuilder = new StringBuilder();
        var imports = new HashSet<string>();

        CollectImports(properties, imports);

        if (emitHeaders)
        {
            foreach (var import in imports.OrderBy(x => x))
                stringBuilder.AppendLine($"import {import};");

            if (imports.Count > 0)
                stringBuilder.AppendLine();
        }

        stringBuilder.AppendLine($"public record {objectName}(");

        BuildRecordMembers(stringBuilder, extraTypes, properties);

        stringBuilder.Append(") {}");

        AddCustomTypes(stringBuilder, extraTypes);

        return stringBuilder.ToStringAndClear();
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        var jsonName = property.JsonName!;
        var fieldName = GetSafePropertyName(jsonName, Language.Java);
        var customType = GetObjectTypeName(property, Language.Java);
        var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

        var stringBuilder = new StringBuilder();
        var serializationAttr = CreateSerializationAnnotation(string.Empty, _serializationAnnotation, jsonName);
        var nullabilityAttr = CreateNullabilityAnnotation(string.Empty, _nullabilityAnnotation, isNullable);

        if (!string.IsNullOrWhiteSpace(serializationAttr))
            stringBuilder.Append($"{serializationAttr} ");

        if (!string.IsNullOrWhiteSpace(nullabilityAttr))
            stringBuilder.Append($"{nullabilityAttr} ");

        stringBuilder.Append($"{customType} {fieldName}");

        return stringBuilder.ToStringAndClear();
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var jsonName = property.JsonName!;
        var fieldName = GetSafePropertyName(jsonName, Language.Java);
        IsArrayOfNullableType(property, Language.Java, childrenTypes, out typeName);
        var isByteArr = typeName.Equals("byte", StringComparison.OrdinalIgnoreCase);
        var fullTypeName = (isByteArr) ? "byte[]" : $"List<{typeName}>";
        var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

        var stringBuilder = new StringBuilder();
        var serializationAttr = CreateSerializationAnnotation(string.Empty, _serializationAnnotation, jsonName);
        var nullabilityAttr = CreateNullabilityAnnotation(string.Empty, _nullabilityAnnotation, isNullable);

        if (!string.IsNullOrWhiteSpace(serializationAttr))
            stringBuilder.Append($"{serializationAttr} ");

        if (!string.IsNullOrWhiteSpace(nullabilityAttr))
            stringBuilder.Append($"{nullabilityAttr} ");

        stringBuilder.Append($"{fullTypeName} {fieldName}");

        return stringBuilder.ToStringAndClear();
    }

    /// <summary>
    /// Builds the record members (components).
    /// </summary>
    /// <param name="stringBuilder">The string builder to append the members to.</param>
    /// <param name="extraTypes">A list to collect any extra types defined within the record.</param>
    /// <param name="properties">The properties to be processed.</param>
    private void BuildRecordMembers(StringBuilder stringBuilder, List<string> extraTypes, IReadOnlyList<ParsedJsonProperty> properties)
    {
        foreach (var property in properties)
        {
            if (HandleCustomType(property, stringBuilder, extraTypes))
            {
                stringBuilder.AppendLine(",");
                continue;
            }

            var jsonName = property.JsonName!;
            var fieldName = GetSafePropertyName(jsonName, Language.Java);
            var typeName = J2SUtils.GetAliasName(property.BclType, Language.Java);
            var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

            stringBuilder.Append(_indentationPadding);

            var serializationAttr = CreateSerializationAnnotation(string.Empty, _serializationAnnotation, jsonName);
            if (!string.IsNullOrWhiteSpace(serializationAttr))
                stringBuilder.Append($"{serializationAttr} ");

            var nullabilityAttr = CreateNullabilityAnnotation(string.Empty, _nullabilityAnnotation, isNullable);
            if (!string.IsNullOrWhiteSpace(nullabilityAttr))
                stringBuilder.Append($"{nullabilityAttr} ");

            stringBuilder.AppendLine($"{typeName} {fieldName},");
        }

        if (properties.Count > 0)
            stringBuilder.Remove(stringBuilder.Length - (Environment.NewLine.Length + 1), Environment.NewLine.Length + 1);

        stringBuilder.Append(Environment.NewLine);
    }

    /// <summary>
    /// Handles the processing of custom types (objects and arrays).
    /// </summary>
    /// <param name="property">The property to be processed.</param>
    /// <param name="stringBuilder">The string builder to append the member to.</param>
    /// <param name="extraTypes">A list to collect any extra types defined.</param>
    /// <returns><see langword="true"/> if the property was a custom type and was handled, <see langword="false"/> otherwise.</returns>
    private bool HandleCustomType(ParsedJsonProperty property, StringBuilder stringBuilder, List<string> extraTypes)
    {
        switch (property.JsonElement.ValueKind)
        {
            case JsonValueKind.Object:
                {
                    var propertyName = GetObjectTypeName(property, Language.Java);
                    extraTypes.Add(InternalParse(propertyName, property.JsonElement, false));
                    stringBuilder.Append($"{_indentationPadding}{ParseCustomType(property)}");
                    return true;
                }
            case JsonValueKind.Array:
                {
                    var childrenTypes = J2SUtils.GetArrayTypes(property);
                    if (childrenTypes.Count is 0) return false;

                    stringBuilder.Append($"{_indentationPadding}{ParseArrayType(property, childrenTypes, out var typeName)}");
                    var isByteArr = typeName.Equals("byte", StringComparison.OrdinalIgnoreCase);
                    if (typeName != "Object" && !isByteArr && !TypeAliases.JavaAliasTypes.Values.Contains(typeName))
                        extraTypes.Add(InternalParse(typeName, childrenTypes[0].JsonElement, false));

                    return true;
                }
            default:
                return false;
        }
    }

    /// <summary>
    /// Appends custom types to the end of the string builder.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append to.</param>
    /// <param name="extraTypes">The list of extra types to be appended.</param>
    private static void AddCustomTypes(StringBuilder stringBuilder, IEnumerable<string> extraTypes)
    {
        var sanitizedExtraTypes = extraTypes.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        
        if (sanitizedExtraTypes.Length is 0)
            return;

        stringBuilder.AppendLine(Environment.NewLine);
        stringBuilder.AppendJoin(Environment.NewLine + Environment.NewLine, sanitizedExtraTypes);
    }

    /// <summary>
    /// Creates a serialization annotation for a Java component.
    /// </summary>
    /// <param name="indentationPadding">The indentation padding to be used.</param>
    /// <param name="annotation">The serialization annotation type.</param>
    /// <param name="jsonName">The original name of the property in JSON.</param>
    /// <returns>The serialization annotation, or <see langword="null"/> if none is applicable.</returns>
    private static string? CreateSerializationAnnotation(string indentationPadding, JavaSerializationAnnotation annotation, string jsonName)
    {
        return annotation switch
        {
            JavaSerializationAnnotation.Jackson => $"{indentationPadding}@JsonProperty(\"{jsonName}\")",
            JavaSerializationAnnotation.Gson => $"{indentationPadding}@SerializedName(\"{jsonName}\")",
            JavaSerializationAnnotation.Moshi => $"{indentationPadding}@Json(name = \"{jsonName}\")",
            _ => null
        };
    }

    /// <summary>
    /// Creates a nullability annotation for a Java component.
    /// </summary>
    /// <param name="indentationPadding">The indentation padding to be used.</param>
    /// <param name="annotation">The nullability annotation type.</param>
    /// <param name="isNullable">Whether the property is nullable.</param>
    /// <returns>The nullability annotation, or <see langword="null"/> if none is applicable.</returns>
    private static string? CreateNullabilityAnnotation(string indentationPadding, JavaNullabilityAnnotation annotation, bool isNullable)
    {
        if (annotation is JavaNullabilityAnnotation.NoAnnotation)
            return null;

        var attr = (isNullable)
            ? annotation switch
            {
                JavaNullabilityAnnotation.Jakarta => "@Nullable",
                JavaNullabilityAnnotation.JSpecify => "@Nullable",
                JavaNullabilityAnnotation.JetBrains => "@Nullable",
                JavaNullabilityAnnotation.FindBugs => "@Nullable",
                _ => null
            }
            : annotation switch
            {
                JavaNullabilityAnnotation.Jakarta => "@NotNull",
                JavaNullabilityAnnotation.JSpecify => "@NonNull",
                JavaNullabilityAnnotation.JetBrains => "@NotNull",
                JavaNullabilityAnnotation.Lombok => "@NonNull",
                JavaNullabilityAnnotation.FindBugs => "@Nonnull",
                _ => null
            };

        return (attr is null) ? null : $"{indentationPadding}{attr}";
    }

    /// <summary>
    /// Collects the necessary imports based on the properties and configuration.
    /// </summary>
    /// <param name="properties">The properties to be processed.</param>
    /// <param name="imports">The set to collect the imports into.</param>
    private void CollectImports(IReadOnlyList<ParsedJsonProperty> properties, HashSet<string> imports)
    {
        if (_serializationAnnotation is JavaSerializationAnnotation.Jackson)
            imports.Add("com.fasterxml.jackson.annotation.JsonProperty");
        else if (_serializationAnnotation is JavaSerializationAnnotation.Gson)
            imports.Add("com.google.gson.annotations.SerializedName");
        else if (_serializationAnnotation is JavaSerializationAnnotation.Moshi)
            imports.Add("com.squareup.moshi.Json");

        switch (_nullabilityAnnotation)
        {
            case JavaNullabilityAnnotation.Jakarta:
                imports.Add("jakarta.validation.constraints.NotNull");
                imports.Add("jakarta.validation.constraints.Nullable");
                break;
            case JavaNullabilityAnnotation.JSpecify:
                imports.Add("org.jspecify.annotations.NonNull");
                imports.Add("org.jspecify.annotations.Nullable");
                break;
            case JavaNullabilityAnnotation.JetBrains:
                imports.Add("org.jetbrains.annotations.NotNull");
                imports.Add("org.jetbrains.annotations.Nullable");
                break;
            case JavaNullabilityAnnotation.Lombok:
                imports.Add("lombok.NonNull");
                break;
            case JavaNullabilityAnnotation.FindBugs:
                imports.Add("javax.annotation.Nonnull");
                imports.Add("javax.annotation.Nullable");
                break;
        }

        foreach (var prop in properties)
        {
            if (prop.BclType == typeof(DateTime) || prop.BclType == typeof(DateTimeOffset))
                imports.Add("java.time.OffsetDateTime");
            else if (prop.BclType == typeof(Guid))
                imports.Add("java.util.UUID");
            else if (prop.BclType == typeof(TimeSpan))
                imports.Add("java.time.Duration");
            else if (prop.BclType == typeof(BigInteger))
                imports.Add("java.math.BigInteger");

            if (prop.JsonElement.ValueKind is JsonValueKind.Array && prop.BclType != typeof(byte[]))
                imports.Add("java.util.List");

            if (prop.Children.Count > 0)
                CollectImports(prop.Children, imports);
        }
    }
}