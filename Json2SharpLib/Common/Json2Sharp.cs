using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Emitters.CSharp;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text.Json;

namespace Json2SharpLib.Common;

/// <summary>
/// Contains methods to parse raw JSON data into a type declaration.
/// </summary>
public static class Json2Sharp
{
    private static readonly JsonDocumentOptions _jsonOptions = new()
    {
        AllowTrailingCommas = true,
        CommentHandling = JsonCommentHandling.Skip
    };

    /// <summary>
    /// Parses raw JSON data into a C# record.
    /// </summary>
    /// <param name="objectName">The name of the record.</param>
    /// <param name="rawJson">The raw JSON data.</param>
    /// <returns>A C# record declaration.</returns>
    public static string Parse(string objectName, string rawJson)
        => Parse(objectName, rawJson, new Json2SharpOptions());

    /// <summary>
    /// Parses raw JSON data into a type declaration specified by <paramref name="options"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="rawJson">The raw JSON data.</param>
    /// <param name="options">The parsing options.</param>
    /// <returns>A type declaration.</returns>
    public static string Parse(string objectName, string rawJson, Json2SharpOptions options)
        => Parse(objectName, rawJson, GetLanguageEmitter(options));

    /// <summary>
    /// Parses raw JSON data into a type declaration emitted by <paramref name="emitter"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="rawJson">The raw JSON data.</param>
    /// <param name="emitter">An object that converts JSON data into a language type definition.</param>
    /// <returns>A type declaration.</returns>
    public static string Parse(string objectName, string rawJson, ICodeEmitter emitter)
    {
        using var jsonDocument = JsonDocument.Parse(rawJson, _jsonOptions);
        return emitter.Parse(objectName, jsonDocument.RootElement);
    }

    /// <summary>
    /// Parses a JSON object into their individual properties.
    /// </summary>
    /// <param name="jsonElement">The JSON object to be parsed.</param>
    /// <returns>The properties of the JSON object.</returns>
    public static IReadOnlyList<ParsedJsonProperty> ParseProperties(JsonElement jsonElement)
    {
        if (jsonElement.ValueKind is JsonValueKind.Object)
        {
            return jsonElement.EnumerateObject()
                .Select(jsonProperty =>
                    new ParsedJsonProperty(
                        jsonProperty.Name,
                        Utilities.ToPascalCase(jsonProperty.Name),
                        jsonProperty.Value,
                        jsonProperty.Value.ToBclType(),
                        (jsonProperty.Value.ValueKind is JsonValueKind.Array or JsonValueKind.Object)
                            ? ParseProperties(jsonProperty.Value)
                            : Array.Empty<ParsedJsonProperty>()
                    )
                )
                .ToImmutableArray();
        }
        else if (jsonElement.ValueKind is JsonValueKind.Array)
        {
            return jsonElement.EnumerateArray()
                .Select((jsonElem, index) =>
                    new ParsedJsonProperty(
                        null,
                        null,
                        jsonElem,
                        jsonElem.ToBclType(),
                        (jsonElem.ValueKind is JsonValueKind.Array or JsonValueKind.Object)
                            ? ParseProperties(jsonElem)
                            : Array.Empty<ParsedJsonProperty>()
                    )
                )
                .ToImmutableArray();
        }

        return Array.Empty<ParsedJsonProperty>();
    }

    /// <summary>
    /// Gets the appropriate emitter for the given parsing <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The parsing options.</param>
    /// <returns>The emitter specified by the <paramref name="options"/>.</returns>
    /// <exception cref="UnreachableException">Occurs when a language lacks an emitter implementation.</exception>
    private static ICodeEmitter GetLanguageEmitter(Json2SharpOptions options)
    {
        return options.TargetLanguage switch
        {
            Language.CSharp when options.CSharp.TargetType is CSharpObjectType.Record
                && options.CSharp.SerializationAttribute is CSharpSerializationAttribute.NewtonsoftJson => new CSharpRecordEmitter(options.CSharp),
            Language.CSharp => new CSharpClassEmitter(options.CSharp),
            _ => throw new UnreachableException($"Emitter for language {options.TargetLanguage} was not implemented."),
        };
    }
}