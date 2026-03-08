namespace Json2SharpTests.KotlinTests.Models.Answers;

internal static class IntegerTypes
{
    public const string Input = """
        {
            "int_number": 2147483647,
            "uint_number": 2147483648,
            "long_number": 4294967296,
            "ulong_number": 9223372036854775808,
            "big_int": 18446744073709551616
        }
        """;

    public const string NoAnnotationOutput = """
        import java.math.BigInteger

        data class Root(
            val intNumber: Int,
            val uintNumber: Long,
            val longNumber: Long,
            val ulongNumber: Long,
            val bigInt: BigInteger
        )
        """;

    public const string KotlinxOutput = """
        import java.math.BigInteger
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class Root(
            @SerialName("int_number") val intNumber: Int,
            @SerialName("uint_number") val uintNumber: Long,
            @SerialName("long_number") val longNumber: Long,
            @SerialName("ulong_number") val ulongNumber: Long,
            @SerialName("big_int") val bigInt: BigInteger
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty
        import java.math.BigInteger

        data class Root(
            @JsonProperty("int_number") val intNumber: Int,
            @JsonProperty("uint_number") val uintNumber: Long,
            @JsonProperty("long_number") val longNumber: Long,
            @JsonProperty("ulong_number") val ulongNumber: Long,
            @JsonProperty("big_int") val bigInt: BigInteger
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName
        import java.math.BigInteger

        data class Root(
            @SerializedName("int_number") val intNumber: Int,
            @SerializedName("uint_number") val uintNumber: Long,
            @SerializedName("long_number") val longNumber: Long,
            @SerializedName("ulong_number") val ulongNumber: Long,
            @SerializedName("big_int") val bigInt: BigInteger
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass
        import java.math.BigInteger

        @JsonClass(generateAdapter = true)
        data class Root(
            @Json(name = "int_number") val intNumber: Int,
            @Json(name = "uint_number") val uintNumber: Long,
            @Json(name = "long_number") val longNumber: Long,
            @Json(name = "ulong_number") val ulongNumber: Long,
            @Json(name = "big_int") val bigInt: BigInteger
        )
        """;
}
