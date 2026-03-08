namespace Json2SharpTests.KotlinTests.Models.Answers;

internal static class BoolTypes
{
    public const string Input = """
        {
            "true_bool": true,
            "false_bool": false
        }
        """;

    public const string NoAnnotationOutput = """
        data class Root(
            val trueBool: Boolean,
            val falseBool: Boolean
        )
        """;

    public const string KotlinxOutput = """
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class Root(
            @SerialName("true_bool") val trueBool: Boolean,
            @SerialName("false_bool") val falseBool: Boolean
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty

        data class Root(
            @JsonProperty("true_bool") val trueBool: Boolean,
            @JsonProperty("false_bool") val falseBool: Boolean
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName

        data class Root(
            @SerializedName("true_bool") val trueBool: Boolean,
            @SerializedName("false_bool") val falseBool: Boolean
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass

        @JsonClass(generateAdapter = true)
        data class Root(
            @Json(name = "true_bool") val trueBool: Boolean,
            @Json(name = "false_bool") val falseBool: Boolean
        )
        """;
}
