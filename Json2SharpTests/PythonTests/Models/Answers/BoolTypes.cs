namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class BoolTypes
{
    public const string Input = """
        {
            "true_bool": true,
            "false_bool": false
        }
        """;

    public const string DataClassOutput = """
        from dataclasses import dataclass


        @dataclass
        class BoolTypes:
            true_bool: bool
            false_bool: bool

        """;

    public const string Output = """
        class BoolTypes:
            def __init__(
                true_bool: bool,
                false_bool: bool
            ) -> None:
                self.true_bool = true_bool
                self.false_bool = false_bool

        """;

    public const string OutputNoTypeHints = """
        class BoolTypes:
            def __init__(
                true_bool,
                false_bool
            ):
                self.true_bool = true_bool
                self.false_bool = false_bool

        """;
}