namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class ObjectTypes
{
    public const string Input = """
        {
            "null_thing": null,
            "empty_thing": {},
            "thing": {
                "text": "hello world",
                "number": 1,
                "int_array": [ 1, 2, 3 ],
                "prop_base:colon": 2,
                "prop_custom:colon": { "blep": "nested" }
            }
        }
        """;

    public const string DataClassOutputOptional = """
        from dataclasses import dataclass
        from typing import Optional, Any, Self


        @dataclass
        class PropCustomColon:
            blep: str

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'blep': json_dict['blep'],
                }

                return cls(**data)


        @dataclass
        class Thing:
            text: str
            number: int
            int_array: list[int]
            prop_base_colon: int
            prop_custom_colon: PropCustomColon

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'text': json_dict['text'],
                    'number': json_dict['number'],
                    'int_array': json_dict['int_array'],
                    'prop_base_colon': json_dict['prop_base:colon'],
                    'prop_custom_colon': json_dict['prop_custom:colon'],
                }

                return cls(**data)


        @dataclass
        class ObjectTypes:
            null_thing: Optional[object]
            empty_thing: object
            thing: Thing

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'null_thing': json_dict['null_thing'],
                    'empty_thing': json_dict['empty_thing'],
                    'thing': json_dict['thing'],
                }

                return cls(**data)
        """;

    public const string DataClassOutputPipe = """
        from dataclasses import dataclass
        from typing import Any, Self


        @dataclass
        class PropCustomColon:
            blep: str

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'blep': json_dict['blep'],
                }

                return cls(**data)


        @dataclass
        class Thing:
            text: str
            number: int
            int_array: list[int]
            prop_base_colon: int
            prop_custom_colon: PropCustomColon

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'text': json_dict['text'],
                    'number': json_dict['number'],
                    'int_array': json_dict['int_array'],
                    'prop_base_colon': json_dict['prop_base:colon'],
                    'prop_custom_colon': json_dict['prop_custom:colon'],
                }

                return cls(**data)


        @dataclass
        class ObjectTypes:
            null_thing: object | None
            empty_thing: object
            thing: Thing

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'null_thing': json_dict['null_thing'],
                    'empty_thing': json_dict['empty_thing'],
                    'thing': json_dict['thing'],
                }

                return cls(**data)
        """;

    public const string OutputOptional = """
        from typing import Optional, Any, Self


        class PropCustomColon:
            def __init__(
                self,
                blep: str
            ) -> None:
                self.blep: str = blep

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'blep': json_dict['blep'],
                }

                return cls(**data)


        class Thing:
            def __init__(
                self,
                text: str,
                number: int,
                int_array: list[int],
                prop_base_colon: int,
                prop_custom_colon: PropCustomColon
            ) -> None:
                self.text: str = text
                self.number: int = number
                self.int_array: list[int] = int_array
                self.prop_base_colon: int = prop_base_colon
                self.prop_custom_colon: PropCustomColon = prop_custom_colon

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'text': json_dict['text'],
                    'number': json_dict['number'],
                    'int_array': json_dict['int_array'],
                    'prop_base_colon': json_dict['prop_base:colon'],
                    'prop_custom_colon': json_dict['prop_custom:colon'],
                }

                return cls(**data)


        class ObjectTypes:
            def __init__(
                self,
                null_thing: Optional[object],
                empty_thing: object,
                thing: Thing
            ) -> None:
                self.null_thing: Optional[object] = null_thing
                self.empty_thing: object = empty_thing
                self.thing: Thing = thing

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'null_thing': json_dict['null_thing'],
                    'empty_thing': json_dict['empty_thing'],
                    'thing': json_dict['thing'],
                }

                return cls(**data)
        """;

    public const string OutputPipe = """
        from typing import Any, Self


        class PropCustomColon:
            def __init__(
                self,
                blep: str
            ) -> None:
                self.blep: str = blep

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'blep': json_dict['blep'],
                }

                return cls(**data)


        class Thing:
            def __init__(
                self,
                text: str,
                number: int,
                int_array: list[int],
                prop_base_colon: int,
                prop_custom_colon: PropCustomColon
            ) -> None:
                self.text: str = text
                self.number: int = number
                self.int_array: list[int] = int_array
                self.prop_base_colon: int = prop_base_colon
                self.prop_custom_colon: PropCustomColon = prop_custom_colon

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'text': json_dict['text'],
                    'number': json_dict['number'],
                    'int_array': json_dict['int_array'],
                    'prop_base_colon': json_dict['prop_base:colon'],
                    'prop_custom_colon': json_dict['prop_custom:colon'],
                }

                return cls(**data)


        class ObjectTypes:
            def __init__(
                self,
                null_thing: object | None,
                empty_thing: object,
                thing: Thing
            ) -> None:
                self.null_thing: object | None = null_thing
                self.empty_thing: object = empty_thing
                self.thing: Thing = thing

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'null_thing': json_dict['null_thing'],
                    'empty_thing': json_dict['empty_thing'],
                    'thing': json_dict['thing'],
                }

                return cls(**data)
        """;

    public const string OutputNoTypeHints = """
        class PropCustomColon:
            def __init__(
                self,
                blep
            ):
                self.blep = blep

            @classmethod
            def from_json(cls, json_dict):
                data = {
                    'blep': json_dict['blep'],
                }

                return cls(**data)


        class Thing:
            def __init__(
                self,
                text,
                number,
                int_array,
                prop_base_colon,
                prop_custom_colon
            ):
                self.text = text
                self.number = number
                self.int_array = int_array
                self.prop_base_colon = prop_base_colon
                self.prop_custom_colon = prop_custom_colon

            @classmethod
            def from_json(cls, json_dict):
                data = {
                    'text': json_dict['text'],
                    'number': json_dict['number'],
                    'int_array': json_dict['int_array'],
                    'prop_base_colon': json_dict['prop_base:colon'],
                    'prop_custom_colon': json_dict['prop_custom:colon'],
                }

                return cls(**data)


        class ObjectTypes:
            def __init__(
                self,
                null_thing,
                empty_thing,
                thing
            ):
                self.null_thing = null_thing
                self.empty_thing = empty_thing
                self.thing = thing

            @classmethod
            def from_json(cls, json_dict):
                data = {
                    'null_thing': json_dict['null_thing'],
                    'empty_thing': json_dict['empty_thing'],
                    'thing': json_dict['thing'],
                }

                return cls(**data)
        """;

    public const string PydanticOptionalOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated, Optional


        class PropCustomColon(BaseModel):
            blep: Annotated[str, Field(alias='blep')]


        class Thing(BaseModel):
            text: Annotated[str, Field(alias='text')]
            number: Annotated[int, Field(alias='number')]
            int_array: Annotated[list[int], Field(alias='int_array')]
            prop_base_colon: Annotated[int, Field(alias='prop_base:colon')]
            prop_custom_colon: Annotated[PropCustomColon, Field(alias='prop_custom:colon')]


        class ObjectTypes(BaseModel):
            null_thing: Annotated[Optional[object], Field(alias='null_thing')]
            empty_thing: Annotated[object, Field(alias='empty_thing')]
            thing: Annotated[Thing, Field(alias='thing')]
        """;

    public const string PydanticPipeOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class PropCustomColon(BaseModel):
            blep: Annotated[str, Field(alias='blep')]


        class Thing(BaseModel):
            text: Annotated[str, Field(alias='text')]
            number: Annotated[int, Field(alias='number')]
            int_array: Annotated[list[int], Field(alias='int_array')]
            prop_base_colon: Annotated[int, Field(alias='prop_base:colon')]
            prop_custom_colon: Annotated[PropCustomColon, Field(alias='prop_custom:colon')]


        class ObjectTypes(BaseModel):
            null_thing: Annotated[object | None, Field(alias='null_thing')]
            empty_thing: Annotated[object, Field(alias='empty_thing')]
            thing: Annotated[Thing, Field(alias='thing')]
        """;
}