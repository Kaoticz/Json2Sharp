namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class ObjectTypes
{
    public const string Input = """
        {
            "null_thing": null,
            "thing": {
                "text": "hello world",
                "number": 1,
                "int_array": [ 1, 2, 3 ]
            }
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        public sealed record ObjectTypes(
            [JsonProperty("null_thing")] object? NullThing,
            [JsonProperty("thing")] Thing Thing
        );

        public sealed record Thing(
            [JsonProperty("text")] string Text,
            [JsonProperty("number")] int Number,
            [JsonProperty("int_array")] int[] IntArray
        );
        """;

    public const string RecordOutput = """
        public sealed record ObjectTypes
        {
            [JsonPropertyName("null_thing")]
            public object? NullThing { get; init; }
        
            [JsonPropertyName("thing")]
            public Thing Thing { get; init; }
        }

        public sealed record Thing
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("number")]
            public int Number { get; init; }
        
            [JsonPropertyName("int_array")]
            public int[] IntArray { get; init; }
        }
        """;

    public const string ClassOutput = """
        public sealed class ObjectTypes
        {
            [JsonPropertyName("null_thing")]
            public object? NullThing { get; init; }
        
            [JsonPropertyName("thing")]
            public Thing Thing { get; init; }
        }

        public sealed class Thing
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("number")]
            public int Number { get; init; }
        
            [JsonPropertyName("int_array")]
            public int[] IntArray { get; init; }
        }
        """;

    public const string StructOutput = """
        public struct ObjectTypes
        {
            [JsonPropertyName("null_thing")]
            public object? NullThing { get; init; }
        
            [JsonPropertyName("thing")]
            public Thing Thing { get; init; }
        }

        public struct Thing
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("number")]
            public int Number { get; init; }
        
            [JsonPropertyName("int_array")]
            public int[] IntArray { get; init; }
        }
        """;
}