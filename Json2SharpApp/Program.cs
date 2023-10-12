using Json2SharpLib.Common;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;

namespace Json2SharpApp;

internal sealed class Program
{
    private const string _rawJson =
        """
        {
            "integer_number": 1,
            "float_number": 1.5,
            "numbers": [ 1, 2, 3, null ],
            "text": "Blep",
            "empty_text": "",
            "null_text": null,
            "true_bool": true,
            "false_bool": false,
            "thing": {
                "hello": "world",
                "blep": "sucks",
                "random_array": [ 1, 2, 3 ]
            },
            "things": [
                {
                    "hello": "world",
                    "blep": "sucks",
                    "random_array": [ 1, 2, 3 ]
                },
                {
                    "hello": "world",
                    "blep": "sucks",
                    "random_array": [ 1, 2, 3 ]
                },
                null
            ],
            "other_things": [
                {
                    "hello": "world",
                    "json": "sucks",
                    "random_array": [ 1, 2, 3 ]
                },
                1,
                "a",
                1.4,
                null
            ]
        }
        """;

    private static void Main(string[] args)
    {
        Console.Write(Json2Sharp.Parse("Test", _rawJson, new Json2SharpOptions() { CSharp = new()
        {
            TargetType = CSharpObjectType.Record,
            SetterType = CSharpSetterType.Set,
            SerializationAttribute = CSharpSerializationAttribute.SystemTextJson
        }}));
    }
}
