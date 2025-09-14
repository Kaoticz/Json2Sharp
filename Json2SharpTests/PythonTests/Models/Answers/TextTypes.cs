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

    public const string DataClassOutput = """
        from dataclasses import dataclass
        from typing import Optional
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

        """;

    public const string Output = """
        from typing import Optional
        from datetime import datetime, timedelta
        from uuid import UUID


        class TextTypes:
            def __init__(
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

        """;

    public const string OutputNoTypeHints = """
        class TextTypes:
            def __init__(
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

        """;
}