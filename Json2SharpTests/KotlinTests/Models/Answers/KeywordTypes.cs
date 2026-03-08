namespace Json2SharpTests.KotlinTests.Models.Answers;

internal static class KeywordTypes
{
    public const string Input = """
        {
            "class": "value",
            "for": "value",
            "1_number": "value"
        }
        """;

    public const string NoAnnotationOutput = """
        data class Root(
            val `class`: String,
            val `for`: String,
            val _1Number: String
        )
        """;

    public const string KotlinxOutput = """
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class Root(
            @SerialName("class") val `class`: String,
            @SerialName("for") val `for`: String,
            @SerialName("1_number") val _1Number: String
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty

        data class Root(
            @JsonProperty("class") val `class`: String,
            @JsonProperty("for") val `for`: String,
            @JsonProperty("1_number") val _1Number: String
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName

        data class Root(
            @SerializedName("class") val `class`: String,
            @SerializedName("for") val `for`: String,
            @SerializedName("1_number") val _1Number: String
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass

        @JsonClass(generateAdapter = true)
        data class Root(
            @Json(name = "class") val `class`: String,
            @Json(name = "for") val `for`: String,
            @Json(name = "1_number") val _1Number: String
        )
        """;
}
