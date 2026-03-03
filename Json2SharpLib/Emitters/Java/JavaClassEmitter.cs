using Json2SharpLib.Common;
using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using Json2SharpLib.Models.LanguageOptions;
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

    private static readonly HashSet<string> _javaKeywords =
    [
        "abstract", "assert", "boolean", "break", "byte", "case", "catch", "char", "class", "const", "continue",
        "default", "do", "double", "else", "enum", "extends", "final", "finally", "float", "for", "goto",
        "if", "implements", "import", "instanceof", "int", "interface", "long", "native", "new", "package",
        "private", "protected", "public", "return", "short", "static", "strictfp", "super", "switch",
        "synchronized", "this", "throw", "throws", "transient", "try", "void", "volatile", "while",
        "true", "false", "null"
    ];

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
        => InternalParse(objectName, jsonElement, true);

    /// <summary>
    /// Parse JSON data into a Java class.
    /// </summary>
    /// <param name="objectName">The name of the class.</param>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <param name="emitHeaders"><see langword="true"/> to include the imports at the beginning, <see langword="false"/> otherwise.</param>
    /// <returns>The Java class.</returns>
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

        stringBuilder.AppendLine($"public class {objectName} {{");

        BuildClassMembers(stringBuilder, extraTypes, properties);

        stringBuilder.Append('}');

        AddCustomTypes(stringBuilder, extraTypes);

        return stringBuilder.ToStringAndClear();
    }

    /// <inheritdoc />
    protected override string ParseCustomType(ParsedJsonProperty property)
    {
        var jsonName = property.JsonName!;
        var name = GetSafeFieldName(jsonName);
        var type = GetObjectTypeName(property, Language.Java);
        var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);

        return BuildFieldDeclaration(type, name, jsonName, isNullable, false);
    }

    /// <inheritdoc />
    protected override string ParseArrayType(ParsedJsonProperty property, IReadOnlyList<ParsedJsonProperty> childrenTypes, out string typeName)
    {
        var jsonName = property.JsonName!;
        var name = GetSafeFieldName(jsonName);
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
    private void BuildClassMembers(StringBuilder stringBuilder, List<string> extraTypes, IReadOnlyList<ParsedJsonProperty> properties)
    {
        var fields = new List<(string Name, string Type, string JsonName, bool IsNullable, bool IsList)>();

        foreach (var property in properties)
        {
            var jsonName = property.JsonName!;
            var fieldName = GetSafeFieldName(jsonName);
            var isNullable = J2SUtils.IsPropertyNullable(property.JsonElement);
            var isList = false;
            string fieldType;

            if (property.JsonElement.ValueKind is JsonValueKind.Object)
            {
                fieldType = GetObjectTypeName(property, Language.Java);
                extraTypes.Add(InternalParse(fieldType, property.JsonElement, false));
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
                        extraTypes.Add(InternalParse(arrayElementTypeName, childrenTypes[0].JsonElement, false));
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
        foreach (var field in fields)
        {
            var getterName = "get" + field.Name.ToPascalCase();
            stringBuilder.AppendLine($"{_indentationPadding}public {field.Type} {getterName}() {{");
            stringBuilder.AppendLine($"{_indentationPadding}{_indentationPadding}return {field.Name};");
            stringBuilder.AppendLine($"{_indentationPadding}}}");
            stringBuilder.AppendLine();

            var setterName = "set" + field.Name.ToPascalCase();
            stringBuilder.AppendLine($"{_indentationPadding}public void {setterName}({field.Type} {field.Name}) {{");
            stringBuilder.AppendLine($"{_indentationPadding}{_indentationPadding}this.{field.Name} = {field.Name};");
            stringBuilder.AppendLine($"{_indentationPadding}}}");
            stringBuilder.AppendLine();
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
    /// Gets a safe field name that does not conflict with Java keywords or start with a digit.
    /// </summary>
    /// <param name="name">The name to be processed.</param>
    /// <returns>A safe field name.</returns>
    private static string GetSafeFieldName(string name)
    {
        var camelCaseName = name.ToCamelCase();
        return (_javaKeywords.Contains(camelCaseName) || char.IsDigit(camelCaseName[0]))
            ? "json2sharp" + camelCaseName.ToPascalCase()
            : camelCaseName;
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
    /// Collects the necessary imports based on the properties and configuration.
    /// </summary>
    /// <param name="properties">The properties to be processed.</param>
    /// <param name="imports">The set to collect the imports into.</param>
    private void CollectImports(IReadOnlyList<ParsedJsonProperty> properties, HashSet<string> imports)
    {
        if (_serializationAnnotation is JavaSerializationAnnotation.Jackson) imports.Add("com.fasterxml.jackson.annotation.JsonProperty");
        if (_serializationAnnotation is JavaSerializationAnnotation.Gson) imports.Add("com.google.gson.annotations.SerializedName");
        if (_serializationAnnotation is JavaSerializationAnnotation.Moshi) imports.Add("com.squareup.moshi.Json");

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
            
            if (prop.JsonElement.ValueKind is JsonValueKind.Array && prop.BclType != typeof(byte[]))
            {
                imports.Add("java.util.ArrayList");
                imports.Add("java.util.List");
            }

            if (prop.Children.Count > 0)
                CollectImports(prop.Children, imports);
        }
    }
}