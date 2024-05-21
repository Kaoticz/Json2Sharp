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

    public const string DataClassOutput = """
        from dataclasses import dataclass
        from typing import Optional


        @dataclass
        class PropCustomColon:
            blep: str

        
        @dataclass
        class Thing:
            text: str
            number: int
            int_array: list[int]
            prop_base_colon: int
            prop_custom_colon: PropCustomColon

        
        @dataclass
        class ObjectTypes:
            null_thing: Optional[object]
            empty_thing: object
            thing: Thing

        """;

    public const string Output = """
        from typing import Optional


        class PropCustomColon:
            def __init__(
                blep: str
            ) -> None:
                self.blep = blep


        class Thing:
            def __init__(
                text: str,
                number: int,
                int_array: list[int],
                prop_base_colon: int,
                prop_custom_colon: PropCustomColon
            ) -> None:
                self.text = text
                self.number = number
                self.int_array = int_array
                self.prop_base_colon = prop_base_colon
                self.prop_custom_colon = prop_custom_colon


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
        class PropCustomColon:
            def __init__(
                blep
            ):
                self.blep = blep


        class Thing:
            def __init__(
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