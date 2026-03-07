namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class KeywordTypes
{
    public const string Input = """
        {
            "class": "value",
            "for": "value",
            "1_number": "value"
        }
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;

        public sealed class KeywordTypes
        {
            [JsonPropertyName("class")]
            public required string Class { get; init; }

            [JsonPropertyName("for")]
            public required string For { get; init; }

            [JsonPropertyName("1_number")]
            public required string _1Number { get; init; }
        }
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;

        public sealed record KeywordTypes(
            [property: JsonPropertyName("class")] string Class,
            [property: JsonPropertyName("for")] string For,
            [property: JsonPropertyName("1_number")] string _1Number
        );
        """;
}