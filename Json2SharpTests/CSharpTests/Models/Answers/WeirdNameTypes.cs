namespace Json2SharpTests.CSharpTests.Models.Answers;

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

    public const string RecordPrimaryCtorOutput = """
        using Newtonsoft.Json;

        public sealed record WeirdNameTypes(
            [JsonProperty("snake_case")] int SnakeCase,
            [JsonProperty("camelCase")] int CamelCase,
            [JsonProperty("PascalCase")] int PascalCase,
            [JsonProperty("SCREAMINGCASE")] int Screamingcase,
            [JsonProperty("SCREAMING_SNAKE")] int ScreamingSnake,
            [JsonProperty("kebab-case")] int KebabCase,
            [JsonProperty("Pascal_Snake")] int PascalSnake,
            [JsonProperty("snake_case:colon")] int SnakeCaseColon,
            [JsonProperty("camelCase:colon")] int CamelCaseColon,
            [JsonProperty("PascalCase:Colon")] int PascalCaseColon,
            [JsonProperty("SCREAMINGCASE:COLON")] int ScreamingcaseColon,
            [JsonProperty("SCREAMING_SNAKE:COLON")] int ScreamingSnakeColon,
            [JsonProperty("kebab-case:colon")] int KebabCaseColon,
            [JsonProperty("Pascal_Snake:Colon")] int PascalSnakeColon,
            [JsonProperty("colon:object")] ColonObject ColonObject,
            [JsonProperty("snake.dot")] int SnakeDot,
            [JsonProperty("snake@at")] int SnakeAt,
            [JsonProperty("snake#hash")] int SnakeHash,
            [JsonProperty("snake$dollar")] int SnakeDollar,
            [JsonProperty("snake%percentage")] int SnakePercentage,
            [JsonProperty("snake&ampersand")] int SnakeAmpersand,
            [JsonProperty("snake*asterisk")] int SnakeAsterisk
        );

        public sealed record ColonObject(
            [JsonProperty("normal_prop")] int NormalProp,
            [JsonProperty("nested:colon")] int NestedColon
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record WeirdNameTypes(
            int SnakeCase,
            int CamelCase,
            int PascalCase,
            int Screamingcase,
            int ScreamingSnake,
            int KebabCase,
            int PascalSnake,
            int SnakeCaseColon,
            int CamelCaseColon,
            int PascalCaseColon,
            int ScreamingcaseColon,
            int ScreamingSnakeColon,
            int KebabCaseColon,
            int PascalSnakeColon,
            ColonObject ColonObject,
            int SnakeDot,
            int SnakeAt,
            int SnakeHash,
            int SnakeDollar,
            int SnakePercentage,
            int SnakeAmpersand,
            int SnakeAsterisk
        );

        public sealed record ColonObject(
            int NormalProp,
            int NestedColon
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;
        
        public sealed record WeirdNameTypes(
            [property: JsonPropertyName("snake_case")] int SnakeCase,
            [property: JsonPropertyName("camelCase")] int CamelCase,
            [property: JsonPropertyName("PascalCase")] int PascalCase,
            [property: JsonPropertyName("SCREAMINGCASE")] int Screamingcase,
            [property: JsonPropertyName("SCREAMING_SNAKE")] int ScreamingSnake,
            [property: JsonPropertyName("kebab-case")] int KebabCase,
            [property: JsonPropertyName("Pascal_Snake")] int PascalSnake,
            [property: JsonPropertyName("snake_case:colon")] int SnakeCaseColon,
            [property: JsonPropertyName("camelCase:colon")] int CamelCaseColon,
            [property: JsonPropertyName("PascalCase:Colon")] int PascalCaseColon,
            [property: JsonPropertyName("SCREAMINGCASE:COLON")] int ScreamingcaseColon,
            [property: JsonPropertyName("SCREAMING_SNAKE:COLON")] int ScreamingSnakeColon,
            [property: JsonPropertyName("kebab-case:colon")] int KebabCaseColon,
            [property: JsonPropertyName("Pascal_Snake:Colon")] int PascalSnakeColon,
            [property: JsonPropertyName("colon:object")] ColonObject ColonObject,
            [property: JsonPropertyName("snake.dot")] int SnakeDot,
            [property: JsonPropertyName("snake@at")] int SnakeAt,
            [property: JsonPropertyName("snake#hash")] int SnakeHash,
            [property: JsonPropertyName("snake$dollar")] int SnakeDollar,
            [property: JsonPropertyName("snake%percentage")] int SnakePercentage,
            [property: JsonPropertyName("snake&ampersand")] int SnakeAmpersand,
            [property: JsonPropertyName("snake*asterisk")] int SnakeAsterisk
        );

        public sealed record ColonObject(
            [property: JsonPropertyName("normal_prop")] int NormalProp,
            [property: JsonPropertyName("nested:colon")] int NestedColon
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;
        
        public sealed class WeirdNameTypes
        {
            [JsonPropertyName("snake_case")]
            public int SnakeCase { get; init; }

            [JsonPropertyName("camelCase")]
            public int CamelCase { get; init; }

            [JsonPropertyName("PascalCase")]
            public int PascalCase { get; init; }

            [JsonPropertyName("SCREAMINGCASE")]
            public int Screamingcase { get; init; }

            [JsonPropertyName("SCREAMING_SNAKE")]
            public int ScreamingSnake { get; init; }

            [JsonPropertyName("kebab-case")]
            public int KebabCase { get; init; }

            [JsonPropertyName("Pascal_Snake")]
            public int PascalSnake { get; init; }

            [JsonPropertyName("snake_case:colon")]
            public int SnakeCaseColon { get; init; }

            [JsonPropertyName("camelCase:colon")]
            public int CamelCaseColon { get; init; }

            [JsonPropertyName("PascalCase:Colon")]
            public int PascalCaseColon { get; init; }

            [JsonPropertyName("SCREAMINGCASE:COLON")]
            public int ScreamingcaseColon { get; init; }

            [JsonPropertyName("SCREAMING_SNAKE:COLON")]
            public int ScreamingSnakeColon { get; init; }

            [JsonPropertyName("kebab-case:colon")]
            public int KebabCaseColon { get; init; }

            [JsonPropertyName("Pascal_Snake:Colon")]
            public int PascalSnakeColon { get; init; }

            [JsonPropertyName("colon:object")]
            public ColonObject ColonObject { get; init; }

            [JsonPropertyName("snake.dot")]
            public int SnakeDot { get; init; }

            [JsonPropertyName("snake@at")]
            public int SnakeAt { get; init; }

            [JsonPropertyName("snake#hash")]
            public int SnakeHash { get; init; }

            [JsonPropertyName("snake$dollar")]
            public int SnakeDollar { get; init; }

            [JsonPropertyName("snake%percentage")]
            public int SnakePercentage { get; init; }

            [JsonPropertyName("snake&ampersand")]
            public int SnakeAmpersand { get; init; }

            [JsonPropertyName("snake*asterisk")]
            public int SnakeAsterisk { get; init; }
        }

        public sealed class ColonObject
        {
            [JsonPropertyName("normal_prop")]
            public int NormalProp { get; init; }
        
            [JsonPropertyName("nested:colon")]
            public int NestedColon { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class WeirdNameTypes
        {
            public int SnakeCase { get; init; }

            public int CamelCase { get; init; }

            public int PascalCase { get; init; }

            public int Screamingcase { get; init; }

            public int ScreamingSnake { get; init; }

            public int KebabCase { get; init; }

            public int PascalSnake { get; init; }

            public int SnakeCaseColon { get; init; }

            public int CamelCaseColon { get; init; }

            public int PascalCaseColon { get; init; }

            public int ScreamingcaseColon { get; init; }

            public int ScreamingSnakeColon { get; init; }

            public int KebabCaseColon { get; init; }

            public int PascalSnakeColon { get; init; }

            public ColonObject ColonObject { get; init; }

            public int SnakeDot { get; init; }

            public int SnakeAt { get; init; }

            public int SnakeHash { get; init; }

            public int SnakeDollar { get; init; }

            public int SnakePercentage { get; init; }

            public int SnakeAmpersand { get; init; }

            public int SnakeAsterisk { get; init; }
        }

        public sealed class ColonObject
        {
            public int NormalProp { get; init; }
        
            public int NestedColon { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;
        
        public readonly struct WeirdNameTypes
        {
            [JsonPropertyName("snake_case")]
            public int SnakeCase { get; init; }

            [JsonPropertyName("camelCase")]
            public int CamelCase { get; init; }

            [JsonPropertyName("PascalCase")]
            public int PascalCase { get; init; }

            [JsonPropertyName("SCREAMINGCASE")]
            public int Screamingcase { get; init; }

            [JsonPropertyName("SCREAMING_SNAKE")]
            public int ScreamingSnake { get; init; }

            [JsonPropertyName("kebab-case")]
            public int KebabCase { get; init; }

            [JsonPropertyName("Pascal_Snake")]
            public int PascalSnake { get; init; }

            [JsonPropertyName("snake_case:colon")]
            public int SnakeCaseColon { get; init; }

            [JsonPropertyName("camelCase:colon")]
            public int CamelCaseColon { get; init; }

            [JsonPropertyName("PascalCase:Colon")]
            public int PascalCaseColon { get; init; }

            [JsonPropertyName("SCREAMINGCASE:COLON")]
            public int ScreamingcaseColon { get; init; }

            [JsonPropertyName("SCREAMING_SNAKE:COLON")]
            public int ScreamingSnakeColon { get; init; }

            [JsonPropertyName("kebab-case:colon")]
            public int KebabCaseColon { get; init; }

            [JsonPropertyName("Pascal_Snake:Colon")]
            public int PascalSnakeColon { get; init; }

            [JsonPropertyName("colon:object")]
            public ColonObject ColonObject { get; init; }

            [JsonPropertyName("snake.dot")]
            public int SnakeDot { get; init; }

            [JsonPropertyName("snake@at")]
            public int SnakeAt { get; init; }

            [JsonPropertyName("snake#hash")]
            public int SnakeHash { get; init; }

            [JsonPropertyName("snake$dollar")]
            public int SnakeDollar { get; init; }

            [JsonPropertyName("snake%percentage")]
            public int SnakePercentage { get; init; }

            [JsonPropertyName("snake&ampersand")]
            public int SnakeAmpersand { get; init; }

            [JsonPropertyName("snake*asterisk")]
            public int SnakeAsterisk { get; init; }
        }

        public readonly struct ColonObject
        {
            [JsonPropertyName("normal_prop")]
            public int NormalProp { get; init; }
        
            [JsonPropertyName("nested:colon")]
            public int NestedColon { get; init; }
        }
        """;
}