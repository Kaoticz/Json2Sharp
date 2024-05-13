namespace Json2SharpTests.CSharpTests.Models.Answers;

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

    public const string BadInput1 = """
        [
            { "id": 1 },
            { "number": 1 }
        ]
        """;

    public const string BadInput2 = """
        [
            { "id": 1 },
            { "name": "blep" }
        ]
        """;

    public const string BadInput3 = """
        [
            { "id": 1 },
            null
        ]
        """;

    public const string BadInput4 = "[]";

    public const string RecordPrimaryCtorOutput = """
        using Newtonsoft.Json;

        public sealed record ArrayRoot(
            [JsonProperty("id")] int Id
        );
        """;

    public const string RecordPrimaryCtorOutputNoAtt = """
        public sealed record ArrayRoot(
            int Id
        );
        """;

    public const string RecordOutput = """
        using System.Text.Json.Serialization;

        public sealed record ArrayRoot(
            [property: JsonPropertyName("id")] int Id
        );
        """;

    public const string ClassOutput = """
        using System.Text.Json.Serialization;

        public sealed class ArrayRoot
        {
            [JsonPropertyName("id")]
            public int Id { get; init; }
        }
        """;

    public const string ClassOutputNoAtt = """
        public sealed class ArrayRoot
        {
            public int Id { get; init; }
        }
        """;

    public const string StructOutput = """
        using System.Text.Json.Serialization;

        public struct ArrayRoot
        {
            [JsonPropertyName("id")]
            public int Id { get; init; }
        }
        """;
}