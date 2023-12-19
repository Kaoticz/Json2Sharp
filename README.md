[![.NET Unit Tests][.NET-Badge]][.NET-Url]
[![CodeQL][CodeQL-Badge]][CodeQL-Url]
[![CodeFactor][CodeFactor-Badge]][CodeFactor-Url]

# Json2Sharp

> *Because life is too short to map data by hand.*

Json2Sharp is a CLI application that converts JSON data into a programming language type declaration (i.e. a class).

At this time only C# is supported, but support for other languages will eventually be implemented. If you don't want to wait for your favorite language to be supported, you're welcome to write it yourself and initiate a pull request.

## Quick start

Pipe JSON data directly into Json2Sharp.

```bash
$ curl -s https://api.isevenapi.xyz/api/iseven/6 | json2sharp
public sealed record MyType
{
    [JsonPropertyName("ad")]
    public string Ad { get; init; }

    [JsonPropertyName("iseven")]
    public bool Iseven { get; init; }
}
```

Or tell it to use a file as input.

```bash
$ json2sharp -i IsEven.json
public sealed record IsEven
{
    [JsonPropertyName("ad")]
    public string Ad { get; init; }

    [JsonPropertyName("iseven")]
    public bool Iseven { get; init; }
}
```

You can also save the result to a file.

```bash
$ curl -s https://api.isevenapi.xyz/api/iseven/6 | json2sharp -o IsEven.cs
$ cat IsEven.cs
public sealed record IsEven
{
    [JsonPropertyName("ad")]
    public string Ad { get; init; }

    [JsonPropertyName("iseven")]
    public bool Iseven { get; init; }
}
```

For additional options, please visit the [wiki][GithubWiki].

## NuGet

Json2Sharp is also available as a library on NuGet. To add it to your .NET project, simply run the following command.

```
dotnet add package Json2Sharp
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