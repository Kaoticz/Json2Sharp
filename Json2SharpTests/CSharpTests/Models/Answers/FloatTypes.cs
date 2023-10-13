namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class FloatTypes
{
    public const string Input = """
        {
            "float_number": 3.4028235E+38,
            "double_number": 1.7976931348623157E+308,
            "decimal_number": 7.9228162514264337593543950335
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        public sealed record FloatTypes(
            [JsonProperty("float_number")] float FloatNumber
            [JsonProperty("double_number")] double DoubleNumber
            [JsonProperty("decimal_number")] decimal DecimalNumber
        );
        """;

    public const string RecordOutput = """
        public sealed record FloatTypes
        {
            [JsonPropertyName("float_number")]
            public float FloatNumber { get; init; }
        
            [JsonPropertyName("double_number")]
            public double DoubleNumber { get; init; }
        
            [JsonPropertyName("decimal_number")]
            public decimal DecimalNumber { get; init; }
        }
        """;

    public const string ClassOutput = """
        public sealed class FloatTypes
        {
            [JsonPropertyName("float_number")]
            public float FloatNumber { get; init; }
        
            [JsonPropertyName("double_number")]
            public double DoubleNumber { get; init; }
        
            [JsonPropertyName("decimal_number")]
            public decimal DecimalNumber { get; init; }
        }
        """;

    public const string StructOutput = """
        public struct FloatTypes
        {
            [JsonPropertyName("float_number")]
            public float FloatNumber { get; init; }
        
            [JsonPropertyName("double_number")]
            public double DoubleNumber { get; init; }
        
            [JsonPropertyName("decimal_number")]
            public decimal DecimalNumber { get; init; }
        }
        """;
}