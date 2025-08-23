namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class TextTypes
{
    public const string Input = """
        {
            "text": "hello world",
            "empty_text": "",
            "date_time_offset": "2024-05-19T01:23:10.000Z",
            "id": "6c33ac26-953b-46bf-8a5d-a34e1b99e5df"
        }
        """;

    public const string DataClassOutput = """
        from dataclasses import dataclass
        from datetime import datetime
        from uuid import UUID


        @dataclass
        class TextTypes:
            text: str
            empty_text: str
            date_time_offset: datetime
            id: UUID

        """;

    public const string Output = """
        from datetime import datetime
        from uuid import UUID


        class TextTypes:
            def __init__(
                text: str,
                empty_text: str,
                date_time_offset: datetime,
                id: UUID
            ) -> None:
                self.text = text
                self.empty_text = empty_text
                self.date_time_offset = date_time_offset
                self.id = id

        """;

    public const string OutputNoTypeHints = """
        class TextTypes:
            def __init__(
                text,
                empty_text,
                date_time_offset,
                id
            ):
                self.text = text
                self.empty_text = empty_text
                self.date_time_offset = date_time_offset
                self.id = id

        """;
}