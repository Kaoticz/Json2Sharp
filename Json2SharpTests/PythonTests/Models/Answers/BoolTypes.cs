namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class BoolTypes
{
    public const string Input = """
        {
            "true_bool": true,
            "false_bool": false
        }
        """;

    public const string DataClassOutputOptional = """
        from dataclasses import dataclass


        @dataclass
        class BoolTypes:
            true_bool: bool
            false_bool: bool

        """;

    public const string DataClassOutputPipe = """
        from dataclasses import dataclass


        @dataclass
        class BoolTypes:
            true_bool: bool
            false_bool: bool

        """;

    public const string OutputOptional = """
        class BoolTypes:
            def __init__(
                true_bool: bool,
                false_bool: bool
            ) -> None:
                self.true_bool: bool = true_bool
                self.false_bool: bool = false_bool

        """;

    public const string OutputPipe = """
        class BoolTypes:
            def __init__(
                true_bool: bool,
                false_bool: bool
            ) -> None:
                self.true_bool: bool = true_bool
                self.false_bool: bool = false_bool

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