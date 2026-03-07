namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class CustomHandleTypes
{
    public const string Input = """
        {
            "id": "550e8400-e29b-41d4-a716-446655440000",
            "date": "2021-01-01T00:00:00Z",
            "duration": "00:00:01",
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

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record custom_handle_types(
            Guid id,
            DateTimeOffset date,
            TimeSpan duration,
            object? null_thing,
            object empty_thing,
            thing[] thing
        );
        
        public sealed record thing(
            string text,
            int number,
            int[] int_array,
            int prop_base_colon,
            prop_custom_colon prop_custom_colon
        );
        
        public sealed record prop_custom_colon(
            string blep
        );
        """;

    public const string RecordPrimaryCtorOutput = """
        using Newtonsoft.Json;
        
        public sealed record custom_handle_types(
            [JsonProperty("id")] Guid id,
            [JsonProperty("date")] DateTimeOffset date,
            [JsonProperty("duration")] TimeSpan duration,
            [JsonProperty("null_thing")] object? null_thing,
            [JsonProperty("empty_thing")] object empty_thing,
            [JsonProperty("thing")] thing[] thing
        );
        
        public sealed record thing(
            [JsonProperty("text")] string text,
            [JsonProperty("number")] int number,
            [JsonProperty("int_array")] int[] int_array,
            [JsonProperty("prop_base:colon")] int prop_base_colon,
            [JsonProperty("prop_custom:colon")] prop_custom_colon prop_custom_colon
        );
        
        public sealed record prop_custom_colon(
            [JsonProperty("blep")] string blep
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record custom_handle_types(
            [property: JsonPropertyName("id")] Guid id,
            [property: JsonPropertyName("date")] DateTimeOffset date,
            [property: JsonPropertyName("duration")] TimeSpan duration,
            [property: JsonPropertyName("null_thing")] object? null_thing,
            [property: JsonPropertyName("empty_thing")] object empty_thing,
            [property: JsonPropertyName("thing")] thing[] thing
        );
        
        public sealed record thing(
            [property: JsonPropertyName("text")] string text,
            [property: JsonPropertyName("number")] int number,
            [property: JsonPropertyName("int_array")] int[] int_array,
            [property: JsonPropertyName("prop_base:colon")] int prop_base_colon,
            [property: JsonPropertyName("prop_custom:colon")] prop_custom_colon prop_custom_colon
        );
        
        public sealed record prop_custom_colon(
            [property: JsonPropertyName("blep")] string blep
        );
        """;

    public const string ClassOutputNoAtt = """
        public sealed class custom_handle_types
        {
            public required Guid id { get; init; }
        
            public required DateTimeOffset date { get; init; }
        
            public required TimeSpan duration { get; init; }
        
            public required object? null_thing { get; init; }
        
            public required object empty_thing { get; init; }
        
            public required thing[] thing { get; init; }
        }
        
        public sealed class thing
        {
            public required string text { get; init; }
        
            public required int number { get; init; }
        
            public required int[] int_array { get; init; }
        
            public required int prop_base_colon { get; init; }
        
            public required prop_custom_colon prop_custom_colon { get; init; }
        }
        
        public sealed class prop_custom_colon
        {
            public required string blep { get; init; }
        }
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class custom_handle_types
        {
            [JsonPropertyName("id")]
            public required Guid id { get; init; }
        
            [JsonPropertyName("date")]
            public required DateTimeOffset date { get; init; }
        
            [JsonPropertyName("duration")]
            public required TimeSpan duration { get; init; }
        
            [JsonPropertyName("null_thing")]
            public required object? null_thing { get; init; }
        
            [JsonPropertyName("empty_thing")]
            public required object empty_thing { get; init; }
        
            [JsonPropertyName("thing")]
            public required thing[] thing { get; init; }
        }
        
        public sealed class thing
        {
            [JsonPropertyName("text")]
            public required string text { get; init; }
        
            [JsonPropertyName("number")]
            public required int number { get; init; }
        
            [JsonPropertyName("int_array")]
            public required int[] int_array { get; init; }
        
            [JsonPropertyName("prop_base:colon")]
            public required int prop_base_colon { get; init; }
        
            [JsonPropertyName("prop_custom:colon")]
            public required prop_custom_colon prop_custom_colon { get; init; }
        }
        
        public sealed class prop_custom_colon
        {
            [JsonPropertyName("blep")]
            public required string blep { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct custom_handle_types
        {
            [JsonPropertyName("id")]
            public required Guid id { get; init; }
        
            [JsonPropertyName("date")]
            public required DateTimeOffset date { get; init; }
        
            [JsonPropertyName("duration")]
            public required TimeSpan duration { get; init; }
        
            [JsonPropertyName("null_thing")]
            public required object? null_thing { get; init; }
        
            [JsonPropertyName("empty_thing")]
            public required object empty_thing { get; init; }
        
            [JsonPropertyName("thing")]
            public required thing[] thing { get; init; }
        }
        
        public readonly struct thing
        {
            [JsonPropertyName("text")]
            public required string text { get; init; }
        
            [JsonPropertyName("number")]
            public required int number { get; init; }
        
            [JsonPropertyName("int_array")]
            public required int[] int_array { get; init; }
        
            [JsonPropertyName("prop_base:colon")]
            public required int prop_base_colon { get; init; }
        
            [JsonPropertyName("prop_custom:colon")]
            public required prop_custom_colon prop_custom_colon { get; init; }
        }
        
        public readonly struct prop_custom_colon
        {
            [JsonPropertyName("blep")]
            public required string blep { get; init; }
        }
        """;

}
