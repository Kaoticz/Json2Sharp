using Json2SharpLib.Emitters;
using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text.Json;

namespace Json2SharpLib.Common;

public static class Json2Sharp
{
    private static readonly JsonDocumentOptions _jsonOptions = new() { CommentHandling = JsonCommentHandling.Skip };

    public static string Parse(string objectName, string rawJson)
        => Parse(objectName, rawJson, new Json2SharpOptions());

    public static string Parse(string objectName, string rawJson, Json2SharpOptions options)
        => Parse(objectName, rawJson, GetLanguageEmitter(options));

    public static string Parse(string objectName, string rawJson, ICodeEmitter emitter)
    {
        using var jsonDocument = JsonDocument.Parse(rawJson, _jsonOptions);
        return emitter.Parse(objectName, jsonDocument.RootElement);
    }

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

    private static ICodeEmitter GetLanguageEmitter(Json2SharpOptions options)
    {
        return options.TargetLanguage switch
        {
            Language.CSharp when options.CSharp.TargetType is CSharpObjectType.Record => new CSharpRecordEmitter(options.CSharp),
            _ => throw new UnreachableException($"Emitter for language {options.TargetLanguage} was not implemented."),
        };
    }
}