using Json2SharpLib.Emitters;
using Json2SharpLib.Models;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Json2SharpLib.Common;

public static class Json2Sharp
{
    private static readonly JsonDocumentOptions _jsonOptions = new() { CommentHandling = JsonCommentHandling.Skip };

    public static string Parse(string objectName, string rawJson)
    {
        var jsonDocument = JsonDocument.Parse(rawJson, _jsonOptions);

        var emitter = new CSharpRecordEmitter();

        return emitter.Parse(objectName, jsonDocument.RootElement);
    }

    // TODO: create ParseArrayProperties
    public static IReadOnlyList<JsonClassProperty> ParseProperties(JsonElement jsonElement)
    {
        if (jsonElement.ValueKind is JsonValueKind.Object)
        {
            return jsonElement.EnumerateObject()
                .Select(jsonProperty =>
                    new JsonClassProperty(
                        jsonProperty.Name,
                        Utilities.ToPascalCase(jsonProperty.Name),
                        jsonProperty.Value,
                        jsonProperty.Value.ToBclType(),
                        (jsonProperty.Value.ValueKind is JsonValueKind.Array or JsonValueKind.Object)
                            ? ParseProperties(jsonProperty.Value)
                            : Array.Empty<JsonClassProperty>()
                    )
                )
                .ToImmutableArray();
        }
        else if (jsonElement.ValueKind is JsonValueKind.Array)
        {
            return jsonElement.EnumerateArray()
                .Select((jsonElem, index) =>
                    new JsonClassProperty(
                        null,
                        null,
                        jsonElem,
                        jsonElem.ToBclType(),
                        (jsonElem.ValueKind is JsonValueKind.Array or JsonValueKind.Object)
                            ? ParseProperties(jsonElem)
                            : Array.Empty<JsonClassProperty>()
                    )
                )
                .ToImmutableArray();
        }

        return Array.Empty<JsonClassProperty>();
    }
}