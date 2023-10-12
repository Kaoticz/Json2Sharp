using Json2SharpLib.Common;
using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Emitters.CSharp;

internal sealed class CSharpRecordEmitter : ICodeEmitter
{
    private readonly string _accessibility;
    private readonly string _serializationAttribute;
    private readonly string _indentationPadding;

    internal CSharpRecordEmitter(Json2SharpCSharpOptions options)
    {
        _accessibility = options.AccessibilityLevel.ToCode() + (options.IsSealed ? " sealed" : string.Empty);
        _serializationAttribute = options.SerializationAttribute.ToCode();
        _indentationPadding = options.IndentationPadding;
    }

    public string Parse(string objectName, JsonElement jsonElement)
    {
        var properties = Json2Sharp.ParseProperties(jsonElement);

        if (properties.Count is 0)
            return string.Empty;

        var extraTypes = new List<string>();
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"{_accessibility} record {objectName}(");

        foreach (var property in properties)
        {
            var bclTypeName = Utilities.TryGetAliasName(property.BclType, out var aliasName)
                ? aliasName
                : property.BclType.Name;

            if (HandleCustomType(property, stringBuilder, bclTypeName, extraTypes))
                continue;

            stringBuilder.AppendLine(
                CreateMemberDeclaration(
                    _indentationPadding,
                    _serializationAttribute,
                    property.JsonName!,
                    bclTypeName + (property.JsonElement.ValueKind is JsonValueKind.Null ? "?" : string.Empty),
                    property.FinalName!
                )
            );
        }

        stringBuilder.Append(");");

        if (extraTypes.Count is not 0)
        {
            stringBuilder.AppendLine(Environment.NewLine);
            stringBuilder.AppendJoin(Environment.NewLine + Environment.NewLine, extraTypes);
        }

        var result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }

    private bool HandleCustomType(JsonClassProperty property, StringBuilder stringBuilder, string bclTypeName, IList<string> extraTypes)
    {
        if (property.BclType == typeof(object) && property.JsonElement.ValueKind is JsonValueKind.Object)
        {
            extraTypes.Add(Parse(property.FinalName ?? property.BclType.Name, property.JsonElement));
            stringBuilder.AppendLine(CreateMemberDeclaration(_indentationPadding, _serializationAttribute, property.JsonName!, property.FinalName!, property.FinalName!));

            return true;
        }
        else if (property.BclType == typeof(object[]))
        {
            var childrenTypes = property.Children
                .DistinctBy(x => x.BclType)
                .ToArray();

            if (childrenTypes.Length is 1)
            {
                extraTypes.Add(Parse(property.FinalName ?? bclTypeName, childrenTypes[0].JsonElement));
                stringBuilder.AppendLine(CreateMemberDeclaration(_indentationPadding, _serializationAttribute, property.JsonName!, property.FinalName + "[]", property.FinalName!));

                return true;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string CreateMemberDeclaration(string indentationPadding, string serializationAttributeName, string jsonName, string targetTypeName, string propertyName)
        => $"{indentationPadding}[{serializationAttributeName}(\"{jsonName}\")] {targetTypeName} {propertyName}";
}