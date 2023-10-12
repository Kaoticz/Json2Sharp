using Json2SharpLib.Common;

namespace Json2SharpApp;

internal sealed class Program
{
    private const string _rawJson =
        """
        {
            "integer_number": 1,
            "float_number": 1.5,
            "numbers": [ 1, 2, 3 ],
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
                {
                    "hello": "world",
                    "blep": "sucks",
                    "random_array": [ 1, 2, 3 ]
                }
            ],
            "other_things": [
                {
                    "hello": "world",
                    "json": "sucks",
                    "random_array": [ 1, 2, 3 ]
                },
                1,
                "a",
                1.4
            ]
        }
        """;

    private static void Main(string[] args)
    {
        Console.Write(Json2Sharp.Parse("Test", _rawJson, new Json2SharpLib.Models.Json2SharpOptions() { CSharp = new()
        {
            TargetType = Json2SharpLib.Enums.CSharpObjectType.Class,
            SetterType = Json2SharpLib.Enums.CSharpSetterType.Set
        }}));
    }
}
