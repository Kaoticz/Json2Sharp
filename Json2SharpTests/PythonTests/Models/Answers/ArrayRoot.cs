namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class ArrayRoot
{
        public const string Input = """
        [
            { "id": 1 },
            { "id": 2 },
            { "id": 3 },
            { "id": 4 },
            { "id": 5 }
        ]
        """;

        public const string OutputOptional = """
        from typing import Any, Self
        
        
        class ArrayRoot:
            def __init__(
                self,
                id: int
            ) -> None:
                self.id: int = id
        
            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'id': json_dict['id'],
                }
        
                return cls(**data)
        """;

        public const string DataClassOutputOptional = """
        from dataclasses import dataclass
        from typing import Any, Self
        
        
        @dataclass
        class ArrayRoot:
            id: int
        
            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'id': json_dict['id'],
                }
        
                return cls(**data)
        """;

        public const string PydanticOptionalOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated
        
        
        class ArrayRoot(BaseModel):
            id: Annotated[int, Field(alias='id')]
        """;
}
