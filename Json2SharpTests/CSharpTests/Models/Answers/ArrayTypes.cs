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
            "nullable_thing_array": [ { "text": "hello" }, null ],
            "null_array": [ null ],
            "objects_array": [
                { "text": "hello" },
                { "id": 1 }
            ],
            "nullable_objects_array": [
                { "text": "hello" },
                { "id": 1 },
                null
            ]
        }
        """;

    public const string RecordPrimaryCtorOutput = """
        using Newtonsoft.Json;

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
            [JsonProperty("nullable_thing_array")] NullableThingArray?[] NullableThingArray,
            [JsonProperty("null_array")] object?[] NullArray,
            [JsonProperty("objects_array")] object[] ObjectsArray,
            [JsonProperty("nullable_objects_array")] object?[] NullableObjectsArray
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
            NullableThingArray?[] NullableThingArray,
            object?[] NullArray,
            object[] ObjectsArray,
            object?[] NullableObjectsArray
        );

        public sealed record ThingArray(
            string Text
        );

        public sealed record NullableThingArray(
            string Text
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;

        public sealed record ArrayTypes(
            [property: JsonPropertyName("empty_array")] object[] EmptyArray,
            [property: JsonPropertyName("int_array")] int[] IntArray,
            [property: JsonPropertyName("nullable_int_array")] int?[] NullableIntArray,
            [property: JsonPropertyName("float_array")] float[] FloatArray,
            [property: JsonPropertyName("nullable_float_array")] float?[] NullableFloatArray,
            [property: JsonPropertyName("string_array")] string[] StringArray,
            [property: JsonPropertyName("nullable_string_array")] string?[] NullableStringArray,
            [property: JsonPropertyName("mixed_array")] object[] MixedArray,
            [property: JsonPropertyName("nullable_mixed_array")] object?[] NullableMixedArray,
            [property: JsonPropertyName("thing_array")] ThingArray[] ThingArray,
            [property: JsonPropertyName("nullable_thing_array")] NullableThingArray?[] NullableThingArray,
            [property: JsonPropertyName("null_array")] object?[] NullArray,
            [property: JsonPropertyName("objects_array")] object[] ObjectsArray,
            [property: JsonPropertyName("nullable_objects_array")] object?[] NullableObjectsArray
        );

        public sealed record ThingArray(
            [property: JsonPropertyName("text")] string Text
        );

        public sealed record NullableThingArray(
            [property: JsonPropertyName("text")] string Text
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class ArrayTypes
        {
            [JsonPropertyName("empty_array")]
            public required object[] EmptyArray { get; init; }
        
            [JsonPropertyName("int_array")]
            public required int[] IntArray { get; init; }
        
            [JsonPropertyName("nullable_int_array")]
            public required int?[] NullableIntArray { get; init; }
        
            [JsonPropertyName("float_array")]
            public required float[] FloatArray { get; init; }
        
            [JsonPropertyName("nullable_float_array")]
            public required float?[] NullableFloatArray { get; init; }
        
            [JsonPropertyName("string_array")]
            public required string[] StringArray { get; init; }
        
            [JsonPropertyName("nullable_string_array")]
            public required string?[] NullableStringArray { get; init; }
        
            [JsonPropertyName("mixed_array")]
            public required object[] MixedArray { get; init; }
        
            [JsonPropertyName("nullable_mixed_array")]
            public required object?[] NullableMixedArray { get; init; }
        
            [JsonPropertyName("thing_array")]
            public required ThingArray[] ThingArray { get; init; }
        
            [JsonPropertyName("nullable_thing_array")]
            public required NullableThingArray?[] NullableThingArray { get; init; }

            [JsonPropertyName("null_array")]
            public required object?[] NullArray { get; init; }

            [JsonPropertyName("objects_array")]
            public required object[] ObjectsArray { get; init; }

            [JsonPropertyName("nullable_objects_array")]
            public required object?[] NullableObjectsArray { get; init; }
        }

        public sealed class ThingArray
        {
            [JsonPropertyName("text")]
            public required string Text { get; init; }
        }

        public sealed class NullableThingArray
        {
            [JsonPropertyName("text")]
            public required string Text { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class ArrayTypes
        {
            public required object[] EmptyArray { get; init; }
        
            public required int[] IntArray { get; init; }
        
            public required int?[] NullableIntArray { get; init; }
        
            public required float[] FloatArray { get; init; }
        
            public required float?[] NullableFloatArray { get; init; }
        
            public required string[] StringArray { get; init; }
        
            public required string?[] NullableStringArray { get; init; }
        
            public required object[] MixedArray { get; init; }
        
            public required object?[] NullableMixedArray { get; init; }
        
            public required ThingArray[] ThingArray { get; init; }
        
            public required NullableThingArray?[] NullableThingArray { get; init; }

            public required object?[] NullArray { get; init; }

            public required object[] ObjectsArray { get; init; }

            public required object?[] NullableObjectsArray { get; init; }
        }

        public sealed class ThingArray
        {
            public required string Text { get; init; }
        }

        public sealed class NullableThingArray
        {
            public required string Text { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct ArrayTypes
        {
            [JsonPropertyName("empty_array")]
            public required object[] EmptyArray { get; init; }
        
            [JsonPropertyName("int_array")]
            public required int[] IntArray { get; init; }
        
            [JsonPropertyName("nullable_int_array")]
            public required int?[] NullableIntArray { get; init; }
        
            [JsonPropertyName("float_array")]
            public required float[] FloatArray { get; init; }
        
            [JsonPropertyName("nullable_float_array")]
            public required float?[] NullableFloatArray { get; init; }
        
            [JsonPropertyName("string_array")]
            public required string[] StringArray { get; init; }
        
            [JsonPropertyName("nullable_string_array")]
            public required string?[] NullableStringArray { get; init; }
        
            [JsonPropertyName("mixed_array")]
            public required object[] MixedArray { get; init; }
        
            [JsonPropertyName("nullable_mixed_array")]
            public required object?[] NullableMixedArray { get; init; }
        
            [JsonPropertyName("thing_array")]
            public required ThingArray[] ThingArray { get; init; }
        
            [JsonPropertyName("nullable_thing_array")]
            public required NullableThingArray?[] NullableThingArray { get; init; }

            [JsonPropertyName("null_array")]
            public required object?[] NullArray { get; init; }

            [JsonPropertyName("objects_array")]
            public required object[] ObjectsArray { get; init; }

            [JsonPropertyName("nullable_objects_array")]
            public required object?[] NullableObjectsArray { get; init; }
        }

        public readonly struct ThingArray
        {
            [JsonPropertyName("text")]
            public required string Text { get; init; }
        }

        public readonly struct NullableThingArray
        {
            [JsonPropertyName("text")]
            public required string Text { get; init; }
        }
        """;
}