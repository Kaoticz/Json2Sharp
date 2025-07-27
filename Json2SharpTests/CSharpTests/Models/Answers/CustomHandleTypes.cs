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

        public sealed record CustomHandleTypes(
            [JsonProperty("null_thing")] object? NullThing,
            [JsonProperty("empty_thing")] object EmptyThing,
            [JsonProperty("thing")] ThingAyy[] Thing
        );

        public sealed record ThingAyy(
            [JsonProperty("text")] string Text,
            [JsonProperty("number")] int Number,
            [JsonProperty("int_array")] int[] IntArray,
            [JsonProperty("prop_base:colon")] int PropBaseColon,
            [JsonProperty("prop_custom:colon")] PropCustomColonAyy PropCustomColon
        );

        public sealed record PropCustomColonAyy(
            [JsonProperty("blep")] string Blep
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record CustomHandleTypes(
            object? NullThing,
            object EmptyThing,
            ThingAyy[] Thing
        );

        public sealed record ThingAyy(
            string Text,
            int Number,
            int[] IntArray,
            int PropBaseColon,
            PropCustomColonAyy PropCustomColon
        );

        public sealed record PropCustomColonAyy(
            string Blep
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record CustomHandleTypes(
            [property: JsonPropertyName("null_thing")] object? NullThing,
            [property: JsonPropertyName("empty_thing")] object EmptyThing,
            [property: JsonPropertyName("thing")] ThingAyy[] Thing
        );

        public sealed record ThingAyy(
            [property: JsonPropertyName("text")] string Text,
            [property: JsonPropertyName("number")] int Number,
            [property: JsonPropertyName("int_array")] int[] IntArray,
            [property: JsonPropertyName("prop_base:colon")] int PropBaseColon,
            [property: JsonPropertyName("prop_custom:colon")] PropCustomColonAyy PropCustomColon
        );

        public sealed record PropCustomColonAyy(
            [property: JsonPropertyName("blep")] string Blep
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class CustomHandleTypes
        {
            [JsonPropertyName("null_thing")]
            public required object? NullThing { get; init; }

            [JsonPropertyName("empty_thing")]
            public required object EmptyThing { get; init; }
        
            [JsonPropertyName("thing")]
            public required ThingAyy[] Thing { get; init; }
        }

        public sealed class ThingAyy
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
            public required PropCustomColonAyy PropCustomColon { get; init; }
        }

        public sealed class PropCustomColonAyy
        {
            [JsonPropertyName("blep")]
            public required string Blep { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class CustomHandleTypes
        {
            public required object? NullThing { get; init; }

            public required object EmptyThing { get; init; }
        
            public required ThingAyy[] Thing { get; init; }
        }

        public sealed class ThingAyy
        {
            public required string Text { get; init; }
        
            public required int Number { get; init; }
        
            public required int[] IntArray { get; init; }

            public required int PropBaseColon { get; init; }

            public required PropCustomColonAyy PropCustomColon { get; init; }
        }

        public sealed class PropCustomColonAyy
        {
            public required string Blep { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct CustomHandleTypes
        {
            [JsonPropertyName("null_thing")]
            public required object? NullThing { get; init; }

            [JsonPropertyName("empty_thing")]
            public required object EmptyThing { get; init; }
        
            [JsonPropertyName("thing")]
            public required ThingAyy[] Thing { get; init; }
        }

        public readonly struct ThingAyy
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
            public required PropCustomColonAyy PropCustomColon { get; init; }
        }

        public readonly struct PropCustomColonAyy
        {
            [JsonPropertyName("blep")]
            public required string Blep { get; init; }
        }
        """;
}