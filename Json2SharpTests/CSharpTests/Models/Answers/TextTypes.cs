namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class TextTypes
{
    public const string Input = """
        {
            "text": "hello world",
            "empty_text": "",
            "timespan": "00:00:01",
            "timespans": ["00:00:01"],
            "nullable_timespans": ["00:00:01", null],
            "date_time_offset": "2024-05-19T01:23:10.000Z",
            "date_time_offset_array": ["2024-05-19T01:23:10.000Z"],
            "date_time_offset_nullable_array": ["2024-05-19T01:23:10.000Z", null],
            "id": "6c33ac26-953b-46bf-8a5d-a34e1b99e5df",
            "ids": ["6c33ac26-953b-46bf-8a5d-a34e1b99e5df"],
            "nullable_ids": ["6c33ac26-953b-46bf-8a5d-a34e1b99e5df", null]
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        using Newtonsoft.Json;

        public sealed record TextTypes(
            [JsonProperty("text")] string Text,
            [JsonProperty("empty_text")] string EmptyText,
            [JsonProperty("timespan")] TimeSpan Timespan,
            [JsonProperty("timespans")] TimeSpan[] Timespans,
            [JsonProperty("nullable_timespans")] TimeSpan?[] NullableTimespans,
            [JsonProperty("date_time_offset")] DateTimeOffset DateTimeOffset,
            [JsonProperty("date_time_offset_array")] DateTimeOffset[] DateTimeOffsetArray,
            [JsonProperty("date_time_offset_nullable_array")] DateTimeOffset?[] DateTimeOffsetNullableArray,
            [JsonProperty("id")] Guid Id,
            [JsonProperty("ids")] Guid[] Ids,
            [JsonProperty("nullable_ids")] Guid?[] NullableIds
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record TextTypes(
            string Text,
            string EmptyText,
            TimeSpan Timespan,
            TimeSpan[] Timespans,
            TimeSpan?[] NullableTimespans,
            DateTimeOffset DateTimeOffset,
            DateTimeOffset[] DateTimeOffsetArray,
            DateTimeOffset?[] DateTimeOffsetNullableArray,
            Guid Id,
            Guid[] Ids,
            Guid?[] NullableIds
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record TextTypes(
            [property: JsonPropertyName("text")] string Text,
            [property: JsonPropertyName("empty_text")] string EmptyText,
            [property: JsonPropertyName("timespan")] TimeSpan Timespan,
            [property: JsonPropertyName("timespans")] TimeSpan[] Timespans,
            [property: JsonPropertyName("nullable_timespans")] TimeSpan?[] NullableTimespans,
            [property: JsonPropertyName("date_time_offset")] DateTimeOffset DateTimeOffset,
            [property: JsonPropertyName("date_time_offset_array")] DateTimeOffset[] DateTimeOffsetArray,
            [property: JsonPropertyName("date_time_offset_nullable_array")] DateTimeOffset?[] DateTimeOffsetNullableArray,
            [property: JsonPropertyName("id")] Guid Id,
            [property: JsonPropertyName("ids")] Guid[] Ids,
            [property: JsonPropertyName("nullable_ids")] Guid?[] NullableIds
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class TextTypes
        {
            [JsonPropertyName("text")]
            public required string Text { get; init; }

            [JsonPropertyName("empty_text")]
            public required string EmptyText { get; init; }

            [JsonPropertyName("timespan")]
            public required TimeSpan Timespan { get; init; }

            [JsonPropertyName("timespans")]
            public required TimeSpan[] Timespans { get; init; }

            [JsonPropertyName("nullable_timespans")]
            public required TimeSpan?[] NullableTimespans { get; init; }

            [JsonPropertyName("date_time_offset")]
            public required DateTimeOffset DateTimeOffset { get; init; }

            [JsonPropertyName("date_time_offset_array")]
            public required DateTimeOffset[] DateTimeOffsetArray { get; init; }

            [JsonPropertyName("date_time_offset_nullable_array")]
            public required DateTimeOffset?[] DateTimeOffsetNullableArray { get; init; }

            [JsonPropertyName("id")]
            public required Guid Id { get; init; }

            [JsonPropertyName("ids")]
            public required Guid[] Ids { get; init; }

            [JsonPropertyName("nullable_ids")]
            public required Guid?[] NullableIds { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class TextTypes
        {
            public required string Text { get; init; }

            public required string EmptyText { get; init; }

            public required TimeSpan Timespan { get; init; }

            public required TimeSpan[] Timespans { get; init; }

            public required TimeSpan?[] NullableTimespans { get; init; }

            public required DateTimeOffset DateTimeOffset { get; init; }

            public required DateTimeOffset[] DateTimeOffsetArray { get; init; }

            public required DateTimeOffset?[] DateTimeOffsetNullableArray { get; init; }

            public required Guid Id { get; init; }

            public required Guid[] Ids { get; init; }

            public required Guid?[] NullableIds { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct TextTypes
        {
            [JsonPropertyName("text")]
            public required string Text { get; init; }

            [JsonPropertyName("empty_text")]
            public required string EmptyText { get; init; }

            [JsonPropertyName("timespan")]
            public required TimeSpan Timespan { get; init; }

            [JsonPropertyName("timespans")]
            public required TimeSpan[] Timespans { get; init; }

            [JsonPropertyName("nullable_timespans")]
            public required TimeSpan?[] NullableTimespans { get; init; }

            [JsonPropertyName("date_time_offset")]
            public required DateTimeOffset DateTimeOffset { get; init; }

            [JsonPropertyName("date_time_offset_array")]
            public required DateTimeOffset[] DateTimeOffsetArray { get; init; }

            [JsonPropertyName("date_time_offset_nullable_array")]
            public required DateTimeOffset?[] DateTimeOffsetNullableArray { get; init; }

            [JsonPropertyName("id")]
            public required Guid Id { get; init; }

            [JsonPropertyName("ids")]
            public required Guid[] Ids { get; init; }

            [JsonPropertyName("nullable_ids")]
            public required Guid?[] NullableIds { get; init; }
        }
        """;
}