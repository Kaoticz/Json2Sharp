using Json2SharpLib.Common;
using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Emitters.CSharp;

internal sealed class CSharpClassEmitter : ICodeEmitter
{
    private readonly string _accessibility;
    private readonly string _serializationAttribute;
    private readonly string _indentationPadding;
    private readonly string _setterType;

    internal CSharpClassEmitter(Json2SharpCSharpOptions options)
    {
        _accessibility = options.AccessibilityLevel.ToCode() + (options.IsSealed ? " sealed" : string.Empty);
        _serializationAttribute = options.SerializationAttribute.ToCode();
        _indentationPadding = options.IndentationPadding;
        _setterType = options.SetterType.ToCode();
    }

    public string Parse(string objectName, JsonElement jsonElement)
    {
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var extraTypes = new List<string>();
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"{_accessibility} class {objectName}");
        stringBuilder.AppendLine("{");

        foreach (var property in properties)
        {
            var bclTypeName = Utilities.TryGetAliasName(property.BclType, out var aliasName)
                ? aliasName
                : property.BclType.Name;

            var nullableAnnotation = (property.JsonElement.ValueKind is JsonValueKind.Null
                || (property.JsonElement.ValueKind is JsonValueKind.Array && property.JsonElement.EnumerateArray().Any(x => x.ValueKind is JsonValueKind.Null)))
                ? "?"
                : string.Empty;

            if (HandleCustomType(property, stringBuilder, bclTypeName, nullableAnnotation, extraTypes))
                continue;

            stringBuilder.AppendLine(CreateMemberAttribute(_indentationPadding, _serializationAttribute, property.JsonName!));
            stringBuilder.AppendLine(
                CreateMemberDeclaration(
                    _indentationPadding,
                    (property.JsonElement.ValueKind is not JsonValueKind.Array)
                        ? bclTypeName + nullableAnnotation
                        : bclTypeName,
                    property.FinalName!,
                    _setterType
                )
            );
            stringBuilder.AppendLine();
        }

        stringBuilder.Remove(stringBuilder.Length - (Environment.NewLine.Length + 1), 1);
        stringBuilder.Append('}');

        if (extraTypes.Count is not 0)
            stringBuilder.AppendJoin(Environment.NewLine + Environment.NewLine, extraTypes);

        var result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }

    private bool HandleCustomType(JsonClassProperty property, StringBuilder stringBuilder, string bclTypeName, string nullableAnnotation, IList<string> extraTypes)
    {
        if (property.BclType == typeof(object) && property.JsonElement.ValueKind is JsonValueKind.Object)
        {
            extraTypes.Add(Parse(property.FinalName ?? property.BclType.Name, property.JsonElement));
            stringBuilder.AppendLine(CreateMemberAttribute(_indentationPadding, _serializationAttribute, property.JsonName!));
            stringBuilder.AppendLine(CreateMemberDeclaration(_indentationPadding, property.FinalName!, property.FinalName!, _setterType));
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
                var child = childrenTypes.First(x => x.JsonElement.ValueKind is not JsonValueKind.Null);
                var typeName = (childrenTypes.Length is not 1 && Utilities.TryGetAliasName(child.BclType, out var aliasName))
                    ? (aliasName == "object") ? property.FinalName! : aliasName
                    : property.FinalName ?? bclTypeName;

                extraTypes.Add(Parse(typeName, childrenTypes[0].JsonElement));
                stringBuilder.AppendLine(CreateMemberAttribute(_indentationPadding, _serializationAttribute, property.JsonName!));
                stringBuilder.AppendLine(CreateMemberDeclaration(_indentationPadding, typeName + nullableAnnotation + "[]", property.FinalName!, _setterType));
                stringBuilder.AppendLine();

                return true;
            }
        }

        return false;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateMemberAttribute(string indentationPadding, string serializationAttributeName, string jsonName)
        => $"{indentationPadding}[{serializationAttributeName}(\"{jsonName}\")]";


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateMemberDeclaration(string indentationPadding, string targetTypeName, string propertyName, string setterType)
        => $"{indentationPadding}public {targetTypeName} {propertyName} {{ get; {setterType}; }}";
}