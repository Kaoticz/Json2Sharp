namespace Json2SharpTests.KotlinTests.Models.Answers;

internal static class WeirdNameTypes
{
    public const string Input = """
        {
            "snake_case": 1,
            "camelCase": 2,
            "PascalCase": 3,
            "SCREAMINGCASE": 4,
            "SCREAMING_SNAKE": 5,
            "kebab-case": 6,
            "Pascal_Snake": 7,
            "snake_case:colon": 8,
            "camelCase:colon": 9,
            "PascalCase:Colon": 10,
            "SCREAMINGCASE:COLON": 11,
            "SCREAMING_SNAKE:COLON": 12,
            "kebab-case:colon": 13,
            "Pascal_Snake:Colon": 14,
            "colon:object": {
                "normal_prop": 15,
                "nested:colon": 16
            },
            "snake.dot": 17,
            "snake@at": 18,
            "snake#hash": 19,
            "snake$dollar": 20,
            "snake%percentage": 21,
            "snake&ampersand": 22,
            "snake*asterisk": 23
        }
        """;

    public const string NoAnnotationOutput = """
        data class Root(
            val snakeCase: Int,
            val camelCase: Int,
            val pascalCase: Int,
            val screamingcase: Int,
            val screamingSnake: Int,
            val kebabCase: Int,
            val pascalSnake: Int,
            val snakeCaseColon: Int,
            val camelCaseColon: Int,
            val pascalCaseColon: Int,
            val screamingcaseColon: Int,
            val screamingSnakeColon: Int,
            val kebabCaseColon: Int,
            val pascalSnakeColon: Int,
            val colonObject: ColonObject,
            val snakeDot: Int,
            val snakeAt: Int,
            val snakeHash: Int,
            val snakeDollar: Int,
            val snakePercentage: Int,
            val snakeAmpersand: Int,
            val snakeAsterisk: Int
        )

        data class ColonObject(
            val normalProp: Int,
            val nestedColon: Int
        )
        """;

    public const string KotlinxOutput = """
        import kotlinx.serialization.Serializable
        import kotlinx.serialization.SerialName

        @Serializable
        data class Root(
            @SerialName("snake_case") val snakeCase: Int,
            @SerialName("camelCase") val camelCase: Int,
            @SerialName("PascalCase") val pascalCase: Int,
            @SerialName("SCREAMINGCASE") val screamingcase: Int,
            @SerialName("SCREAMING_SNAKE") val screamingSnake: Int,
            @SerialName("kebab-case") val kebabCase: Int,
            @SerialName("Pascal_Snake") val pascalSnake: Int,
            @SerialName("snake_case:colon") val snakeCaseColon: Int,
            @SerialName("camelCase:colon") val camelCaseColon: Int,
            @SerialName("PascalCase:Colon") val pascalCaseColon: Int,
            @SerialName("SCREAMINGCASE:COLON") val screamingcaseColon: Int,
            @SerialName("SCREAMING_SNAKE:COLON") val screamingSnakeColon: Int,
            @SerialName("kebab-case:colon") val kebabCaseColon: Int,
            @SerialName("Pascal_Snake:Colon") val pascalSnakeColon: Int,
            @SerialName("colon:object") val colonObject: ColonObject,
            @SerialName("snake.dot") val snakeDot: Int,
            @SerialName("snake@at") val snakeAt: Int,
            @SerialName("snake#hash") val snakeHash: Int,
            @SerialName("snake$dollar") val snakeDollar: Int,
            @SerialName("snake%percentage") val snakePercentage: Int,
            @SerialName("snake&ampersand") val snakeAmpersand: Int,
            @SerialName("snake*asterisk") val snakeAsterisk: Int
        )

        @Serializable
        data class ColonObject(
            @SerialName("normal_prop") val normalProp: Int,
            @SerialName("nested:colon") val nestedColon: Int
        )
        """;

    public const string JacksonOutput = """
        import com.fasterxml.jackson.annotation.JsonProperty

        data class Root(
            @JsonProperty("snake_case") val snakeCase: Int,
            @JsonProperty("camelCase") val camelCase: Int,
            @JsonProperty("PascalCase") val pascalCase: Int,
            @JsonProperty("SCREAMINGCASE") val screamingcase: Int,
            @JsonProperty("SCREAMING_SNAKE") val screamingSnake: Int,
            @JsonProperty("kebab-case") val kebabCase: Int,
            @JsonProperty("Pascal_Snake") val pascalSnake: Int,
            @JsonProperty("snake_case:colon") val snakeCaseColon: Int,
            @JsonProperty("camelCase:colon") val camelCaseColon: Int,
            @JsonProperty("PascalCase:Colon") val pascalCaseColon: Int,
            @JsonProperty("SCREAMINGCASE:COLON") val screamingcaseColon: Int,
            @JsonProperty("SCREAMING_SNAKE:COLON") val screamingSnakeColon: Int,
            @JsonProperty("kebab-case:colon") val kebabCaseColon: Int,
            @JsonProperty("Pascal_Snake:Colon") val pascalSnakeColon: Int,
            @JsonProperty("colon:object") val colonObject: ColonObject,
            @JsonProperty("snake.dot") val snakeDot: Int,
            @JsonProperty("snake@at") val snakeAt: Int,
            @JsonProperty("snake#hash") val snakeHash: Int,
            @JsonProperty("snake$dollar") val snakeDollar: Int,
            @JsonProperty("snake%percentage") val snakePercentage: Int,
            @JsonProperty("snake&ampersand") val snakeAmpersand: Int,
            @JsonProperty("snake*asterisk") val snakeAsterisk: Int
        )

        data class ColonObject(
            @JsonProperty("normal_prop") val normalProp: Int,
            @JsonProperty("nested:colon") val nestedColon: Int
        )
        """;

