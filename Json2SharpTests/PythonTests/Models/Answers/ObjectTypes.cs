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
                "int_array": [ 1, 2, 3 ]
            }
        }
        """;

    public const string DataClassOutput = """
        from dataclasses import dataclass
        from typing import Optional

        
        @dataclass
        class Thing:
            text: str
            number: int
            int_array: list[int]

        
        @dataclass
        class ObjectTypes:
            null_thing: Optional[object]
            empty_thing: object
            thing: Thing

        """;

    public const string Output = """
        from typing import Optional


        class Thing:
            def __init__(
                text: str,
                number: int,
                int_array: list[int]
            ) -> None:
                self.text = text
                self.number = number
                self.int_array = int_array


        class ObjectTypes:
            def __init__(
                null_thing: Optional[object],
                empty_thing: object,
                thing: Thing
            ) -> None:
                self.null_thing = null_thing
                self.empty_thing = empty_thing
                self.thing = thing

        """;

    public const string OutputNoTypeHints = """
        class Thing:
            def __init__(
                text,
                number,
                int_array
            ):
                self.text = text
                self.number = number
                self.int_array = int_array


        class ObjectTypes:
            def __init__(
                null_thing,
                empty_thing,
                thing
            ):
                self.null_thing = null_thing
                self.empty_thing = empty_thing
                self.thing = thing

        """;
}