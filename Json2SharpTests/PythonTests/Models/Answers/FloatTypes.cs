namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class FloatTypes
{
    public const string Input = """
        {
            "float_number": 3.4028235E+38,
            "double_number": 1.7976931348623157E+308,
            "decimal_number": 7.9228162514264337593543950335
        }
        """;

    public const string DataClassOutput = """
        from dataclasses import dataclass


        @dataclass
        class FloatTypes:
            float_number: float
            double_number: float
            decimal_number: float

        """;

    public const string Output = """
        class FloatTypes:
            def __init__(
                float_number: float,
                double_number: float,
                decimal_number: float
            ) -> None:
                self.float_number = float_number
                self.double_number = double_number
                self.decimal_number = decimal_number

        """;

    public const string OutputNoTypeHints = """
        class FloatTypes:
            def __init__(
                float_number,
                double_number,
                decimal_number
            ):
                self.float_number = float_number
                self.double_number = double_number
                self.decimal_number = decimal_number

        """;
}