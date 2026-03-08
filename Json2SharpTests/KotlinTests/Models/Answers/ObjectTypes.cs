namespace Json2SharpTests.KotlinTests.Models.Answers;

internal static class ObjectTypes
{
    public const string Input = """
        {
            "null_thing": null,
            "empty_thing": {},
            "thing": {
                "text": "hello world",
                "number": 1,
                "int_array": [ 1, 2, 3 ],
                "prop_base:colon": 2,
                "prop_custom:colon": { "blep": "nested" }
            }
        }
        """;

    public const string NoAnnotationOutput = """
        data class Root(
            val nullThing: Any?,
            val emptyThing: Any,
            val thing: Thing
        )

        data class Thing(
            val text: String,
            val number: Int,
            val intArray: List<Int>,
            val propBaseColon: Int,
            val propCustomColon: PropCustomColon
        )

        data class PropCustomColon(
            val blep: String
        )
        """;

    public const string KotlinxOutput = """
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class Root(
            @SerialName("null_thing") val nullThing: Any?,
            @SerialName("empty_thing") val emptyThing: Any,
            @SerialName("thing") val thing: Thing
        )

        @Serializable
        data class Thing(
            @SerialName("text") val text: String,
            @SerialName("number") val number: Int,
            @SerialName("int_array") val intArray: List<Int>,
            @SerialName("prop_base:colon") val propBaseColon: Int,
            @SerialName("prop_custom:colon") val propCustomColon: PropCustomColon
        )

        @Serializable
        data class PropCustomColon(
            @SerialName("blep") val blep: String
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty

        data class Root(
            @JsonProperty("null_thing") val nullThing: Any?,
            @JsonProperty("empty_thing") val emptyThing: Any,
            @JsonProperty("thing") val thing: Thing
        )

        data class Thing(
            @JsonProperty("text") val text: String,
            @JsonProperty("number") val number: Int,
            @JsonProperty("int_array") val intArray: List<Int>,
            @JsonProperty("prop_base:colon") val propBaseColon: Int,
            @JsonProperty("prop_custom:colon") val propCustomColon: PropCustomColon
        )

        data class PropCustomColon(
            @JsonProperty("blep") val blep: String
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName

        data class Root(
            @SerializedName("null_thing") val nullThing: Any?,
            @SerializedName("empty_thing") val emptyThing: Any,
            @SerializedName("thing") val thing: Thing
        )

        data class Thing(
            @SerializedName("text") val text: String,
            @SerializedName("number") val number: Int,
            @SerializedName("int_array") val intArray: List<Int>,
            @SerializedName("prop_base:colon") val propBaseColon: Int,
            @SerializedName("prop_custom:colon") val propCustomColon: PropCustomColon
        )

        data class PropCustomColon(
            @SerializedName("blep") val blep: String
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass

        @JsonClass(generateAdapter = true)
        data class Root(
            @Json(name = "null_thing") val nullThing: Any?,
            @Json(name = "empty_thing") val emptyThing: Any,
            @Json(name = "thing") val thing: Thing
        )

        @JsonClass(generateAdapter = true)
        data class Thing(
            @Json(name = "text") val text: String,
            @Json(name = "number") val number: Int,
            @Json(name = "int_array") val intArray: List<Int>,
            @Json(name = "prop_base:colon") val propBaseColon: Int,
            @Json(name = "prop_custom:colon") val propCustomColon: PropCustomColon
        )

        @JsonClass(generateAdapter = true)
        data class PropCustomColon(
            @Json(name = "blep") val blep: String
        )
        """;
}
