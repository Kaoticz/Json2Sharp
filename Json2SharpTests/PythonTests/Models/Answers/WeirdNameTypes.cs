namespace Json2SharpTests.PythonTests.Models.Answers;

internal static class WeirdNameTypes
{
    public const string Input = """
        {
            "snake_case": 1,
            "camelCase": 2,
            "PascalCase": 3,
            "SCREAMINGCASE": 4,
            "SCREAMING_SNAKE": 5,
            "kebab-case": 6,
            "Pascal_Snake": 7,
            "snake_case:colon": 8,
            "camelCase:colon": 9,
            "PascalCase:Colon": 10,
            "SCREAMINGCASE:COLON": 11,
            "SCREAMING_SNAKE:COLON": 12,
            "kebab-case:colon": 13,
            "Pascal_Snake:Colon": 14,
            "colon:object": {
                "normal_prop": 15,
                "nested:colon": 16
            },
            "snake.dot": 17,
            "snake@at": 18,
            "snake#hash": 19,
            "snake$dollar": 20,
            "snake%percentage": 21,
            "snake&ampersand": 22,
            "snake*asterisk": 23
        }
        """;

    public const string DataClassOutputOptional = """
        from dataclasses import dataclass


        @dataclass
        class ColonObject:
            normal_prop: int
            nested_colon: int

        
        @dataclass
        class WeirdNameTypes:
            snake_case: int
            camel_case: int
            pascal_case: int
            screamingcase: int
            screaming_snake: int
            kebab_case: int
            pascal_snake: int
            snake_case_colon: int
            camel_case_colon: int
            pascal_case_colon: int
            screamingcase_colon: int
            screaming_snake_colon: int
            kebab_case_colon: int
            pascal_snake_colon: int
            colon_object: ColonObject
            snake_dot: int
            snake_at: int
            snake_hash: int
            snake_dollar: int
            snake_percentage: int
            snake_ampersand: int
            snake_asterisk: int

        """;

    public const string DataClassOutputPipe = """
        from dataclasses import dataclass


        @dataclass
        class ColonObject:
            normal_prop: int
            nested_colon: int

        
        @dataclass
        class WeirdNameTypes:
            snake_case: int
            camel_case: int
            pascal_case: int
            screamingcase: int
            screaming_snake: int
            kebab_case: int
            pascal_snake: int
            snake_case_colon: int
            camel_case_colon: int
            pascal_case_colon: int
            screamingcase_colon: int
            screaming_snake_colon: int
            kebab_case_colon: int
            pascal_snake_colon: int
            colon_object: ColonObject
            snake_dot: int
            snake_at: int
            snake_hash: int
            snake_dollar: int
            snake_percentage: int
            snake_ampersand: int
            snake_asterisk: int

        """;

    public const string OutputOptional = """
        class ColonObject:
            def __init__(
                normal_prop: int,
                nested_colon: int
            ) -> None:
                self.normal_prop: int = normal_prop
                self.nested_colon: int = nested_colon


        class WeirdNameTypes:
            def __init__(
                snake_case: int,
                camel_case: int,
                pascal_case: int,
                screamingcase: int,
                screaming_snake: int,
                kebab_case: int,
                pascal_snake: int,
                snake_case_colon: int,
                camel_case_colon: int,
                pascal_case_colon: int,
                screamingcase_colon: int,
                screaming_snake_colon: int,
                kebab_case_colon: int,
                pascal_snake_colon: int,
                colon_object: ColonObject,
                snake_dot: int,
                snake_at: int,
                snake_hash: int,
                snake_dollar: int,
                snake_percentage: int,
                snake_ampersand: int,
                snake_asterisk: int
            ) -> None:
                self.snake_case: int = snake_case
                self.camel_case: int = camel_case
                self.pascal_case: int = pascal_case
                self.screamingcase: int = screamingcase
                self.screaming_snake: int = screaming_snake
                self.kebab_case: int = kebab_case
                self.pascal_snake: int = pascal_snake
                self.snake_case_colon: int = snake_case_colon
                self.camel_case_colon: int = camel_case_colon
                self.pascal_case_colon: int = pascal_case_colon
                self.screamingcase_colon: int = screamingcase_colon
                self.screaming_snake_colon: int = screaming_snake_colon
                self.kebab_case_colon: int = kebab_case_colon
                self.pascal_snake_colon: int = pascal_snake_colon
                self.colon_object: ColonObject = colon_object
                self.snake_dot: int = snake_dot
                self.snake_at: int = snake_at
                self.snake_hash: int = snake_hash
                self.snake_dollar: int = snake_dollar
                self.snake_percentage: int = snake_percentage
                self.snake_ampersand: int = snake_ampersand
                self.snake_asterisk: int = snake_asterisk

        """;

