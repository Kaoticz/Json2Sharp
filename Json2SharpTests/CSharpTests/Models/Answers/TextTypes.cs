namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class TextTypes
{
    public const string Input = """
        {
            "text": "hello world",
            "empty_text": ""
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        public sealed record TextTypes(
            [JsonProperty("text")] string Text,
            [JsonProperty("empty_text")] string EmptyText
        );
        """;

    public const string RecordOutput = """
        public sealed record TextTypes
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("empty_text")]
            public string EmptyText { get; init; }
        }
        """;

    public const string ClassOutput = """
        public sealed class TextTypes
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("empty_text")]
            public string EmptyText { get; init; }
        }
        """;

    public const string StructOutput = """
        public struct TextTypes
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("empty_text")]
            public string EmptyText { get; init; }
        }
        """;
}