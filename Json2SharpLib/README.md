
[![NuGet Badge][Nuget-Badge]][Nuget-Url]
[![NuGet Nightly Badge][Nuget-Nightly-Badge]][Nuget-Url]

# Json2Sharp

Json2Sharp is a library that converts a JSON object to a class definition (or an equivalent for the target language).

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
    CSharpOptions = new()
    {
        IsSealed = false,
        IsPropertyRequired = false,
        TargetType = CSharpObjectType.Class,
        SerializationAttribute = CSharpSerializationAttribute.NewtonsoftJson
    }
};

string code = Json2Sharp.Parse(className, rawJson, options);
/*
 * using Newtonsoft.Json;
 *
 * public sealed class Person
 * {
 *     [JsonProperty("id")]
 *     public int Id { get; init; }
 *
 *     [JsonProperty("name")]
 *     public string Name { get; init; }
 * }
 */
```

[Nuget-Badge]: https://img.shields.io/nuget/v/Json2Sharp.svg?label=NuGet
[Nuget-Nightly-Badge]: https://img.shields.io/nuget/vpre/Json2Sharp?color=00007f&label=NuGet%20Nightly
[Nuget-Url]: https://www.nuget.org/packages/Json2Sharp