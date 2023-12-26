namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class ObjectTypes
{
    public const string Input = """
        {
            "null_thing": null,
            "thing": {
                "text": "hello world",
                "number": 1,
                "int_array": [ 1, 2, 3 ]
            }
        }
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
                thing: Thing
            ) -> None:
                self.null_thing = null_thing
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
                thing
            ):
                self.null_thing = null_thing
                self.thing = thing
        """;
}