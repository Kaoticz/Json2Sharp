namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class IntegerTypes
{
    public const string Input = """
        {
            "int_number": 2147483647,
            "uint_number": 2147483648,
            "long_number": 4294967296,
            "ulong_number": 9223372036854775808
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        public sealed record IntegerTypes(
            [JsonProperty("int_number")] int IntNumber
            [JsonProperty("uint_number")] uint UintNumber
            [JsonProperty("long_number")] long LongNumber
            [JsonProperty("ulong_number")] ulong UlongNumber
        );
        """;

    public const string RecordOutput = """
        public sealed record IntegerTypes
        {
            [JsonPropertyName("int_number")]
            public int IntNumber { get; init; }
        
            [JsonPropertyName("uint_number")]
            public uint UintNumber { get; init; }
        
            [JsonPropertyName("long_number")]
            public long LongNumber { get; init; }
        
            [JsonPropertyName("ulong_number")]
            public ulong UlongNumber { get; init; }
        }
        """;

    public const string ClassOutput = """
        public sealed class IntegerTypes
        {
            [JsonPropertyName("int_number")]
            public int IntNumber { get; init; }
        
            [JsonPropertyName("uint_number")]
            public uint UintNumber { get; init; }
        
            [JsonPropertyName("long_number")]
            public long LongNumber { get; init; }
        
            [JsonPropertyName("ulong_number")]
            public ulong UlongNumber { get; init; }
        }
        """;

    public const string StructOutput = """
        public struct IntegerTypes
        {
            [JsonPropertyName("int_number")]
            public int IntNumber { get; init; }
        
            [JsonPropertyName("uint_number")]
            public uint UintNumber { get; init; }
        
            [JsonPropertyName("long_number")]
            public long LongNumber { get; init; }
        
            [JsonPropertyName("ulong_number")]
            public ulong UlongNumber { get; init; }
        }
        """;
}