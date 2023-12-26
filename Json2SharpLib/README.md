
[![NuGet Badge][Nuget-Badge]][Nuget-Url]
[![NuGet Nightly Badge][Nuget-Nightly-Badge]][Nuget-Url]

# Json2Sharp

Json2Sharp is a library that converts a JSON object to a programming language type definition (i.e. a class).

To perform a conversion, call the `Parse` method from the `Json2Sharp` class.

```cs
string code = Json2Sharp.Parse("Person", """{ "id": 1, "name": "John" }""");
/*
 * using System.Text.Json.Serialization;
 *
 * public sealed record Person(
 *     [property: JsonPropertyName("id")] int Id,
 *     [property: JsonPropertyName("name")] bool Name
 * );
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
 * using Newtonsoft.Json;
 *
 * public record Person(
 *     [JsonProperty("id")] int Id,
 *     [JsonProperty("name")] string Name
 * );
 */
```

[Nuget-Badge]: https://img.shields.io/nuget/v/Json2Sharp.svg?label=NuGet
[Nuget-Nightly-Badge]: https://img.shields.io/nuget/vpre/Json2Sharp?color=00007f&label=NuGet%20Nightly
[Nuget-Url]: https://www.nuget.org/packages/Json2Sharp