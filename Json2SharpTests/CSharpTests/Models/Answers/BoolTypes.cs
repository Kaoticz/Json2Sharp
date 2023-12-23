namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class BoolTypes
{
    public const string Input = """
        {
            "true_bool": true,
            "false_bool": false
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        public sealed record BoolTypes(
            [JsonProperty("true_bool")] bool TrueBool,
            [JsonProperty("false_bool")] bool FalseBool
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record BoolTypes(
            bool TrueBool,
            bool FalseBool
        );
        """;

    public const string RecordOutput = """
        public sealed record BoolTypes
        {
            [JsonPropertyName("true_bool")]
            public bool TrueBool { get; init; }
        
            [JsonPropertyName("false_bool")]
            public bool FalseBool { get; init; }
        }
        """;

    public const string ClassOutput = """
        public sealed class BoolTypes
        {
            [JsonPropertyName("true_bool")]
            public bool TrueBool { get; init; }
        
            [JsonPropertyName("false_bool")]
            public bool FalseBool { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class BoolTypes
        {
            public bool TrueBool { get; init; }
        
            public bool FalseBool { get; init; }
        }
        """;

    public const string StructOutput = """
        public struct BoolTypes
        {
            [JsonPropertyName("true_bool")]
            public bool TrueBool { get; init; }
        
            [JsonPropertyName("false_bool")]
            public bool FalseBool { get; init; }
        }
        """;
}