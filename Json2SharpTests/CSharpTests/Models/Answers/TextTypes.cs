namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class TextTypes
{
    public const string Input = """
        {
            "text": "hello world",
            "empty_text": "",
            "date_time_offset": "2024-05-19T01:23:10.000Z",
            "id": "6c33ac26-953b-46bf-8a5d-a34e1b99e5df"
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        using Newtonsoft.Json;

        public sealed record TextTypes(
            [JsonProperty("text")] string Text,
            [JsonProperty("empty_text")] string EmptyText,
            [JsonProperty("date_time_offset")] DateTimeOffset DateTimeOffset,
            [JsonProperty("id")] Guid Id
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record TextTypes(
            string Text,
            string EmptyText,
            DateTimeOffset DateTimeOffset,
            Guid Id
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record TextTypes(
            [property: JsonPropertyName("text")] string Text,
            [property: JsonPropertyName("empty_text")] string EmptyText,
            [property: JsonPropertyName("date_time_offset")] DateTimeOffset DateTimeOffset,
            [property: JsonPropertyName("id")] Guid Id
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class TextTypes
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("empty_text")]
            public string EmptyText { get; init; }

            [JsonPropertyName("date_time_offset")]
            public DateTimeOffset DateTimeOffset { get; init; }

            [JsonPropertyName("id")]
            public Guid Id { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class TextTypes
        {
            public string Text { get; init; }
        
            public string EmptyText { get; init; }

            public DateTimeOffset DateTimeOffset { get; init; }

            public Guid Id { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct TextTypes
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("empty_text")]
            public string EmptyText { get; init; }

            [JsonPropertyName("date_time_offset")]
            public DateTimeOffset DateTimeOffset { get; init; }

            [JsonPropertyName("id")]
            public Guid Id { get; init; }
        }
        """;
}