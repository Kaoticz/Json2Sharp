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

    public const string DataClassOutputOptional = """
        from dataclasses import dataclass


        @dataclass
        class FloatTypes:
            float_number: float
            double_number: float
            decimal_number: float

        """;

    public const string DataClassOutputPipe = """
        from dataclasses import dataclass


        @dataclass
        class FloatTypes:
            float_number: float
            double_number: float
            decimal_number: float

        """;

    public const string OutputOptional = """
        class FloatTypes:
            def __init__(
                float_number: float,
                double_number: float,
                decimal_number: float
            ) -> None:
                self.float_number: float = float_number
                self.double_number: float = double_number
                self.decimal_number: float = decimal_number

        """;

    public const string OutputPipe = """
        class FloatTypes:
            def __init__(
                float_number: float,
                double_number: float,
                decimal_number: float
            ) -> None:
                self.float_number: float = float_number
                self.double_number: float = double_number
                self.decimal_number: float = decimal_number

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

    public const string PydanticOptionalOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class FloatTypes(BaseModel):
            float_number: Annotated[float, Field(alias='float_number')]
            double_number: Annotated[float, Field(alias='double_number')]
            decimal_number: Annotated[float, Field(alias='decimal_number')]

        """;

    public const string PydanticPipeOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class FloatTypes(BaseModel):
            float_number: Annotated[float, Field(alias='float_number')]
            double_number: Annotated[float, Field(alias='double_number')]
            decimal_number: Annotated[float, Field(alias='decimal_number')]

        """;
}