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
        using Newtonsoft.Json;

        public sealed record IntegerTypes(
            [JsonProperty("int_number")] int IntNumber,
            [JsonProperty("uint_number")] uint UintNumber,
            [JsonProperty("long_number")] long LongNumber,
            [JsonProperty("ulong_number")] ulong UlongNumber
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record IntegerTypes(
            int IntNumber,
            uint UintNumber,
            long LongNumber,
            ulong UlongNumber
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record IntegerTypes(
            [property: JsonPropertyName("int_number")] int IntNumber,
            [property: JsonPropertyName("uint_number")] uint UintNumber,
            [property: JsonPropertyName("long_number")] long LongNumber,
            [property: JsonPropertyName("ulong_number")] ulong UlongNumber
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class IntegerTypes
        {
            [JsonPropertyName("int_number")]
            public required int IntNumber { get; init; }
        
            [JsonPropertyName("uint_number")]
            public required uint UintNumber { get; init; }
        
            [JsonPropertyName("long_number")]
            public required long LongNumber { get; init; }
        
            [JsonPropertyName("ulong_number")]
            public required ulong UlongNumber { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class IntegerTypes
        {
            public required int IntNumber { get; init; }
        
            public required uint UintNumber { get; init; }
        
            public required long LongNumber { get; init; }
        
            public required ulong UlongNumber { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct IntegerTypes
        {
            [JsonPropertyName("int_number")]
            public required int IntNumber { get; init; }
        
            [JsonPropertyName("uint_number")]
            public required uint UintNumber { get; init; }
        
            [JsonPropertyName("long_number")]
            public required long LongNumber { get; init; }
        
            [JsonPropertyName("ulong_number")]
            public required ulong UlongNumber { get; init; }
        }
        """;
}