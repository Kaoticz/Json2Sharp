namespace Json2SharpTests.KotlinTests.Models.Answers;

internal static class FloatTypes
{
    public const string Input = """
        {
            "float_number": 3.4028235E+38,
            "double_number": 1.7976931348623157E+308,
            "decimal_number": 7.9228162514264337593543950335
        }
        """;

    public const string NoAnnotationOutput = """
        data class Root(
            val floatNumber: Float,
            val doubleNumber: Double,
            val decimalNumber: Double
        )
        """;

    public const string KotlinxOutput = """
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class Root(
            @SerialName("float_number") val floatNumber: Float,
            @SerialName("double_number") val doubleNumber: Double,
            @SerialName("decimal_number") val decimalNumber: Double
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty

        data class Root(
            @JsonProperty("float_number") val floatNumber: Float,
            @JsonProperty("double_number") val doubleNumber: Double,
            @JsonProperty("decimal_number") val decimalNumber: Double
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName

        data class Root(
            @SerializedName("float_number") val floatNumber: Float,
            @SerializedName("double_number") val doubleNumber: Double,
            @SerializedName("decimal_number") val decimalNumber: Double
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass

        @JsonClass(generateAdapter = true)
        data class Root(
            @Json(name = "float_number") val floatNumber: Float,
            @Json(name = "double_number") val doubleNumber: Double,
            @Json(name = "decimal_number") val decimalNumber: Double
        )
        """;
}