    public const string OutputPipe = """
        class ColonObject:
            def __init__(
                normal_prop: int,
                nested_colon: int
            ) -> None:
                self.normal_prop: int = normal_prop
                self.nested_colon: int = nested_colon


        class WeirdNameTypes:
            def __init__(
                snake_case: int,
                camel_case: int,
                pascal_case: int,
                screamingcase: int,
                screaming_snake: int,
                kebab_case: int,
                pascal_snake: int,
                snake_case_colon: int,
                camel_case_colon: int,
                pascal_case_colon: int,
                screamingcase_colon: int,
                screaming_snake_colon: int,
                kebab_case_colon: int,
                pascal_snake_colon: int,
                colon_object: ColonObject,
                snake_dot: int,
                snake_at: int,
                snake_hash: int,
                snake_dollar: int,
                snake_percentage: int,
                snake_ampersand: int,
                snake_asterisk: int
            ) -> None:
                self.snake_case: int = snake_case
                self.camel_case: int = camel_case
                self.pascal_case: int = pascal_case
                self.screamingcase: int = screamingcase
                self.screaming_snake: int = screaming_snake
                self.kebab_case: int = kebab_case
                self.pascal_snake: int = pascal_snake
                self.snake_case_colon: int = snake_case_colon
                self.camel_case_colon: int = camel_case_colon
                self.pascal_case_colon: int = pascal_case_colon
                self.screamingcase_colon: int = screamingcase_colon
                self.screaming_snake_colon: int = screaming_snake_colon
                self.kebab_case_colon: int = kebab_case_colon
                self.pascal_snake_colon: int = pascal_snake_colon
                self.colon_object: ColonObject = colon_object
                self.snake_dot: int = snake_dot
                self.snake_at: int = snake_at
                self.snake_hash: int = snake_hash
                self.snake_dollar: int = snake_dollar
                self.snake_percentage: int = snake_percentage
                self.snake_ampersand: int = snake_ampersand
                self.snake_asterisk: int = snake_asterisk

        """;

    public const string OutputNoTypeHints = """
        class ColonObject:
            def __init__(
                normal_prop,
                nested_colon
            ):
                self.normal_prop = normal_prop
                self.nested_colon = nested_colon


        class WeirdNameTypes:
            def __init__(
                snake_case,
                camel_case,
                pascal_case,
                screamingcase,
                screaming_snake,
                kebab_case,
                pascal_snake,
                snake_case_colon,
                camel_case_colon,
                pascal_case_colon,
                screamingcase_colon,
                screaming_snake_colon,
                kebab_case_colon,
                pascal_snake_colon,
                colon_object,
                snake_dot,
                snake_at,
                snake_hash,
                snake_dollar,
                snake_percentage,
                snake_ampersand,
                snake_asterisk
            ):
                self.snake_case = snake_case
                self.camel_case = camel_case
                self.pascal_case = pascal_case
                self.screamingcase = screamingcase
                self.screaming_snake = screaming_snake
                self.kebab_case = kebab_case
                self.pascal_snake = pascal_snake
                self.snake_case_colon = snake_case_colon
                self.camel_case_colon = camel_case_colon
                self.pascal_case_colon = pascal_case_colon
                self.screamingcase_colon = screamingcase_colon
                self.screaming_snake_colon = screaming_snake_colon
                self.kebab_case_colon = kebab_case_colon
                self.pascal_snake_colon = pascal_snake_colon
                self.colon_object = colon_object
                self.snake_dot = snake_dot
                self.snake_at = snake_at
                self.snake_hash = snake_hash
                self.snake_dollar = snake_dollar
                self.snake_percentage = snake_percentage
                self.snake_ampersand = snake_ampersand
                self.snake_asterisk = snake_asterisk

        """;

