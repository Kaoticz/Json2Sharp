namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class CustomHandleTypes
{
    public const string Input = """
        {
            "null_thing": null,
            "empty_thing": {},
            "thing": [
                {
                    "text": "hello world",
                    "number": 1,
                    "int_array": [ 1, 2, 3 ],
                    "prop_base:colon": 2,
                    "prop_custom:colon": { "blep": "nested" }
                }
            ]
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        using Newtonsoft.Json;

        public sealed record custom_handle_types(
            [JsonProperty("null_thing")] object? NullThing,
            [JsonProperty("empty_thing")] object EmptyThing,
            [JsonProperty("thing")] thing[] Thing
        );

        public sealed record thing(
            [JsonProperty("text")] string Text,
            [JsonProperty("number")] int Number,
            [JsonProperty("int_array")] int[] IntArray,
            [JsonProperty("prop_base:colon")] int PropBaseColon,
            [JsonProperty("prop_custom:colon")] prop_custom_colon PropCustomColon
        );

        public sealed record prop_custom_colon(
            [JsonProperty("blep")] string Blep
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record custom_handle_types(
            object? NullThing,
            object EmptyThing,
            thing[] Thing
        );

        public sealed record thing(
            string Text,
            int Number,
            int[] IntArray,
            int PropBaseColon,
            prop_custom_colon PropCustomColon
        );

        public sealed record prop_custom_colon(
            string Blep
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record custom_handle_types(
            [property: JsonPropertyName("null_thing")] object? NullThing,
            [property: JsonPropertyName("empty_thing")] object EmptyThing,
            [property: JsonPropertyName("thing")] thing[] Thing
        );

        public sealed record thing(
            [property: JsonPropertyName("text")] string Text,
            [property: JsonPropertyName("number")] int Number,
            [property: JsonPropertyName("int_array")] int[] IntArray,
            [property: JsonPropertyName("prop_base:colon")] int PropBaseColon,
            [property: JsonPropertyName("prop_custom:colon")] prop_custom_colon PropCustomColon
        );

        public sealed record prop_custom_colon(
            [property: JsonPropertyName("blep")] string Blep
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class custom_handle_types
        {
            [JsonPropertyName("null_thing")]
            public required object? NullThing { get; init; }

            [JsonPropertyName("empty_thing")]
            public required object EmptyThing { get; init; }
        
            [JsonPropertyName("thing")]
            public required thing[] Thing { get; init; }
        }

        public sealed class thing
        {
            [JsonPropertyName("text")]
            public required string Text { get; init; }
        
            [JsonPropertyName("number")]
            public required int Number { get; init; }
        
            [JsonPropertyName("int_array")]
            public required int[] IntArray { get; init; }

            [JsonPropertyName("prop_base:colon")]
            public required int PropBaseColon { get; init; }

            [JsonPropertyName("prop_custom:colon")]
            public required prop_custom_colon PropCustomColon { get; init; }
        }

        public sealed class prop_custom_colon
        {
            [JsonPropertyName("blep")]
            public required string Blep { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class custom_handle_types
        {
            public required object? NullThing { get; init; }

            public required object EmptyThing { get; init; }
        
            public required thing[] Thing { get; init; }
        }

        public sealed class thing
        {
            public required string Text { get; init; }
        
            public required int Number { get; init; }
        
            public required int[] IntArray { get; init; }

            public required int PropBaseColon { get; init; }

            public required prop_custom_colon PropCustomColon { get; init; }
        }

        public sealed class prop_custom_colon
        {
            public required string Blep { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct custom_handle_types
        {
            [JsonPropertyName("null_thing")]
            public required object? NullThing { get; init; }

            [JsonPropertyName("empty_thing")]
            public required object EmptyThing { get; init; }
        
            [JsonPropertyName("thing")]
            public required thing[] Thing { get; init; }
        }

        public readonly struct thing
        {
            [JsonPropertyName("text")]
            public required string Text { get; init; }
        
            [JsonPropertyName("number")]
            public required int Number { get; init; }
        
            [JsonPropertyName("int_array")]
            public required int[] IntArray { get; init; }

            [JsonPropertyName("prop_base:colon")]
            public required int PropBaseColon { get; init; }

            [JsonPropertyName("prop_custom:colon")]
            public required prop_custom_colon PropCustomColon { get; init; }
        }

        public readonly struct prop_custom_colon
        {
            [JsonPropertyName("blep")]
            public required string Blep { get; init; }
        }
        """;
}