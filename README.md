[![.NET Unit Tests][.NET-Badge]][.NET-Url]
[![CodeQL][CodeQL-Badge]][CodeQL-Url]
[![CodeFactor][CodeFactor-Badge]][CodeFactor-Url]
[![NuGet Downloads][Nuget-Downloads]][Nuget-Url]
[![NuGet Badge][Nuget-Badge]][Nuget-Url]
[![NuGet Nightly Badge][Nuget-Nightly-Badge]][Nuget-Url]

# Json2Sharp

> *Because life is too short to map data by hand.*

Json2Sharp is a CLI application that converts a JSON object to a class definition (or an equivalent for the target language).

Currently, C# and Python are supported. We're open to contributions. If you'd like to add your favorite language to the mix, feel free to open a pull request!

## Installation

If you have `dotnet` installed, you can install Json2Sharp as a NuGet tool.

```bash
dotnet tool install -g json2sharp-cli
```

Other packaging options are listed in the [wiki][GithubWiki].

## Quick start

Pipe JSON data directly into Json2Sharp.

```bash
$ curl -s https://api.isevenapi.xyz/api/iseven/6 | json2sharp
using System.Text.Json.Serialization;

public sealed record Root(
    [property: JsonPropertyName("ad")] string Ad,
    [property: JsonPropertyName("iseven")] bool Iseven
);
```
To generate the same output in Python, use --config:
```bash
$ curl -s https://api.isevenapi.xyz/api/iseven/6 | json2sharp --config python
@dataclass
class Root:
    ad: str
    iseven: bool
```
Or pass the JSON data to the `--json`/`-j` option.

```bash
$ json2sharp -j "{ \"ad\": \"Some ad here\", \"iseven\": false }"
using System.Text.Json.Serialization;

public sealed record Root(
    [property: JsonPropertyName("ad")] string Ad,
    [property: JsonPropertyName("iseven")] bool Iseven
);
```
For Python:
```bash
$ json2sharp -j "{ \"ad\": \"Some ad here\", \"iseven\": false }" --config python 
```
Or tell it to use a file as input.

```bash
$ json2sharp -i IsEven.json
using System.Text.Json.Serialization;

public sealed record Root(
    [property: JsonPropertyName("ad")] string Ad,
    [property: JsonPropertyName("iseven")] bool Iseven
);
```
For Python:
```bash
$ json2sharp -i IsEven.json --config python
```
You can also save the result to a file.

```bash
$ curl -s https://api.isevenapi.xyz/api/iseven/6 | json2sharp -o IsEven.cs
$ cat IsEven.cs
using System.Text.Json.Serialization;

public sealed record Root(
    [property: JsonPropertyName("ad")] string Ad,
    [property: JsonPropertyName("iseven")] bool Iseven
);
```
```bash
$ curl -s https://api.isevenapi.xyz/api/iseven/6 | json2sharp -o IsEven.cs --config python
```
For additional options, please visit the [wiki][GithubWiki].

## NuGet

Json2Sharp is also available as a library on NuGet. To add it to your .NET project, simply run the following command.

```
dotnet add package Json2Sharp
```

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

## License

Copyright 2023 Kotz

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

> http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

[GithubWiki]: ../../wiki
[CodeFactor-Url]: https://www.codefactor.io/repository/github/kaoticz/json2sharp/overview/main
[CodeFactor-Badge]: https://www.codefactor.io/repository/github/kaoticz/json2sharp/badge/main
[.NET-Url]: ../../actions/workflows/dotnet.yml
[.NET-Badge]: ../../actions/workflows/dotnet.yml/badge.svg
[CodeQL-Url]: ../../actions/workflows/codeql.yml
[CodeQL-Badge]: ../../actions/workflows/codeql.yml/badge.svg
[Nuget-Badge]: https://img.shields.io/nuget/v/Json2Sharp.svg?label=NuGet
[Nuget-Downloads]: https://img.shields.io/nuget/dt/Json2Sharp
[Nuget-Nightly-Badge]: https://img.shields.io/nuget/vpre/Json2Sharp?color=00007f&label=NuGet%20Nightly
[Nuget-Url]: https://www.nuget.org/packages/Json2Sharp