using Json2SharpLib.Common;

namespace Json2SharpTests.Utilities;

public sealed class ToSnakeCaseTests
{
    [Theory]
    [InlineData("snake_case", "snake_case")]
    [InlineData("snake__case", "snake_case")]
    [InlineData("_snake__case_", "snake_case")]
    [InlineData("PascalCase", "pascal_case")]
    [InlineData("SCREAMINGCASE", "screamingcase")]
    [InlineData("SCREAMING_SNAKE", "screaming_snake")]
    [InlineData("kebab-case", "kebab_case")]
    [InlineData("Pascal_Snake", "pascal_snake")]
    [InlineData("snake_case:colon", "snake_case_colon")]
    [InlineData("camelCase:colon", "camel_case_colon")]
    [InlineData("PascalCase:Colon", "pascal_case_colon")]
    [InlineData("SCREAMINGCASE:COLON", "screamingcase_colon")]
    [InlineData("SCREAMING_SNAKE:COLON", "screaming_snake_colon")]
    [InlineData("kebab-case:colon", "kebab_case_colon")]
    [InlineData("Pascal_Snake:Colon", "pascal_snake_colon")]
    [InlineData("snake.dot", "snake_dot")]
    [InlineData("snake@at", "snake_at")]
    [InlineData("snake#hash", "snake_hash")]
    [InlineData("snake$dollar", "snake_dollar")]
    [InlineData("snake%percentage", "snake_percentage")]
    [InlineData("snake&ampersand", "snake_ampersand")]
    [InlineData("snake*asterisk", "snake_asterisk")]
    [InlineData("_private_stuff", "private_stuff")]
    internal void ToSnakeCaseSuccessTest(string input, string expected)
        => Assert.Equal(expected, J2SUtils.ToSnakeCase(input));
}