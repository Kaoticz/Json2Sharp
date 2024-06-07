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
        using Newtonsoft.Json;

        public sealed record FloatTypes(
            [JsonProperty("float_number")] float FloatNumber,
            [JsonProperty("double_number")] double DoubleNumber,
            [JsonProperty("decimal_number")] decimal DecimalNumber
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record FloatTypes(
            float FloatNumber,
            double DoubleNumber,
            decimal DecimalNumber
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record FloatTypes(
            [property: JsonPropertyName("float_number")] float FloatNumber,
            [property: JsonPropertyName("double_number")] double DoubleNumber,
            [property: JsonPropertyName("decimal_number")] decimal DecimalNumber
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class FloatTypes
        {
            [JsonPropertyName("float_number")]
            public required float FloatNumber { get; init; }
        
            [JsonPropertyName("double_number")]
            public required double DoubleNumber { get; init; }
        
            [JsonPropertyName("decimal_number")]
            public required decimal DecimalNumber { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class FloatTypes
        {
            public required float FloatNumber { get; init; }
        
            public required double DoubleNumber { get; init; }
        
            public required decimal DecimalNumber { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct FloatTypes
        {
            [JsonPropertyName("float_number")]
            public required float FloatNumber { get; init; }
        
            [JsonPropertyName("double_number")]
            public required double DoubleNumber { get; init; }
        
            [JsonPropertyName("decimal_number")]
            public required decimal DecimalNumber { get; init; }
        }
        """;
}