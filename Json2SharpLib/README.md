# Json2Sharp

Json2Sharp is a library that converts a JSON object to a programming language type definition (i.e. a class).

To perform a conversion, call the `Parse` method from the `Json2Sharp` class.

```cs
string code = Json2Sharp.Parse("Person", """{ "id": 1, "name": "John" }""");
/*
 * public sealed record Person
 * {
 *     [JsonPropertyName("id")]
 *     public int Id { get; init; }
 * 
 *     [JsonPropertyName("name")]
 *     public string Name { get; init; }
 * }
 */
```

You can also customize the conversion by initializing a `Json2SharpOptions` object and populating its members to suit your needs.

```cs
Json2SharpOptions options = new()
{
    TargetLanguage = Language.CSharp,
    CSharp = new()
    {
        IsSealed = false,
        TargetType = CSharpObjectType.Record,
        SerializationAttribute = CSharpSerializationAttribute.NewtonsoftJson
    }
};

string code = Json2Sharp.Parse(className, rawJson, options);
/*
 * public record Person(
 *     [JsonProperty("id")] int Id,
 *     [JsonProperty("name")] string Name
 * );
 */
```