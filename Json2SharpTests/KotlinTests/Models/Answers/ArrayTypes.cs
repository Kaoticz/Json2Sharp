namespace Json2SharpTests.KotlinTests.Models.Answers;

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

    public const string NoAnnotationOutput = """
        data class Root(
            val emptyArray: List<Any>,
            val intArray: List<Int>,
            val nullableIntArray: List<Int?>,
            val floatArray: List<Float>,
            val nullableFloatArray: List<Float?>,
            val stringArray: List<String>,
            val nullableStringArray: List<String?>,
            val mixedArray: List<Any>,
            val nullableMixedArray: List<Any?>,
            val thingArray: List<ThingArray>,
            val nullableThingArray: List<NullableThingArray?>,
            val nullArray: List<Any?>,
            val objectsArray: List<Any>,
            val nullableObjectsArray: List<Any?>
        )

        data class ThingArray(
            val text: String
        )

        data class NullableThingArray(
            val text: String
        )
        """;

    public const string KotlinxOutput = """
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class Root(
            @SerialName("empty_array") val emptyArray: List<Any>,
            @SerialName("int_array") val intArray: List<Int>,
            @SerialName("nullable_int_array") val nullableIntArray: List<Int?>,
            @SerialName("float_array") val floatArray: List<Float>,
            @SerialName("nullable_float_array") val nullableFloatArray: List<Float?>,
            @SerialName("string_array") val stringArray: List<String>,
            @SerialName("nullable_string_array") val nullableStringArray: List<String?>,
            @SerialName("mixed_array") val mixedArray: List<Any>,
            @SerialName("nullable_mixed_array") val nullableMixedArray: List<Any?>,
            @SerialName("thing_array") val thingArray: List<ThingArray>,
            @SerialName("nullable_thing_array") val nullableThingArray: List<NullableThingArray?>,
            @SerialName("null_array") val nullArray: List<Any?>,
            @SerialName("objects_array") val objectsArray: List<Any>,
            @SerialName("nullable_objects_array") val nullableObjectsArray: List<Any?>
        )

        @Serializable
        data class ThingArray(
            @SerialName("text") val text: String
        )

        @Serializable
        data class NullableThingArray(
            @SerialName("text") val text: String
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty

        data class Root(
            @JsonProperty("empty_array") val emptyArray: List<Any>,
            @JsonProperty("int_array") val intArray: List<Int>,
            @JsonProperty("nullable_int_array") val nullableIntArray: List<Int?>,
            @JsonProperty("float_array") val floatArray: List<Float>,
            @JsonProperty("nullable_float_array") val nullableFloatArray: List<Float?>,
            @JsonProperty("string_array") val stringArray: List<String>,
            @JsonProperty("nullable_string_array") val nullableStringArray: List<String?>,
            @JsonProperty("mixed_array") val mixedArray: List<Any>,
            @JsonProperty("nullable_mixed_array") val nullableMixedArray: List<Any?>,
            @JsonProperty("thing_array") val thingArray: List<ThingArray>,
            @JsonProperty("nullable_thing_array") val nullableThingArray: List<NullableThingArray?>,
            @JsonProperty("null_array") val nullArray: List<Any?>,
            @JsonProperty("objects_array") val objectsArray: List<Any>,
            @JsonProperty("nullable_objects_array") val nullableObjectsArray: List<Any?>
        )

        data class ThingArray(
            @JsonProperty("text") val text: String
        )

        data class NullableThingArray(
            @JsonProperty("text") val text: String
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName

        data class Root(
            @SerializedName("empty_array") val emptyArray: List<Any>,
            @SerializedName("int_array") val intArray: List<Int>,
            @SerializedName("nullable_int_array") val nullableIntArray: List<Int?>,
            @SerializedName("float_array") val floatArray: List<Float>,
            @SerializedName("nullable_float_array") val nullableFloatArray: List<Float?>,
            @SerializedName("string_array") val stringArray: List<String>,
            @SerializedName("nullable_string_array") val nullableStringArray: List<String?>,
            @SerializedName("mixed_array") val mixedArray: List<Any>,
            @SerializedName("nullable_mixed_array") val nullableMixedArray: List<Any?>,
            @SerializedName("thing_array") val thingArray: List<ThingArray>,
            @SerializedName("nullable_thing_array") val nullableThingArray: List<NullableThingArray?>,
            @SerializedName("null_array") val nullArray: List<Any?>,
            @SerializedName("objects_array") val objectsArray: List<Any>,
            @SerializedName("nullable_objects_array") val nullableObjectsArray: List<Any?>
        )

        data class ThingArray(
            @SerializedName("text") val text: String
        )

        data class NullableThingArray(
            @SerializedName("text") val text: String
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass

        @JsonClass(generateAdapter = true)
        data class Root(
            @Json(name = "empty_array") val emptyArray: List<Any>,
            @Json(name = "int_array") val intArray: List<Int>,
            @Json(name = "nullable_int_array") val nullableIntArray: List<Int?>,
            @Json(name = "float_array") val floatArray: List<Float>,
            @Json(name = "nullable_float_array") val nullableFloatArray: List<Float?>,
            @Json(name = "string_array") val stringArray: List<String>,
            @Json(name = "nullable_string_array") val nullableStringArray: List<String?>,
            @Json(name = "mixed_array") val mixedArray: List<Any>,
            @Json(name = "nullable_mixed_array") val nullableMixedArray: List<Any?>,
            @Json(name = "thing_array") val thingArray: List<ThingArray>,
            @Json(name = "nullable_thing_array") val nullableThingArray: List<NullableThingArray?>,
            @Json(name = "null_array") val nullArray: List<Any?>,
            @Json(name = "objects_array") val objectsArray: List<Any>,
            @Json(name = "nullable_objects_array") val nullableObjectsArray: List<Any?>
        )

        @JsonClass(generateAdapter = true)
        data class ThingArray(
            @Json(name = "text") val text: String
        )

        @JsonClass(generateAdapter = true)
        data class NullableThingArray(
            @Json(name = "text") val text: String
        )
        """;
}
