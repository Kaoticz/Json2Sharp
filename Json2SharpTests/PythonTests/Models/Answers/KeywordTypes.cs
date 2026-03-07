namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class KeywordTypes
{
        public const string Input = """

        {
        "class": "value",
        "for": "value",
        "1_number": "value"
        }
        
        """;

        public const string Output = """
        from typing import Any, Self
        
        
        class KeywordTypes:
            def __init__(
                self,
                class_: str,
                for_: str,
                _1_number: str
            ) -> None:
                self.class_: str = class_
                self.for_: str = for_
                self._1_number: str = _1_number
        
            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'class_': json_dict['class'],
                    'for_': json_dict['for'],
                    '_1_number': json_dict['1_number'],
                }
        
                return cls(**data)
        """;

        public const string DataClassOutput = """
        from dataclasses import dataclass
        from typing import Any, Self
        
        
        @dataclass
        class KeywordTypes:
            class_: str
            for_: str
            _1_number: str
        
            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'class_': json_dict['class'],
                    'for_': json_dict['for'],
                    '_1_number': json_dict['1_number'],
                }
        
                return cls(**data)
        """;

        public const string PydanticOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated
        
        
        class KeywordTypes(BaseModel):
            class_: Annotated[str, Field(alias='class')]
            for_: Annotated[str, Field(alias='for')]
            _1_number: Annotated[str, Field(alias='1_number')]
        """;
}