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
        from typing import Any, Self


        @dataclass
        class BoolTypes:
            true_bool: bool
            false_bool: bool

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'true_bool': json_dict['true_bool'],
                    'false_bool': json_dict['false_bool'],
                }

                return cls(**data)

        """;

    public const string DataClassOutputPipe = """
        from dataclasses import dataclass
        from typing import Any, Self


        @dataclass
        class BoolTypes:
            true_bool: bool
            false_bool: bool

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'true_bool': json_dict['true_bool'],
                    'false_bool': json_dict['false_bool'],
                }

                return cls(**data)

        """;

    public const string OutputOptional = """
        from typing import Any, Self


        class BoolTypes:
            def __init__(
                true_bool: bool,
                false_bool: bool
            ) -> None:
                self.true_bool: bool = true_bool
                self.false_bool: bool = false_bool

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'true_bool': json_dict['true_bool'],
                    'false_bool': json_dict['false_bool'],
                }

                return cls(**data)

        """;

    public const string OutputPipe = """
        from typing import Any, Self


        class BoolTypes:
            def __init__(
                true_bool: bool,
                false_bool: bool
            ) -> None:
                self.true_bool: bool = true_bool
                self.false_bool: bool = false_bool

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'true_bool': json_dict['true_bool'],
                    'false_bool': json_dict['false_bool'],
                }

                return cls(**data)

        """;

    public const string OutputNoTypeHints = """
        class BoolTypes:
            def __init__(
                true_bool,
                false_bool
            ):
                self.true_bool = true_bool
                self.false_bool = false_bool

            @classmethod
            def from_json(cls, json_dict):
                data = {
                    'true_bool': json_dict['true_bool'],
                    'false_bool': json_dict['false_bool'],
                }

                return cls(**data)

        """;

    public const string PydanticOptionalOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class BoolTypes(BaseModel):
            true_bool: Annotated[bool, Field(alias='true_bool')]
            false_bool: Annotated[bool, Field(alias='false_bool')]

        """;

    public const string PydanticPipeOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class BoolTypes(BaseModel):
            true_bool: Annotated[bool, Field(alias='true_bool')]
            false_bool: Annotated[bool, Field(alias='false_bool')]

        """;
}