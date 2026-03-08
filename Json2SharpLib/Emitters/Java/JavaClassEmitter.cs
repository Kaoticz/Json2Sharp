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
/// Parses JSON data into a Java class.
/// </summary>
internal sealed class JavaClassEmitter : CodeEmitter
{
    private readonly JavaSerializationAnnotation _serializationAnnotation;
    private readonly JavaNullabilityAnnotation _nullabilityAnnotation;
    private readonly string _indentationPadding;

    /// <summary>
    /// Parses JSON data into a Java class.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal JavaClassEmitter(Json2SharpJavaOptions options) : base(options.TypeNameHandler)
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
        => InternalParse(objectName, jsonElement, true, null);

    /// <summary>
    /// Parse JSON data into a Java class.
    /// </summary>
    /// <param name="objectName">The name of the class.</param>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <param name="emitHeaders"><see langword="true"/> to include the imports at the beginning, <see langword="false"/> otherwise.</param>
    /// <param name="useFullLombokName"><see langword="true"/> to use fully qualified Lombok annotation names, <see langword="false"/> otherwise.</param>
    /// <returns>The Java class.</returns>
    private string InternalParse(string objectName, JsonElement jsonElement, bool emitHeaders, bool? useFullLombokName)
    {
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var extraTypes = new List<string>();
        var stringBuilder = new StringBuilder();
        var imports = new HashSet<string>();
        var classNames = new HashSet<string>();

        CollectMetadata(objectName, properties, imports, classNames);

        useFullLombokName ??= classNames.Contains("Data");

        if (emitHeaders)
        {
            if (_nullabilityAnnotation is JavaNullabilityAnnotation.Lombok && !useFullLombokName.Value)
                imports.Add("lombok.Data");

            foreach (var import in imports.OrderBy(x => x))
                stringBuilder.AppendLine($"import {import};");

            if (imports.Count > 0)
                stringBuilder.AppendLine();
        }

        if (_nullabilityAnnotation is JavaNullabilityAnnotation.Lombok)
            stringBuilder.AppendLine(useFullLombokName.Value ? "@lombok.Data" : "@Data");

        stringBuilder.AppendLine($"public class {objectName} {{");

        BuildClassMembers(stringBuilder, extraTypes, properties, useFullLombokName);

        stringBuilder.Append('}');

        AddCustomTypes(stringBuilder, extraTypes);

        return stringBuilder.ToStringAndClear();
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        var jsonName = property.JsonName!;
        var name = GetSafePropertyName(jsonName, Language.Java);
        var type = GetObjectTypeName(property, Language.Java);
        var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

        return BuildFieldDeclaration(type, name, jsonName, isNullable, false);
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var jsonName = property.JsonName!;
        var name = GetSafePropertyName(jsonName, Language.Java);
        IsArrayOfNullableType(property, Language.Java, childrenTypes, out typeName);

        var isByteArr = typeName.Equals("byte", StringComparison.OrdinalIgnoreCase);
        var fullTypeName = (isByteArr) ? "byte[]" : $"List<{typeName}>";
        var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

        return BuildFieldDeclaration(fullTypeName, name, jsonName, isNullable, !isByteArr);
    }

    /// <summary>
    /// Builds the class members (fields, getters, and setters).
    /// </summary>
    /// <param name="stringBuilder">The string builder to append the members to.</param>
    /// <param name="extraTypes">A list to collect any extra types defined within the class.</param>
    /// <param name="properties">The properties to be processed.</param>
    /// <param name="useFullLombokName"><see langword="true"/> to use fully qualified Lombok annotation names, <see langword="false"/> otherwise.</param>
    private void BuildClassMembers(StringBuilder stringBuilder, List<string> extraTypes, IReadOnlyList<ParsedJsonProperty> properties, bool? useFullLombokName)
    {
        var fields = new List<(string Name, string Type, string JsonName, bool IsNullable, bool IsList)>();

        foreach (var property in properties)
        {
            var jsonName = property.JsonName!;
            var fieldName = GetSafePropertyName(jsonName, Language.Java);
            var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);
            var isList = false;
            string fieldType;

            if (property.JsonElement.ValueKind is JsonValueKind.Object)
            {
                fieldType = GetObjectTypeName(property, Language.Java);
                extraTypes.Add(InternalParse(fieldType, property.JsonElement, false, useFullLombokName));
                stringBuilder.AppendLine(ParseCustomType(property));
            }
            else if (property.JsonElement.ValueKind is JsonValueKind.Array)
            {
                var childrenTypes = J2SUtils.GetArrayTypes(property);
                if (childrenTypes.Count is not 0)
                {
                    stringBuilder.AppendLine(ParseArrayType(property, childrenTypes, out var arrayElementTypeName));
                    isList = !arrayElementTypeName.Equals("byte", StringComparison.OrdinalIgnoreCase);
                    fieldType = (isList) ? $"List<{arrayElementTypeName}>" : "byte[]";

                    if (arrayElementTypeName != "Object" && isList && !TypeAliases.JavaAliasTypes.Values.Contains(arrayElementTypeName))
                        extraTypes.Add(InternalParse(arrayElementTypeName, childrenTypes[0].JsonElement, false, useFullLombokName));
                }
                else
                {
                    fieldType = J2SUtils.GetAliasName(property.BclType, Language.Java);
                    isList = fieldType.StartsWith("List<", StringComparison.Ordinal);
                    stringBuilder.AppendLine(BuildFieldDeclaration(fieldType, fieldName, jsonName, isNullable, isList));
                }
            }
            else
            {
                fieldType = J2SUtils.GetAliasName(property.BclType, Language.Java);
                stringBuilder.AppendLine(BuildFieldDeclaration(fieldType, fieldName, jsonName, isNullable, false));
            }

            stringBuilder.AppendLine();
            fields.Add((fieldName, fieldType, jsonName, isNullable, isList));
        }

