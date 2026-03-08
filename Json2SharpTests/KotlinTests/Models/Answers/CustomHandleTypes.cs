namespace Json2SharpTests.KotlinTests.Models.Answers;

internal static class CustomHandleTypes
{
    public const string Input = """
        {
            "id": "550e8400-e29b-41d4-a716-446655440000",
            "date": "2021-01-01T00:00:00Z",
            "duration": "00:00:01",
            "null_thing": null,
            "empty_thing": {},
            "thing": [
                {
                    "text": "hello world",
                    "number": 1,
                    "int_array": [ 1, 2, 3 ],
                    "prop_base:colon": 2,
                    "prop_custom:colon": { "blep": "nested" }
                }
            ]
        }
        """;

    public const string NoAnnotationOutput = """
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID

        data class custom_handle_types(
            val id: UUID,
            val date: OffsetDateTime,
            val duration: Duration,
            val nullThing: Any?,
            val emptyThing: Any,
            val thing: List<thing>
        )

        data class thing(
            val text: String,
            val number: Int,
            val intArray: List<Int>,
            val propBaseColon: Int,
            val propCustomColon: prop_custom_colon
        )

        data class prop_custom_colon(
            val blep: String
        )
        """;

    public const string KotlinxOutput = """
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class custom_handle_types(
            @SerialName("id") val id: UUID,
            @SerialName("date") val date: OffsetDateTime,
            @SerialName("duration") val duration: Duration,
            @SerialName("null_thing") val nullThing: Any?,
            @SerialName("empty_thing") val emptyThing: Any,
            @SerialName("thing") val thing: List<thing>
        )

        @Serializable
        data class thing(
            @SerialName("text") val text: String,
            @SerialName("number") val number: Int,
            @SerialName("int_array") val intArray: List<Int>,
            @SerialName("prop_base:colon") val propBaseColon: Int,
            @SerialName("prop_custom:colon") val propCustomColon: prop_custom_colon
        )

        @Serializable
        data class prop_custom_colon(
            @SerialName("blep") val blep: String
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID

        data class custom_handle_types(
            @JsonProperty("id") val id: UUID,
            @JsonProperty("date") val date: OffsetDateTime,
            @JsonProperty("duration") val duration: Duration,
            @JsonProperty("null_thing") val nullThing: Any?,
            @JsonProperty("empty_thing") val emptyThing: Any,
            @JsonProperty("thing") val thing: List<thing>
        )

        data class thing(
            @JsonProperty("text") val text: String,
            @JsonProperty("number") val number: Int,
            @JsonProperty("int_array") val intArray: List<Int>,
            @JsonProperty("prop_base:colon") val propBaseColon: Int,
            @JsonProperty("prop_custom:colon") val propCustomColon: prop_custom_colon
        )

        data class prop_custom_colon(
            @JsonProperty("blep") val blep: String
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID

        data class custom_handle_types(
            @SerializedName("id") val id: UUID,
            @SerializedName("date") val date: OffsetDateTime,
            @SerializedName("duration") val duration: Duration,
            @SerializedName("null_thing") val nullThing: Any?,
            @SerializedName("empty_thing") val emptyThing: Any,
            @SerializedName("thing") val thing: List<thing>
        )

        data class thing(
            @SerializedName("text") val text: String,
            @SerializedName("number") val number: Int,
            @SerializedName("int_array") val intArray: List<Int>,
            @SerializedName("prop_base:colon") val propBaseColon: Int,
            @SerializedName("prop_custom:colon") val propCustomColon: prop_custom_colon
        )

        data class prop_custom_colon(
            @SerializedName("blep") val blep: String
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass
        import java.time.Duration
        import java.time.OffsetDateTime
        import java.util.UUID

        @JsonClass(generateAdapter = true)
        data class custom_handle_types(
            @Json(name = "id") val id: UUID,
            @Json(name = "date") val date: OffsetDateTime,
            @Json(name = "duration") val duration: Duration,
            @Json(name = "null_thing") val nullThing: Any?,
            @Json(name = "empty_thing") val emptyThing: Any,
            @Json(name = "thing") val thing: List<thing>
        )

        @JsonClass(generateAdapter = true)
        data class thing(
            @Json(name = "text") val text: String,
            @Json(name = "number") val number: Int,
            @Json(name = "int_array") val intArray: List<Int>,
            @Json(name = "prop_base:colon") val propBaseColon: Int,
            @Json(name = "prop_custom:colon") val propCustomColon: prop_custom_colon
        )

        @JsonClass(generateAdapter = true)
        data class prop_custom_colon(
            @Json(name = "blep") val blep: String
        )
        """;
}