    public const string GsonOutput = """
        import com.google.gson.annotations.SerializedName

        data class Root(
            @SerializedName("snake_case") val snakeCase: Int,
            @SerializedName("camelCase") val camelCase: Int,
            @SerializedName("PascalCase") val pascalCase: Int,
            @SerializedName("SCREAMINGCASE") val screamingcase: Int,
            @SerializedName("SCREAMING_SNAKE") val screamingSnake: Int,
            @SerializedName("kebab-case") val kebabCase: Int,
            @SerializedName("Pascal_Snake") val pascalSnake: Int,
            @SerializedName("snake_case:colon") val snakeCaseColon: Int,
            @SerializedName("camelCase:colon") val camelCaseColon: Int,
            @SerializedName("PascalCase:Colon") val pascalCaseColon: Int,
            @SerializedName("SCREAMINGCASE:COLON") val screamingcaseColon: Int,
            @SerializedName("SCREAMING_SNAKE:COLON") val screamingSnakeColon: Int,
            @SerializedName("kebab-case:colon") val kebabCaseColon: Int,
            @SerializedName("Pascal_Snake:Colon") val pascalSnakeColon: Int,
            @SerializedName("colon:object") val colonObject: ColonObject,
            @SerializedName("snake.dot") val snakeDot: Int,
            @SerializedName("snake@at") val snakeAt: Int,
            @SerializedName("snake#hash") val snakeHash: Int,
            @SerializedName("snake$dollar") val snakeDollar: Int,
            @SerializedName("snake%percentage") val snakePercentage: Int,
            @SerializedName("snake&ampersand") val snakeAmpersand: Int,
            @SerializedName("snake*asterisk") val snakeAsterisk: Int
        )

        data class ColonObject(
            @SerializedName("normal_prop") val normalProp: Int,
            @SerializedName("nested:colon") val nestedColon: Int
        )
        """;

    public const string MoshiOutput = """
        import com.squareup.moshi.Json
        import com.squareup.moshi.JsonClass

        @JsonClass(generateAdapter = true)
        data class Root(
            @Json(name = "snake_case") val snakeCase: Int,
            @Json(name = "camelCase") val camelCase: Int,
            @Json(name = "PascalCase") val pascalCase: Int,
            @Json(name = "SCREAMINGCASE") val screamingcase: Int,
            @Json(name = "SCREAMING_SNAKE") val screamingSnake: Int,
            @Json(name = "kebab-case") val kebabCase: Int,
            @Json(name = "Pascal_Snake") val pascalSnake: Int,
            @Json(name = "snake_case:colon") val snakeCaseColon: Int,
            @Json(name = "camelCase:colon") val camelCaseColon: Int,
            @Json(name = "PascalCase:Colon") val pascalCaseColon: Int,
            @Json(name = "SCREAMINGCASE:COLON") val screamingcaseColon: Int,
            @Json(name = "SCREAMING_SNAKE:COLON") val screamingSnakeColon: Int,
            @Json(name = "kebab-case:colon") val kebabCaseColon: Int,
            @Json(name = "Pascal_Snake:Colon") val pascalSnakeColon: Int,
            @Json(name = "colon:object") val colonObject: ColonObject,
            @Json(name = "snake.dot") val snakeDot: Int,
            @Json(name = "snake@at") val snakeAt: Int,
            @Json(name = "snake#hash") val snakeHash: Int,
            @Json(name = "snake$dollar") val snakeDollar: Int,
            @Json(name = "snake%percentage") val snakePercentage: Int,
            @Json(name = "snake&ampersand") val snakeAmpersand: Int,
            @Json(name = "snake*asterisk") val snakeAsterisk: Int
        )

        @JsonClass(generateAdapter = true)
        data class ColonObject(
            @Json(name = "normal_prop") val normalProp: Int,
            @Json(name = "nested:colon") val nestedColon: Int
        )
        """;
}
