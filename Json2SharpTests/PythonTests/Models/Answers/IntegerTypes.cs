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

    public const string DataClassOutputOptional = """
        from dataclasses import dataclass


        @dataclass
        class IntegerTypes:
            int_number: int
            uint_number: int
            long_number: int
            ulong_number: int

        """;

    public const string DataClassOutputPipe = """
        from dataclasses import dataclass


        @dataclass
        class IntegerTypes:
            int_number: int
            uint_number: int
            long_number: int
            ulong_number: int

        """;

    public const string OutputOptional = """
        class IntegerTypes:
            def __init__(
                int_number: int,
                uint_number: int,
                long_number: int,
                ulong_number: int
            ) -> None:
                self.int_number: int = int_number
                self.uint_number: int = uint_number
                self.long_number: int = long_number
                self.ulong_number: int = ulong_number

        """;

    public const string OutputPipe = """
        class IntegerTypes:
            def __init__(
                int_number: int,
                uint_number: int,
                long_number: int,
                ulong_number: int
            ) -> None:
                self.int_number: int = int_number
                self.uint_number: int = uint_number
                self.long_number: int = long_number
                self.ulong_number: int = ulong_number

        """;

    public const string OutputNoTypeHints = """
        class IntegerTypes:
            def __init__(
                int_number,
                uint_number,
                long_number,
                ulong_number
            ):
                self.int_number = int_number
                self.uint_number = uint_number
                self.long_number = long_number
                self.ulong_number = ulong_number

        """;

    public const string PydanticOptionalOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class IntegerTypes(BaseModel):
            int_number: Annotated[int, Field(alias='int_number')]
            uint_number: Annotated[int, Field(alias='uint_number')]
            long_number: Annotated[int, Field(alias='long_number')]
            ulong_number: Annotated[int, Field(alias='ulong_number')]

        """;

    public const string PydanticPipeOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class IntegerTypes(BaseModel):
            int_number: Annotated[int, Field(alias='int_number')]
            uint_number: Annotated[int, Field(alias='uint_number')]
            long_number: Annotated[int, Field(alias='long_number')]
            ulong_number: Annotated[int, Field(alias='ulong_number')]

        """;
}