    public const string PydanticOptionalOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class ColonObject(BaseModel):
            normal_prop: Annotated[int, Field(alias='normal_prop')]
            nested_colon: Annotated[int, Field(alias='nested:colon')]


        class WeirdNameTypes(BaseModel):
            snake_case: Annotated[int, Field(alias='snake_case')]
            camel_case: Annotated[int, Field(alias='camelCase')]
            pascal_case: Annotated[int, Field(alias='PascalCase')]
            screamingcase: Annotated[int, Field(alias='SCREAMINGCASE')]
            screaming_snake: Annotated[int, Field(alias='SCREAMING_SNAKE')]
            kebab_case: Annotated[int, Field(alias='kebab-case')]
            pascal_snake: Annotated[int, Field(alias='Pascal_Snake')]
            snake_case_colon: Annotated[int, Field(alias='snake_case:colon')]
            camel_case_colon: Annotated[int, Field(alias='camelCase:colon')]
            pascal_case_colon: Annotated[int, Field(alias='PascalCase:Colon')]
            screamingcase_colon: Annotated[int, Field(alias='SCREAMINGCASE:COLON')]
            screaming_snake_colon: Annotated[int, Field(alias='SCREAMING_SNAKE:COLON')]
            kebab_case_colon: Annotated[int, Field(alias='kebab-case:colon')]
            pascal_snake_colon: Annotated[int, Field(alias='Pascal_Snake:Colon')]
            colon_object: Annotated[ColonObject, Field(alias='colon:object')]
            snake_dot: Annotated[int, Field(alias='snake.dot')]
            snake_at: Annotated[int, Field(alias='snake@at')]
            snake_hash: Annotated[int, Field(alias='snake#hash')]
            snake_dollar: Annotated[int, Field(alias='snake$dollar')]
            snake_percentage: Annotated[int, Field(alias='snake%percentage')]
            snake_ampersand: Annotated[int, Field(alias='snake&ampersand')]
            snake_asterisk: Annotated[int, Field(alias='snake*asterisk')]

        """;

    public const string PydanticPipeOutput = """
        from pydantic import BaseModel, Field
        from typing import Annotated


        class ColonObject(BaseModel):
            normal_prop: Annotated[int, Field(alias='normal_prop')]
            nested_colon: Annotated[int, Field(alias='nested:colon')]


        class WeirdNameTypes(BaseModel):
            snake_case: Annotated[int, Field(alias='snake_case')]
            camel_case: Annotated[int, Field(alias='camelCase')]
            pascal_case: Annotated[int, Field(alias='PascalCase')]
            screamingcase: Annotated[int, Field(alias='SCREAMINGCASE')]
            screaming_snake: Annotated[int, Field(alias='SCREAMING_SNAKE')]
            kebab_case: Annotated[int, Field(alias='kebab-case')]
            pascal_snake: Annotated[int, Field(alias='Pascal_Snake')]
            snake_case_colon: Annotated[int, Field(alias='snake_case:colon')]
            camel_case_colon: Annotated[int, Field(alias='camelCase:colon')]
            pascal_case_colon: Annotated[int, Field(alias='PascalCase:Colon')]
            screamingcase_colon: Annotated[int, Field(alias='SCREAMINGCASE:COLON')]
            screaming_snake_colon: Annotated[int, Field(alias='SCREAMING_SNAKE:COLON')]
            kebab_case_colon: Annotated[int, Field(alias='kebab-case:colon')]
            pascal_snake_colon: Annotated[int, Field(alias='Pascal_Snake:Colon')]
            colon_object: Annotated[ColonObject, Field(alias='colon:object')]
            snake_dot: Annotated[int, Field(alias='snake.dot')]
            snake_at: Annotated[int, Field(alias='snake@at')]
            snake_hash: Annotated[int, Field(alias='snake#hash')]
            snake_dollar: Annotated[int, Field(alias='snake$dollar')]
            snake_percentage: Annotated[int, Field(alias='snake%percentage')]
            snake_ampersand: Annotated[int, Field(alias='snake&ampersand')]
            snake_asterisk: Annotated[int, Field(alias='snake*asterisk')]

        """;
}