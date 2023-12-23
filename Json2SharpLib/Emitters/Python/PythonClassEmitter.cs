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
/// Parses JSON data into a Python type declaration.
/// </summary>
internal sealed class PythonClassEmitter : ICodeEmitter
{
    private int _stackCounter;
    private readonly bool _addTypeHint;
    private readonly string _indentationPadding;

    /// <summary>
    /// Creates an object that parses JSON data into a Python type declaration.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    internal PythonClassEmitter(Json2SharpPythonOptions options)
    {
        _addTypeHint = options.AddTypeHints;
        _indentationPadding = new string(
            options.IndentationPaddingCharacter is IndentationCharacterType.Space ? ' ' : '\t',
            options.IndentationCharacterAmount
        );
    }

    /// <inheritdoc />
    public string Parse(string objectName, JsonElement jsonElement)
    {
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        _stackCounter++;

        var stringBuilder = BuildConstructorSignature(objectName, properties, out var extraTypes);

        // Build the body of the constructor
        foreach (var property in properties)
            stringBuilder.AppendIndentedLine($"self.{property.JsonName} = {property.JsonName}", _indentationPadding, 2);

        // Add extra types at the top
        AddCustomTypes(stringBuilder, extraTypes);

        // Add the imports
        AddImports(stringBuilder);

        // Remove the last newline
        if (_stackCounter == default)
            stringBuilder.Remove(stringBuilder.Length - Environment.NewLine.Length, Environment.NewLine.Length);

        return stringBuilder.ToStringAndClear();
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

            if (HandleCustomType(property, stringBuilder, isNullable, extraTypes))
                continue;

            var type = (_addTypeHint && J2SUtils.TryGetAliasName(property.BclType, Language.Python, out var aliasName))
                ? ": " + ((isNullable) ? $"Optional[{aliasName}]" : aliasName)
                : string.Empty;

            stringBuilder.AppendIndentedLine($"{property.JsonName}{type},", _indentationPadding, 2);
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
            stringBuilder.Insert(0, Environment.NewLine);
            stringBuilder.Insert(0, string.Join(Environment.NewLine, sanitizedExtraTypes));

            return true;
        }

        return false;
    }

    /// <summary>
    /// Adds imports to the top of the class definition.
    /// </summary>
    /// <param name="stringBuilder">The string builder that contains the class definition.</param>
    /// <returns><see langword="true"/> if imports were added, <see langword="false"/> otherwise.</returns>
    private bool AddImports(StringBuilder stringBuilder)
    {
        if (--_stackCounter != default || !_addTypeHint)
            return false;

        var namespaces = new List<string>(3);

        if (stringBuilder.Contains("Any"))
            namespaces.Add("Any");

        if (stringBuilder.Contains("List["))
            namespaces.Add("List");

        if (stringBuilder.Contains("Optional["))
            namespaces.Add("Optional");

        if (namespaces.Count is not 0)
            stringBuilder.Insert(0, Constants.PythonTypeImportBase + string.Join(", ", namespaces) + Environment.NewLine + Environment.NewLine);

        return namespaces.Count is not 0;
    }

    /// <summary>
    /// Parses an <see langword="object"/> or <see langword="object[]"/> JSON <paramref name="property"/>.
    /// </summary>
    /// <param name="property">The property to be processed.</param>
    /// <param name="stringBuilder">The string builder used to build the type declaration.</param>
    /// <param name="isNullable">Determines whether the <paramref name="property"/> is nullable or not.</param>
    /// <param name="extraTypes">The list that contains the definitions of custom types in the JSON data.</param>
    /// <returns><see langword="true"/> if <paramref name="property"/> was parsed, <see langword="false"/> otherwise.</returns>
    private bool HandleCustomType(ParsedJsonProperty property, StringBuilder stringBuilder, bool isNullable, List<string> extraTypes)
    {
        if (property.BclType == typeof(object) && property.JsonElement.ValueKind is JsonValueKind.Object)
        {
            var typeName = (_addTypeHint)
                ? ": " + ((property.JsonElement.EnumerateObject().Any()) ? J2SUtils.ToPascalCase(property.JsonName) : "Any")
                : string.Empty;

            extraTypes.Add(Parse(J2SUtils.ToPascalCase(property.JsonName!), property.JsonElement));
            stringBuilder.AppendIndentedLine($"{property.JsonName}{typeName},", _indentationPadding, 2);

            return true;
        }
        else if (property.BclType == typeof(object[]))
        {
            var childrenTypes = property.Children
                .DistinctBy(x => x.JsonElement.ValueKind)
                .ToArray();

            if (childrenTypes.Count(x => x.JsonElement.ValueKind is not JsonValueKind.Null) is 1)
            {
                var className = J2SUtils.ToPascalCase(property.JsonName!);
                var child = childrenTypes.First(x => x.JsonElement.ValueKind is not JsonValueKind.Null);
                var typeName = (childrenTypes.Length is not 1 && J2SUtils.TryGetAliasName(child.BclType, Language.Python, out var aliasName))
                    ? (aliasName is "Any") ? className : aliasName  // CustomType or alias
                    : className ?? "Any";                           // CustomType or Any

                var finalName = (isNullable)
                    ? $"Optional[{typeName}]"
                    : typeName;

                extraTypes.Add(Parse(typeName, childrenTypes[0].JsonElement));
                stringBuilder.AppendIndentedLine($"{property.JsonName}{((_addTypeHint) ? $": List[{finalName}]" : string.Empty)},", _indentationPadding, 2);

                return true;
            }
        }

        return false;
    }
}