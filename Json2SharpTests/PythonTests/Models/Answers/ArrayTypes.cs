namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class ArrayTypes
{
    public const string Input = """
        {
            "empty_array": [],
            "int_array": [ 1, 2, 3 ],
            "nullable_int_array" : [ 1, 2, null ],
            "float_array": [ 1.0, 2.0, 3.0 ],
            "nullable_float_array" : [ 1.0, 2.0, null ],
            "string_array": [ "a", "b", "c" ],
            "nullable_string_array": [ "a", "b", null ],
            "mixed_array": [ 1, "a", 2.1 ],
            "nullable_mixed_array": [ 1, "a", 2.1, null ],
            "thing_array": [ { "text": "hello" } ],
            "nullable_thing_array": [ { "text": "hello" }, null ]
        }
        """;

    public const string DataClassOutput = """
        from typing import Optional
        from dataclasses import dataclass
        
        
        @dataclass
        class NullableThingArray:
            text: str


        @dataclass
        class ThingArray:
            text: str


        @dataclass
        class ArrayTypes:
            empty_array: list[object]
            int_array: list[int]
            nullable_int_array: list[Optional[int]]
            float_array: list[float]
            nullable_float_array: list[Optional[float]]
            string_array: list[str]
            nullable_string_array: list[Optional[str]]
            mixed_array: list[object]
            nullable_mixed_array: list[Optional[object]]
            thing_array: list[ThingArray]
            nullable_thing_array: list[Optional[NullableThingArray]]

        """;

    public const string Output = """
        from typing import Optional


        class NullableThingArray:
            def __init__(
                text: str
            ) -> None:
                self.text = text


        class ThingArray:
            def __init__(
                text: str
            ) -> None:
                self.text = text


        class ArrayTypes:
            def __init__(
                empty_array: list[object],
                int_array: list[int],
                nullable_int_array: list[Optional[int]],
                float_array: list[float],
                nullable_float_array: list[Optional[float]],
                string_array: list[str],
                nullable_string_array: list[Optional[str]],
                mixed_array: list[object],
                nullable_mixed_array: list[Optional[object]],
                thing_array: list[ThingArray],
                nullable_thing_array: list[Optional[NullableThingArray]]
            ) -> None:
                self.empty_array = empty_array
                self.int_array = int_array
                self.nullable_int_array = nullable_int_array
                self.float_array = float_array
                self.nullable_float_array = nullable_float_array
                self.string_array = string_array
                self.nullable_string_array = nullable_string_array
                self.mixed_array = mixed_array
                self.nullable_mixed_array = nullable_mixed_array
                self.thing_array = thing_array
                self.nullable_thing_array = nullable_thing_array

        """;

    public const string OutputNoTypeHints = """
        class NullableThingArray:
            def __init__(
                text
            ):
                self.text = text


        class ThingArray:
            def __init__(
                text
            ):
                self.text = text


        class ArrayTypes:
            def __init__(
                empty_array,
                int_array,
                nullable_int_array,
                float_array,
                nullable_float_array,
                string_array,
                nullable_string_array,
                mixed_array,
                nullable_mixed_array,
                thing_array,
                nullable_thing_array
            ):
                self.empty_array = empty_array
                self.int_array = int_array
                self.nullable_int_array = nullable_int_array
                self.float_array = float_array
                self.nullable_float_array = nullable_float_array
                self.string_array = string_array
                self.nullable_string_array = nullable_string_array
                self.mixed_array = mixed_array
                self.nullable_mixed_array = nullable_mixed_array
                self.thing_array = thing_array
                self.nullable_thing_array = nullable_thing_array

        """;
}