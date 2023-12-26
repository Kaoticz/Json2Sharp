using Json2SharpLib.Emitters.Abstractions;
using Json2SharpLib.Emitters.CSharp;
using Json2SharpLib.Emitters.Python;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using System.Buffers;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Text.Json;

namespace Json2SharpLib;

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

    #region Parse - string

    /// <summary>
    /// Parses raw JSON data into a C# record.
    /// </summary>
    /// <param name="objectName">The name of the record.</param>
    /// <param name="rawJson">The raw JSON data.</param>
    /// <returns>A C# record declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="rawJson"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, string rawJson)
        => Parse(objectName, rawJson, new Json2SharpOptions());

    /// <summary>
    /// Parses raw JSON data into a type declaration specified by <paramref name="options"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="rawJson">The raw JSON data.</param>
    /// <param name="options">The parsing options.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="rawJson"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, string rawJson, Json2SharpOptions options)
        => Parse(objectName, rawJson, GetLanguageEmitter(options));

    /// <summary>
    /// Parses raw JSON data into a type declaration emitted by <paramref name="emitter"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="rawJson">The raw JSON data.</param>
    /// <param name="emitter">An object that converts JSON data into a language type definition.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="rawJson"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, string rawJson, ICodeEmitter emitter)
    {
        using var jsonDocument = JsonDocument.Parse(rawJson, _jsonOptions);
        return emitter.Parse(objectName, jsonDocument.RootElement);
    }

    #endregion

    #region Parse - Stream

    /// <summary>
    /// Parses raw JSON data into a C# record.
    /// </summary>
    /// <param name="objectName">The name of the record.</param>
    /// <param name="utf8Json">The raw JSON data in UTF-8.</param>
    /// <returns>A C# record declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, Stream utf8Json)
        => Parse(objectName, utf8Json, new Json2SharpOptions());

    /// <summary>
    /// Parses raw JSON data into a type declaration specified by <paramref name="options"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="utf8Json">The raw JSON data in UTF-8.</param>
    /// <param name="options">The parsing options.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, Stream utf8Json, Json2SharpOptions options)
        => Parse(objectName, utf8Json, GetLanguageEmitter(options));

    /// <summary>
    /// Parses raw JSON data into a type declaration emitted by <paramref name="emitter"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="utf8Json">The raw JSON data in UTF-8.</param>
    /// <param name="emitter">An object that converts JSON data into a language type definition.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, Stream utf8Json, ICodeEmitter emitter)
    {
        using var jsonDocument = JsonDocument.Parse(utf8Json, _jsonOptions);
        return emitter.Parse(objectName, jsonDocument.RootElement);
    }

    #endregion

    #region Parse - ReadOnlyMemory<char>

    /// <summary>
    /// Parses raw JSON data into a C# record.
    /// </summary>
    /// <param name="objectName">The name of the record.</param>
    /// <param name="rawJson">The raw JSON data.</param>
    /// <returns>A C# record declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="rawJson"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, ReadOnlyMemory<char> rawJson)
        => Parse(objectName, rawJson, new Json2SharpOptions());

    /// <summary>
    /// Parses raw JSON data into a type declaration specified by <paramref name="options"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="rawJson">The raw JSON data.</param>
    /// <param name="options">The parsing options.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="rawJson"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, ReadOnlyMemory<char> rawJson, Json2SharpOptions options)
        => Parse(objectName, rawJson, GetLanguageEmitter(options));

    /// <summary>
    /// Parses raw JSON data into a type declaration emitted by <paramref name="emitter"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="rawJson">The raw JSON data.</param>
    /// <param name="emitter">An object that converts JSON data into a language type definition.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="rawJson"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, ReadOnlyMemory<char> rawJson, ICodeEmitter emitter)
    {
        using var jsonDocument = JsonDocument.Parse(rawJson, _jsonOptions);
        return emitter.Parse(objectName, jsonDocument.RootElement);
    }

    #endregion

    #region Parse - ReadOnlyMemory<byte>

    /// <summary>
    /// Parses raw JSON data into a C# record.
    /// </summary>
    /// <param name="objectName">The name of the record.</param>
    /// <param name="utf8Json">The raw JSON data in UTF-8.</param>
    /// <returns>A C# record declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, ReadOnlyMemory<byte> utf8Json)
        => Parse(objectName, utf8Json, new Json2SharpOptions());

    /// <summary>
    /// Parses raw JSON data into a type declaration specified by <paramref name="options"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="utf8Json">The raw JSON data in UTF-8.</param>
    /// <param name="options">The parsing options.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, ReadOnlyMemory<byte> utf8Json, Json2SharpOptions options)
        => Parse(objectName, utf8Json, GetLanguageEmitter(options));

    /// <summary>
    /// Parses raw JSON data into a type declaration emitted by <paramref name="emitter"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="utf8Json">The raw JSON data in UTF-8.</param>
    /// <param name="emitter">An object that converts JSON data into a language type definition.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, ReadOnlyMemory<byte> utf8Json, ICodeEmitter emitter)
    {
        using var jsonDocument = JsonDocument.Parse(utf8Json, _jsonOptions);
        return emitter.Parse(objectName, jsonDocument.RootElement);
    }

    #endregion

    #region Parse - ReadOnlySequence<byte>

    /// <summary>
    /// Parses raw JSON data into a C# record.
    /// </summary>
    /// <param name="objectName">The name of the record.</param>
    /// <param name="utf8Json">The raw JSON data in UTF-8.</param>
    /// <returns>A C# record declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, ReadOnlySequence<byte> utf8Json)
        => Parse(objectName, utf8Json, new Json2SharpOptions());

    /// <summary>
    /// Parses raw JSON data into a type declaration specified by <paramref name="options"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="utf8Json">The raw JSON data in UTF-8.</param>
    /// <param name="options">The parsing options.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, ReadOnlySequence<byte> utf8Json, Json2SharpOptions options)
        => Parse(objectName, utf8Json, GetLanguageEmitter(options));

    /// <summary>
    /// Parses raw JSON data into a type declaration emitted by <paramref name="emitter"/>.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="utf8Json">The raw JSON data in UTF-8.</param>
    /// <param name="emitter">An object that converts JSON data into a language type definition.</param>
    /// <returns>A type declaration.</returns>
    /// <exception cref="JsonException">Occurs when <paramref name="utf8Json"/> does not represent a valid single JSON value.</exception>
    public static string Parse(string objectName, ReadOnlySequence<byte> utf8Json, ICodeEmitter emitter)
    {
        using var jsonDocument = JsonDocument.Parse(utf8Json, _jsonOptions);
        return emitter.Parse(objectName, jsonDocument.RootElement);
    }

    #endregion

    /// <summary>
    /// Parses a JSON object into their individual properties.
    /// </summary>
    /// <param name="jsonElement">The JSON object to be parsed.</param>
    /// <returns>The properties of the JSON object.</returns>
    public static IReadOnlyList<ParsedJsonProperty> ParseProperties(JsonElement jsonElement)
    {
        if (jsonElement.ValueKind is JsonValueKind.Object)
        {
            using var jsonEnumerator = jsonElement.EnumerateObject();

            return jsonEnumerator
                .Select(jsonProperty =>
                    new ParsedJsonProperty(
                        jsonProperty.Name,
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
            using var jsonEnumerator = jsonElement.EnumerateArray();

            return jsonEnumerator
                .Select(jsonElem =>
                    new ParsedJsonProperty(
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
            Language.CSharp when options.CSharpOptions.TargetType is CSharpObjectType.Record
                && options.CSharpOptions.SetterType is CSharpSetterType.Init => new CSharpRecordEmitter(options.CSharpOptions),
            Language.CSharp => new CSharpClassEmitter(options.CSharpOptions),
            Language.Python => new PythonClassEmitter(options.PythonOptions),
            _ => throw new UnreachableException($"Emitter for language {options.TargetLanguage} was not implemented."),
        };
    }
}