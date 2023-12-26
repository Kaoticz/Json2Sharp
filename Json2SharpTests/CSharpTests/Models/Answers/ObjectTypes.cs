namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class ObjectTypes
{
    public const string Input = """
        {
            "null_thing": null,
            "empty_thing": {},
            "thing": {
                "text": "hello world",
                "number": 1,
                "int_array": [ 1, 2, 3 ]
            }
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        using Newtonsoft.Json;

        public sealed record ObjectTypes(
            [JsonProperty("null_thing")] object? NullThing,
            [JsonProperty("empty_thing")] object EmptyThing,
            [JsonProperty("thing")] Thing Thing
        );

        public sealed record Thing(
            [JsonProperty("text")] string Text,
            [JsonProperty("number")] int Number,
            [JsonProperty("int_array")] int[] IntArray
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record ObjectTypes(
            object? NullThing,
            object EmptyThing,
            Thing Thing
        );

        public sealed record Thing(
            string Text,
            int Number,
            int[] IntArray
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record ObjectTypes(
            [property: JsonPropertyName("null_thing")] object? NullThing,
            [property: JsonPropertyName("empty_thing")] object EmptyThing,
            [property: JsonPropertyName("thing")] Thing Thing
        );

        public sealed record Thing(
            [property: JsonPropertyName("text")] string Text,
            [property: JsonPropertyName("number")] int Number,
            [property: JsonPropertyName("int_array")] int[] IntArray
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class ObjectTypes
        {
            [JsonPropertyName("null_thing")]
            public object? NullThing { get; init; }

            [JsonPropertyName("empty_thing")]
            public object EmptyThing { get; init; }
        
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

    public const string ClassOutputNoAtt = """
        public sealed class ObjectTypes
        {
            public object? NullThing { get; init; }

            public object EmptyThing { get; init; }
        
            public Thing Thing { get; init; }
        }

        public sealed class Thing
        {
            public string Text { get; init; }
        
            public int Number { get; init; }
        
            public int[] IntArray { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public struct ObjectTypes
        {
            [JsonPropertyName("null_thing")]
            public object? NullThing { get; init; }

            [JsonPropertyName("empty_thing")]
            public object EmptyThing { get; init; }
        
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