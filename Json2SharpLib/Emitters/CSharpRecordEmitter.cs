using Json2SharpLib.Common;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Emitters;

internal sealed class CSharpRecordEmitter
{
    private readonly string _accessibility;
    private readonly string _indentationPadding;

    internal CSharpRecordEmitter(CSharpAccessibilityLevel accessibilityLevel, bool isSealed = true, string indentationPadding = Constants.IndentationPadding)
        : this(accessibilityLevel.ToCode() + ((isSealed) ? " sealed" : string.Empty), indentationPadding)
    {
    }

    internal CSharpRecordEmitter(string accessibility = Constants.CSharpDefaultAccessibility, string indentationPadding = Constants.IndentationPadding)
    {
        _accessibility = accessibility ?? Constants.CSharpDefaultAccessibility;
        _indentationPadding = indentationPadding ?? Constants.IndentationPadding;
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

            if (property.BclType == typeof(object))
            {
                extraTypes.Add(Parse(property.FinalName ?? property.BclType.Name, property.JsonElement));
                stringBuilder.AppendLine($"{_indentationPadding}[JsonPropertyName(\"{property.JsonName}\")] {property.FinalName} {property.FinalName}");

                continue;
            }
            else if (property.BclType == typeof(object[]))
            {
                var childrenTypes = property.Children
                    .DistinctBy(x => x.BclType)
                    .ToArray();

                if (childrenTypes.Length is 1)
                {
                    extraTypes.Add(Parse(property.FinalName ?? bclTypeName, childrenTypes[0].JsonElement));
                    stringBuilder.AppendLine($"{_indentationPadding}[JsonPropertyName(\"{property.JsonName}\")] {property.FinalName}[] {property.FinalName}");
                    
                    continue;
                }
            }
            
            stringBuilder.AppendLine($"{_indentationPadding}[JsonPropertyName(\"{property.JsonName}\")] {bclTypeName} {property.FinalName}");
        }

        stringBuilder.Append(");");

        if (extraTypes.Count is not 0)
            stringBuilder.AppendJoin(Environment.NewLine + Environment.NewLine, extraTypes);

        var result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }
}