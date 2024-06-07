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
                "int_array": [ 1, 2, 3 ],
                "prop_base:colon": 2,
                "prop_custom:colon": { "blep": "nested" }
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
            [JsonProperty("int_array")] int[] IntArray,
            [JsonProperty("prop_base:colon")] int PropBaseColon,
            [JsonProperty("prop_custom:colon")] PropCustomColon PropCustomColon
        );

        public sealed record PropCustomColon(
            [JsonProperty("blep")] string Blep
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
            int[] IntArray,
            int PropBaseColon,
            PropCustomColon PropCustomColon
        );

        public sealed record PropCustomColon(
            string Blep
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
            [property: JsonPropertyName("int_array")] int[] IntArray,
            [property: JsonPropertyName("prop_base:colon")] int PropBaseColon,
            [property: JsonPropertyName("prop_custom:colon")] PropCustomColon PropCustomColon
        );

        public sealed record PropCustomColon(
            [property: JsonPropertyName("blep")] string Blep
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

            [JsonPropertyName("prop_base:colon")]
            public int PropBaseColon { get; init; }

            [JsonPropertyName("prop_custom:colon")]
            public PropCustomColon PropCustomColon { get; init; }
        }

        public sealed class PropCustomColon
        {
            [JsonPropertyName("blep")]
            public string Blep { get; init; }
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

            public int PropBaseColon { get; init; }

            public PropCustomColon PropCustomColon { get; init; }
        }

        public sealed class PropCustomColon
        {
            public string Blep { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct ObjectTypes
        {
            [JsonPropertyName("null_thing")]
            public object? NullThing { get; init; }

            [JsonPropertyName("empty_thing")]
            public object EmptyThing { get; init; }
        
            [JsonPropertyName("thing")]
            public Thing Thing { get; init; }
        }

        public readonly struct Thing
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("number")]
            public int Number { get; init; }
        
            [JsonPropertyName("int_array")]
            public int[] IntArray { get; init; }

            [JsonPropertyName("prop_base:colon")]
            public int PropBaseColon { get; init; }

            [JsonPropertyName("prop_custom:colon")]
            public PropCustomColon PropCustomColon { get; init; }
        }

        public readonly struct PropCustomColon
        {
            [JsonPropertyName("blep")]
            public string Blep { get; init; }
        }
        """;
}