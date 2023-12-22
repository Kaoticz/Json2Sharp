namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class IntegerTypes
{
    public const string Input = """
        {
            "int_number": 2147483647,
            "uint_number": 2147483648,
            "long_number": 4294967296,
            "ulong_number": 9223372036854775808
        }
        """;

    public const string Output = """
        class IntegerTypes:
            def __init__(
                int_number: int,
                uint_number: int,
                long_number: int,
                ulong_number: int
            ) -> None:
                self.int_number = int_number
                self.uint_number = uint_number
                self.long_number = long_number
                self.ulong_number = ulong_number
        """;
}