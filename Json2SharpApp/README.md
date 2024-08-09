# Json2SharpApp

Json2Sharp is a CLI application that converts a JSON object to a class definition (or an equivalent for the target language).

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

Or pass the JSON data to the `--json`/`-j` option.

```bash
$ json2sharp -j "{ \"ad\": \"Some ad here\", \"iseven\": false }"
using System.Text.Json.Serialization;

public sealed record Root(
    [property: JsonPropertyName("ad")] string Ad,
    [property: JsonPropertyName("iseven")] bool Iseven
);
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

For additional options, please visit the [wiki](https://github.com/Kaoticz/Json2Sharp/wiki).