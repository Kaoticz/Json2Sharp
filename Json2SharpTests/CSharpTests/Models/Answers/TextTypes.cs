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
        using Newtonsoft.Json;

        public sealed record TextTypes(
            [JsonProperty("text")] string Text,
            [JsonProperty("empty_text")] string EmptyText
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record TextTypes(
            string Text,
            string EmptyText
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record TextTypes
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("empty_text")]
            public string EmptyText { get; init; }
        }
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class TextTypes
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("empty_text")]
            public string EmptyText { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class TextTypes
        {
            public string Text { get; init; }
        
            public string EmptyText { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public struct TextTypes
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        
            [JsonPropertyName("empty_text")]
            public string EmptyText { get; init; }
        }
        """;
}