namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class TextTypes
{
    public const string Input = """
        {
            "text": "hello world",
            "empty_text": "",
            "timespan": "00:00:01",
            "timespans": ["00:00:01"],
            "nullable_timespans": ["00:00:01", null],
            "date_time_offset": "2024-05-19T01:23:10.000Z",
            "date_time_offset_array": ["2024-05-19T01:23:10.000Z"],
            "date_time_offset_nullable_array": ["2024-05-19T01:23:10.000Z", null],
            "id": "6c33ac26-953b-46bf-8a5d-a34e1b99e5df",
            "ids": ["6c33ac26-953b-46bf-8a5d-a34e1b99e5df"],
            "nullable_ids": ["6c33ac26-953b-46bf-8a5d-a34e1b99e5df", null]
        }
        """;

    public const string DataClassOutputOptional = """
        from dataclasses import dataclass
        from typing import Optional, Any, Self
        from datetime import datetime, timedelta
        from uuid import UUID


        @dataclass
        class TextTypes:
            text: str
            empty_text: str
            timespan: timedelta
            timespans: list[timedelta]
            nullable_timespans: list[Optional[timedelta]]
            date_time_offset: datetime
            date_time_offset_array: list[datetime]
            date_time_offset_nullable_array: list[Optional[datetime]]
            id: UUID
            ids: list[UUID]
            nullable_ids: list[Optional[UUID]]

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'text': json_dict['text'],
                    'empty_text': json_dict['empty_text'],
                    'timespan': json_dict['timespan'],
                    'timespans': json_dict['timespans'],
                    'nullable_timespans': json_dict['nullable_timespans'],
                    'date_time_offset': json_dict['date_time_offset'],
                    'date_time_offset_array': json_dict['date_time_offset_array'],
                    'date_time_offset_nullable_array': json_dict['date_time_offset_nullable_array'],
                    'id': json_dict['id'],
                    'ids': json_dict['ids'],
                    'nullable_ids': json_dict['nullable_ids'],
                }

                return cls(**data)
        """;

    public const string DataClassOutputPipe = """
        from dataclasses import dataclass
        from typing import Any, Self
        from datetime import datetime, timedelta
        from uuid import UUID


        @dataclass
        class TextTypes:
            text: str
            empty_text: str
            timespan: timedelta
            timespans: list[timedelta]
            nullable_timespans: list[timedelta | None]
            date_time_offset: datetime
            date_time_offset_array: list[datetime]
            date_time_offset_nullable_array: list[datetime | None]
            id: UUID
            ids: list[UUID]
            nullable_ids: list[UUID | None]

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'text': json_dict['text'],
                    'empty_text': json_dict['empty_text'],
                    'timespan': json_dict['timespan'],
                    'timespans': json_dict['timespans'],
                    'nullable_timespans': json_dict['nullable_timespans'],
                    'date_time_offset': json_dict['date_time_offset'],
                    'date_time_offset_array': json_dict['date_time_offset_array'],
                    'date_time_offset_nullable_array': json_dict['date_time_offset_nullable_array'],
                    'id': json_dict['id'],
                    'ids': json_dict['ids'],
                    'nullable_ids': json_dict['nullable_ids'],
                }

                return cls(**data)
        """;

    public const string OutputOptional = """
        from typing import Optional, Any, Self
        from datetime import datetime, timedelta
        from uuid import UUID


        class TextTypes:
            def __init__(
                self,
                text: str,
                empty_text: str,
                timespan: timedelta,
                timespans: list[timedelta],
                nullable_timespans: list[Optional[timedelta]],
                date_time_offset: datetime,
                date_time_offset_array: list[datetime],
                date_time_offset_nullable_array: list[Optional[datetime]],
                id: UUID,
                ids: list[UUID],
                nullable_ids: list[Optional[UUID]]
            ) -> None:
                self.text: str = text
                self.empty_text: str = empty_text
                self.timespan: timedelta = timespan
                self.timespans: list[timedelta] = timespans
                self.nullable_timespans: list[Optional[timedelta]] = nullable_timespans
                self.date_time_offset: datetime = date_time_offset
                self.date_time_offset_array: list[datetime] = date_time_offset_array
                self.date_time_offset_nullable_array: list[Optional[datetime]] = date_time_offset_nullable_array
                self.id: UUID = id
                self.ids: list[UUID] = ids
                self.nullable_ids: list[Optional[UUID]] = nullable_ids

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'text': json_dict['text'],
                    'empty_text': json_dict['empty_text'],
                    'timespan': json_dict['timespan'],
                    'timespans': json_dict['timespans'],
                    'nullable_timespans': json_dict['nullable_timespans'],
                    'date_time_offset': json_dict['date_time_offset'],
                    'date_time_offset_array': json_dict['date_time_offset_array'],
                    'date_time_offset_nullable_array': json_dict['date_time_offset_nullable_array'],
                    'id': json_dict['id'],
                    'ids': json_dict['ids'],
                    'nullable_ids': json_dict['nullable_ids'],
                }

                return cls(**data)
        """;

    public const string OutputPipe = """
        from typing import Any, Self
        from datetime import datetime, timedelta
        from uuid import UUID


        class TextTypes:
            def __init__(
                self,
                text: str,
                empty_text: str,
                timespan: timedelta,
                timespans: list[timedelta],
                nullable_timespans: list[timedelta | None],
                date_time_offset: datetime,
                date_time_offset_array: list[datetime],
                date_time_offset_nullable_array: list[datetime | None],
                id: UUID,
                ids: list[UUID],
                nullable_ids: list[UUID | None]
            ) -> None:
                self.text: str = text
                self.empty_text: str = empty_text
                self.timespan: timedelta = timespan
                self.timespans: list[timedelta] = timespans
                self.nullable_timespans: list[timedelta | None] = nullable_timespans
                self.date_time_offset: datetime = date_time_offset
                self.date_time_offset_array: list[datetime] = date_time_offset_array
                self.date_time_offset_nullable_array: list[datetime | None] = date_time_offset_nullable_array
                self.id: UUID = id
                self.ids: list[UUID] = ids
                self.nullable_ids: list[UUID | None] = nullable_ids

            @classmethod
            def from_json(cls, json_dict: dict[str, Any]) -> Self:
                data: dict[str, Any] = {
                    'text': json_dict['text'],
                    'empty_text': json_dict['empty_text'],
                    'timespan': json_dict['timespan'],
                    'timespans': json_dict['timespans'],
                    'nullable_timespans': json_dict['nullable_timespans'],
                    'date_time_offset': json_dict['date_time_offset'],
                    'date_time_offset_array': json_dict['date_time_offset_array'],
                    'date_time_offset_nullable_array': json_dict['date_time_offset_nullable_array'],
                    'id': json_dict['id'],
                    'ids': json_dict['ids'],
                    'nullable_ids': json_dict['nullable_ids'],
                }

                return cls(**data)
        """;

    public const string OutputNoTypeHints = """
        class TextTypes:
            def __init__(
                self,
                text,
                empty_text,
                timespan,
                timespans,
                nullable_timespans,
                date_time_offset,
                date_time_offset_array,
                date_time_offset_nullable_array,
                id,
                ids,
                nullable_ids
            ):
                self.text = text
                self.empty_text = empty_text
                self.timespan = timespan
                self.timespans = timespans
                self.nullable_timespans = nullable_timespans
                self.date_time_offset = date_time_offset
                self.date_time_offset_array = date_time_offset_array
                self.date_time_offset_nullable_array = date_time_offset_nullable_array
                self.id = id
                self.ids = ids
                self.nullable_ids = nullable_ids

            @classmethod
            def from_json(cls, json_dict):
                data = {
                    'text': json_dict['text'],
                    'empty_text': json_dict['empty_text'],
                    'timespan': json_dict['timespan'],
                    'timespans': json_dict['timespans'],
                    'nullable_timespans': json_dict['nullable_timespans'],
                    'date_time_offset': json_dict['date_time_offset'],
                    'date_time_offset_array': json_dict['date_time_offset_array'],
                    'date_time_offset_nullable_array': json_dict['date_time_offset_nullable_array'],
                    'id': json_dict['id'],
                    'ids': json_dict['ids'],
                    'nullable_ids': json_dict['nullable_ids'],
                }

                return cls(**data)
        """;

    public const string PydanticOptionalOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated, Optional
        from datetime import datetime, timedelta
        from uuid import UUID


        class TextTypes(BaseModel):
            text: Annotated[str, Field(alias='text')]
            empty_text: Annotated[str, Field(alias='empty_text')]
            timespan: Annotated[timedelta, Field(alias='timespan')]
            timespans: Annotated[list[timedelta], Field(alias='timespans')]
            nullable_timespans: Annotated[list[Optional[timedelta]], Field(alias='nullable_timespans')]
            date_time_offset: Annotated[datetime, Field(alias='date_time_offset')]
            date_time_offset_array: Annotated[list[datetime], Field(alias='date_time_offset_array')]
            date_time_offset_nullable_array: Annotated[list[Optional[datetime]], Field(alias='date_time_offset_nullable_array')]
            id: Annotated[UUID, Field(alias='id')]
            ids: Annotated[list[UUID], Field(alias='ids')]
            nullable_ids: Annotated[list[Optional[UUID]], Field(alias='nullable_ids')]
        """;

    public const string PydanticPipeOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated
        from datetime import datetime, timedelta
        from uuid import UUID


        class TextTypes(BaseModel):
            text: Annotated[str, Field(alias='text')]
            empty_text: Annotated[str, Field(alias='empty_text')]
            timespan: Annotated[timedelta, Field(alias='timespan')]
            timespans: Annotated[list[timedelta], Field(alias='timespans')]
            nullable_timespans: Annotated[list[timedelta | None], Field(alias='nullable_timespans')]
            date_time_offset: Annotated[datetime, Field(alias='date_time_offset')]
            date_time_offset_array: Annotated[list[datetime], Field(alias='date_time_offset_array')]
            date_time_offset_nullable_array: Annotated[list[datetime | None], Field(alias='date_time_offset_nullable_array')]
            id: Annotated[UUID, Field(alias='id')]
            ids: Annotated[list[UUID], Field(alias='ids')]
            nullable_ids: Annotated[list[UUID | None], Field(alias='nullable_ids')]
        """;
}