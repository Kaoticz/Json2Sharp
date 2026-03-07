namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class IntegerTypes
{
    public const string Input = """
        {
            "int_number": 2147483647,
            "uint_number": 2147483648,
            "long_number": 4294967296,
            "ulong_number": 9223372036854775808,
            "big_int": 18446744073709551616
        }
        """;

    public const string DataClassOutputOptional = """
        from dataclasses import dataclass
        from typing import Any, Self


        @dataclass
        class IntegerTypes:
            int_number: int
            uint_number: int
            long_number: int
            ulong_number: int
            big_int: int

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'int_number': json_dict['int_number'],
                    'uint_number': json_dict['uint_number'],
                    'long_number': json_dict['long_number'],
                    'ulong_number': json_dict['ulong_number'],
                    'big_int': json_dict['big_int'],
                }

                return cls(**data)
        """;

    public const string DataClassOutputPipe = """
        from dataclasses import dataclass
        from typing import Any, Self


        @dataclass
        class IntegerTypes:
            int_number: int
            uint_number: int
            long_number: int
            ulong_number: int
            big_int: int

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'int_number': json_dict['int_number'],
                    'uint_number': json_dict['uint_number'],
                    'long_number': json_dict['long_number'],
                    'ulong_number': json_dict['ulong_number'],
                    'big_int': json_dict['big_int'],
                }

                return cls(**data)
        """;

    public const string OutputOptional = """
        from typing import Any, Self


        class IntegerTypes:
            def __init__(
                self,
                int_number: int,
                uint_number: int,
                long_number: int,
                ulong_number: int,
                big_int: int
            ) -> None:
                self.int_number: int = int_number
                self.uint_number: int = uint_number
                self.long_number: int = long_number
                self.ulong_number: int = ulong_number
                self.big_int: int = big_int

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'int_number': json_dict['int_number'],
                    'uint_number': json_dict['uint_number'],
                    'long_number': json_dict['long_number'],
                    'ulong_number': json_dict['ulong_number'],
                    'big_int': json_dict['big_int'],
                }

                return cls(**data)
        """;

    public const string OutputPipe = """
        from typing import Any, Self


        class IntegerTypes:
            def __init__(
                self,
                int_number: int,
                uint_number: int,
                long_number: int,
                ulong_number: int,
                big_int: int
            ) -> None:
                self.int_number: int = int_number
                self.uint_number: int = uint_number
                self.long_number: int = long_number
                self.ulong_number: int = ulong_number
                self.big_int: int = big_int

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'int_number': json_dict['int_number'],
                    'uint_number': json_dict['uint_number'],
                    'long_number': json_dict['long_number'],
                    'ulong_number': json_dict['ulong_number'],
                    'big_int': json_dict['big_int'],
                }

                return cls(**data)
        """;

    public const string OutputNoTypeHints = """
        class IntegerTypes:
            def __init__(
                self,
                int_number,
                uint_number,
                long_number,
                ulong_number,
                big_int
            ):
                self.int_number = int_number
                self.uint_number = uint_number
                self.long_number = long_number
                self.ulong_number = ulong_number
                self.big_int = big_int

            @classmethod
            def from_json(cls, json_dict):
                data = {
                    'int_number': json_dict['int_number'],
                    'uint_number': json_dict['uint_number'],
                    'long_number': json_dict['long_number'],
                    'ulong_number': json_dict['ulong_number'],
                    'big_int': json_dict['big_int'],
                }

                return cls(**data)
        """;

    public const string PydanticOptionalOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class IntegerTypes(BaseModel):
            int_number: Annotated[int, Field(alias='int_number')]
            uint_number: Annotated[int, Field(alias='uint_number')]
            long_number: Annotated[int, Field(alias='long_number')]
            ulong_number: Annotated[int, Field(alias='ulong_number')]
            big_int: Annotated[int, Field(alias='big_int')]
        """;

    public const string PydanticPipeOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class IntegerTypes(BaseModel):
            int_number: Annotated[int, Field(alias='int_number')]
            uint_number: Annotated[int, Field(alias='uint_number')]
            long_number: Annotated[int, Field(alias='long_number')]
            ulong_number: Annotated[int, Field(alias='ulong_number')]
            big_int: Annotated[int, Field(alias='big_int')]
        """;
}