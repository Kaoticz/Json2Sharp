namespace Json2SharpTests.KotlinTests.Models.Answers;

internal static class ArrayRoot
{
    public const string Input = """
        [
            { "id": 1 },
            { "id": 2 },
            { "id": 3 },
            { "id": 4 },
            { "id": 5 }
        ]
        """;

    public const string NoAnnotationOutput = """
        data class Root(
            val id: Int
        )
        """;

    public const string KotlinxOutput = """
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class Root(
            @SerialName("id") val id: Int
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty

        data class Root(
            @JsonProperty("id") val id: Int
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName

        data class Root(
            @SerializedName("id") val id: Int
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass

        @JsonClass(generateAdapter = true)
        data class Root(
            @Json(name = "id") val id: Int
        )
        """;
}
