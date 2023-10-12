using System.Text.Json;

namespace Json2SharpLib.Tests;

public class UnitTest1
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
                "json": "sucks",
                "random_array": [ 1, 2, 3 ]
            }
        }
        """;

    [Fact]
    internal void Test1()
    {

    }
}