        // 2. Getters and Setters
        if (_nullabilityAnnotation is not JavaNullabilityAnnotation.Lombok)
        {
            foreach (var field in fields)
            {
                var methodNameSuffix = (char.IsDigit(field.Name[0]) || (field.Name.Length > 1 && field.Name[0] == '_' && char.IsDigit(field.Name[1])))
                    ? field.Name
                    : field.Name.ToPascalCase();

                var getterName = "get" + methodNameSuffix;
                stringBuilder.AppendLine($"{_indentationPadding}public {field.Type} {getterName}() {{");
                stringBuilder.AppendLine($"{_indentationPadding}{_indentationPadding}return {field.Name};");
                stringBuilder.AppendLine($"{_indentationPadding}}}");
                stringBuilder.AppendLine();

                var setterName = "set" + methodNameSuffix;
                stringBuilder.AppendLine($"{_indentationPadding}public void {setterName}({field.Type} {field.Name}) {{");
                stringBuilder.AppendLine($"{_indentationPadding}{_indentationPadding}this.{field.Name} = {field.Name};");
                stringBuilder.AppendLine($"{_indentationPadding}}}");
                stringBuilder.AppendLine();
            }
        }

        if (properties.Count > 0)
            stringBuilder.Remove(stringBuilder.Length - Environment.NewLine.Length, Environment.NewLine.Length);
    }

    /// <summary>
    /// Appends custom types to the end of the string builder.
    /// </summary>
    /// <param name="stringBuilder">The string builder to append to.</param>
    /// <param name="extraTypes">The list of extra types to be appended.</param>
    private static void AddCustomTypes(StringBuilder stringBuilder, List<string> extraTypes)
    {
        var sanitizedExtraTypes = extraTypes.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        if (sanitizedExtraTypes.Length is 0) return;

        stringBuilder.AppendLine(Environment.NewLine);
        stringBuilder.AppendJoin(Environment.NewLine + Environment.NewLine, sanitizedExtraTypes);
    }

    /// <summary>
    /// Creates a serialization annotation for a Java field.
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
    /// Builds a Java field declaration string.
    /// </summary>
    /// <param name="type">The type of the field.</param>
    /// <param name="name">The name of the field.</param>
    /// <param name="jsonName">The original JSON name of the property.</param>
    /// <param name="isNullable">Whether the field is nullable.</param>
    /// <param name="isList">Whether the field is a list that should be initialized.</param>
    /// <returns>A Java field declaration string.</returns>
    private string BuildFieldDeclaration(string type, string name, string jsonName, bool isNullable, bool isList)
    {
        var fieldStringBuilder = new StringBuilder();
        var serializationAttr = CreateSerializationAnnotation(_indentationPadding, _serializationAnnotation, jsonName);

        if (!string.IsNullOrWhiteSpace(serializationAttr))
            fieldStringBuilder.AppendLine(serializationAttr);

        var nullabilityAttr = CreateNullabilityAnnotation(_indentationPadding, _nullabilityAnnotation, isNullable);

        if (!string.IsNullOrWhiteSpace(nullabilityAttr))
            fieldStringBuilder.AppendLine(nullabilityAttr);

        var initialization = (isList) ? " = new ArrayList<>()" : string.Empty;
        fieldStringBuilder.Append($"{_indentationPadding}private {type} {name}{initialization};");

        return fieldStringBuilder.ToString();
    }

    /// <summary>
    /// Creates a nullability annotation for a Java field.
    /// </summary>
    /// <param name="indentationPadding">The indentation padding to be used.</param>
    /// <param name="annotation">The nullability annotation type.</param>
    /// <param name="isNullable">Whether the property is nullable.</param>
    /// <returns>The nullability annotation, or <see langword="null"/> if none is applicable.</returns>
    private static string? CreateNullabilityAnnotation(string indentationPadding, JavaNullabilityAnnotation annotation, bool isNullable)
    {
        if (annotation is JavaNullabilityAnnotation.NoAnnotation) return null;

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
    /// Collects metadata (imports and class names) based on the properties and configuration.
    /// </summary>
    /// <param name="objectName">The name of the class.</param>
    /// <param name="properties">The properties to be processed.</param>
    /// <param name="imports">The set to collect the imports into.</param>
    /// <param name="classNames">The set to collect the class names into.</param>
    private void CollectMetadata(string objectName, IReadOnlyList<ParsedJsonProperty> properties, HashSet<string> imports, HashSet<string> classNames)
    {
        classNames.Add(objectName);

        if (_serializationAnnotation is JavaSerializationAnnotation.Jackson) imports.Add("com.fasterxml.jackson.annotation.JsonProperty");
        if (_serializationAnnotation is JavaSerializationAnnotation.Gson) imports.Add("com.google.gson.annotations.SerializedName");
        if (_serializationAnnotation is JavaSerializationAnnotation.Moshi) imports.Add("com.squareup.moshi.Json");

        foreach (var prop in properties)
        {
            var isNullable = J2SUtils.IsPropertyNullable(prop.JsonElement);

            switch (_nullabilityAnnotation)
            {
                case JavaNullabilityAnnotation.Jakarta:
                    imports.Add(isNullable ? "jakarta.validation.constraints.Nullable" : "jakarta.validation.constraints.NotNull");
                    break;
                case JavaNullabilityAnnotation.JSpecify:
                    imports.Add(isNullable ? "org.jspecify.annotations.Nullable" : "org.jspecify.annotations.NonNull");
                    break;
                case JavaNullabilityAnnotation.JetBrains:
                    imports.Add(isNullable ? "org.jetbrains.annotations.Nullable" : "org.jetbrains.annotations.NotNull");
                    break;
                case JavaNullabilityAnnotation.Lombok:
                    if (!isNullable)
                        imports.Add("lombok.NonNull");
                    break;
                case JavaNullabilityAnnotation.FindBugs:
                    imports.Add(isNullable ? "javax.annotation.Nullable" : "javax.annotation.Nonnull");
                    break;
            }

            if (prop.BclType == typeof(DateTime) || prop.BclType == typeof(DateTimeOffset))
                imports.Add("java.time.OffsetDateTime");
            else if (prop.BclType == typeof(Guid))
                imports.Add("java.util.UUID");
            else if (prop.BclType == typeof(TimeSpan))
                imports.Add("java.time.Duration");
            else if (prop.BclType == typeof(BigInteger))
                imports.Add("java.math.BigInteger");

            if (prop.JsonElement.ValueKind is JsonValueKind.Array && prop.BclType != typeof(byte[]))
            {
                imports.Add("java.util.ArrayList");
                imports.Add("java.util.List");
            }

            if (prop.JsonElement.ValueKind is JsonValueKind.Object)
            {
                var typeName = GetObjectTypeName(prop, Language.Java);
                CollectMetadata(typeName, Json2Sharp.ParseProperties(prop.JsonElement), imports, classNames);
            }
            else if (prop.JsonElement.ValueKind is JsonValueKind.Array)
            {
                var childrenTypes = J2SUtils.GetArrayTypes(prop);
                if (childrenTypes.Count is not 0)
                {
                    IsArrayOfNullableType(prop, Language.Java, childrenTypes, out var arrayElementTypeName);
                    var isByteArr = arrayElementTypeName.Equals("byte", StringComparison.OrdinalIgnoreCase);

                    if (arrayElementTypeName != "Object" && !isByteArr && !TypeAliases.JavaAliasTypes.Values.Contains(arrayElementTypeName))
                        CollectMetadata(arrayElementTypeName, Json2Sharp.ParseProperties(childrenTypes[0].JsonElement), imports, classNames);
                }
            }
        }
    }
}