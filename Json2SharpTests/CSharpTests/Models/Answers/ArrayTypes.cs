namespace Json2SharpTests.CSharpTests.Models.Answers;

internal static class ArrayTypes
{
    public const string Input = """
        {
            "empty_array": [],
            "int_array": [ 1, 2, 3 ],
            "nullable_int_array" : [ 1, 2, null ],
            "float_array": [ 1.0, 2.0, 3.0 ],
            "nullable_float_array" : [ 1.0, 2.0, null ],
            "string_array": [ "a", "b", "c" ],
            "nullable_string_array": [ "a", "b", null ],
            "mixed_array": [ 1, "a", 2.1 ],
            "nullable_mixed_array": [ 1, "a", 2.1, null ],
            "thing_array": [ { "text": "hello" } ],
            "nullable_thing_array": [ { "text": "hello" }, null ]
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        public sealed record ArrayTypes(
            [JsonProperty("empty_array")] object[] EmptyArray,
            [JsonProperty("int_array")] int[] IntArray,
            [JsonProperty("nullable_int_array")] int?[] NullableIntArray,
            [JsonProperty("float_array")] float[] FloatArray,
            [JsonProperty("nullable_float_array")] float?[] NullableFloatArray,
            [JsonProperty("string_array")] string[] StringArray,
            [JsonProperty("nullable_string_array")] string?[] NullableStringArray,
            [JsonProperty("mixed_array")] object[] MixedArray,
            [JsonProperty("nullable_mixed_array")] object?[] NullableMixedArray,
            [JsonProperty("thing_array")] ThingArray[] ThingArray,
            [JsonProperty("nullable_thing_array")] NullableThingArray?[] NullableThingArray
        );

        public sealed record ThingArray(
            [JsonProperty("text")] string Text
        );

        public sealed record NullableThingArray(
            [JsonProperty("text")] string Text
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record ArrayTypes(
            object[] EmptyArray,
            int[] IntArray,
            int?[] NullableIntArray,
            float[] FloatArray,
            float?[] NullableFloatArray,
            string[] StringArray,
            string?[] NullableStringArray,
            object[] MixedArray,
            object?[] NullableMixedArray,
            ThingArray[] ThingArray,
            NullableThingArray?[] NullableThingArray
        );

        public sealed record ThingArray(
            string Text
        );

        public sealed record NullableThingArray(
            string Text
        );
        """;

    public const string RecordOutput = """
        public sealed record ArrayTypes
        {
            [JsonPropertyName("empty_array")]
            public object[] EmptyArray { get; init; }
        
            [JsonPropertyName("int_array")]
            public int[] IntArray { get; init; }
        
            [JsonPropertyName("nullable_int_array")]
            public int?[] NullableIntArray { get; init; }
        
            [JsonPropertyName("float_array")]
            public float[] FloatArray { get; init; }
        
            [JsonPropertyName("nullable_float_array")]
            public float?[] NullableFloatArray { get; init; }
        
            [JsonPropertyName("string_array")]
            public string[] StringArray { get; init; }
        
            [JsonPropertyName("nullable_string_array")]
            public string?[] NullableStringArray { get; init; }
        
            [JsonPropertyName("mixed_array")]
            public object[] MixedArray { get; init; }
        
            [JsonPropertyName("nullable_mixed_array")]
            public object?[] NullableMixedArray { get; init; }
        
            [JsonPropertyName("thing_array")]
            public ThingArray[] ThingArray { get; init; }
        
            [JsonPropertyName("nullable_thing_array")]
            public NullableThingArray?[] NullableThingArray { get; init; }
        }

        public sealed record ThingArray
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        }

        public sealed record NullableThingArray
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        }
        """;

    public const string ClassOutput = """
        public sealed class ArrayTypes
        {
            [JsonPropertyName("empty_array")]
            public object[] EmptyArray { get; init; }
        
            [JsonPropertyName("int_array")]
            public int[] IntArray { get; init; }
        
            [JsonPropertyName("nullable_int_array")]
            public int?[] NullableIntArray { get; init; }
        
            [JsonPropertyName("float_array")]
            public float[] FloatArray { get; init; }
        
            [JsonPropertyName("nullable_float_array")]
            public float?[] NullableFloatArray { get; init; }
        
            [JsonPropertyName("string_array")]
            public string[] StringArray { get; init; }
        
            [JsonPropertyName("nullable_string_array")]
            public string?[] NullableStringArray { get; init; }
        
            [JsonPropertyName("mixed_array")]
            public object[] MixedArray { get; init; }
        
            [JsonPropertyName("nullable_mixed_array")]
            public object?[] NullableMixedArray { get; init; }
        
            [JsonPropertyName("thing_array")]
            public ThingArray[] ThingArray { get; init; }
        
            [JsonPropertyName("nullable_thing_array")]
            public NullableThingArray?[] NullableThingArray { get; init; }
        }

        public sealed class ThingArray
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        }

        public sealed class NullableThingArray
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class ArrayTypes
        {
            public object[] EmptyArray { get; init; }
        
            public int[] IntArray { get; init; }
        
            public int?[] NullableIntArray { get; init; }
        
            public float[] FloatArray { get; init; }
        
            public float?[] NullableFloatArray { get; init; }
        
            public string[] StringArray { get; init; }
        
            public string?[] NullableStringArray { get; init; }
        
            public object[] MixedArray { get; init; }
        
            public object?[] NullableMixedArray { get; init; }
        
            public ThingArray[] ThingArray { get; init; }
        
            public NullableThingArray?[] NullableThingArray { get; init; }
        }

        public sealed class ThingArray
        {
            public string Text { get; init; }
        }

        public sealed class NullableThingArray
        {
            public string Text { get; init; }
        }
        """;

    public const string StructOutput = """
        public struct ArrayTypes
        {
            [JsonPropertyName("empty_array")]
            public object[] EmptyArray { get; init; }
        
            [JsonPropertyName("int_array")]
            public int[] IntArray { get; init; }
        
            [JsonPropertyName("nullable_int_array")]
            public int?[] NullableIntArray { get; init; }
        
            [JsonPropertyName("float_array")]
            public float[] FloatArray { get; init; }
        
            [JsonPropertyName("nullable_float_array")]
            public float?[] NullableFloatArray { get; init; }
        
            [JsonPropertyName("string_array")]
            public string[] StringArray { get; init; }
        
            [JsonPropertyName("nullable_string_array")]
            public string?[] NullableStringArray { get; init; }
        
            [JsonPropertyName("mixed_array")]
            public object[] MixedArray { get; init; }
        
            [JsonPropertyName("nullable_mixed_array")]
            public object?[] NullableMixedArray { get; init; }
        
            [JsonPropertyName("thing_array")]
            public ThingArray[] ThingArray { get; init; }
        
            [JsonPropertyName("nullable_thing_array")]
            public NullableThingArray?[] NullableThingArray { get; init; }
        }

        public struct ThingArray
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        }

        public struct NullableThingArray
        {
            [JsonPropertyName("text")]
            public string Text { get; init; }
        }
        """;
}