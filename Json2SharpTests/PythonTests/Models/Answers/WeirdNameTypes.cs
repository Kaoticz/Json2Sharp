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

    public const string DataClassOutput = """
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

    public const string Output = """
        class ColonObject:
            def __init__(
                normal_prop: int,
                nested_colon: int
            ) -> None:
                self.normal_prop = normal_prop
                self.nested_colon = nested_colon


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
}