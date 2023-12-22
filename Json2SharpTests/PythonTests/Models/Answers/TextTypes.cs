namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class TextTypes
{
    public const string Input = """
        {
            "text": "hello world",
            "empty_text": ""
        }
        """;

    public const string Output = """
        class TextTypes:
            def __init__(
                text: str,
                empty_text: str
            ) -> None:
                self.text = text
                self.empty_text = empty_text
        """;

    public const string OutputNoTypeHints = """
        class TextTypes:
            def __init__(
                text,
                empty_text
            ):
                self.text = text
                self.empty_text = empty_text
        """;
}