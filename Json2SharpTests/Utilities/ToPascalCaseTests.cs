using Json2SharpLib.Common;

namespace Json2SharpTests.Utilities;

public sealed class ToPascalCaseTests
{
    [Theory]
    [InlineData("snake_case", "SnakeCase")]
    [InlineData("PascalCase", "PascalCase")]
    [InlineData("SCREAMINGCASE", "Screamingcase")]
    [InlineData("SCREAMING_SNAKE", "ScreamingSnake")]
    [InlineData("kebab-case", "KebabCase")]
    [InlineData("Pascal_Snake", "PascalSnake")]
    [InlineData("snake_case:colon", "SnakeCaseColon")]
    [InlineData("camelCase:colon", "CamelCaseColon")]
    [InlineData("PascalCase:Colon", "PascalCaseColon")]
    [InlineData("SCREAMINGCASE:COLON", "ScreamingcaseColon")]
    [InlineData("SCREAMING_SNAKE:COLON", "ScreamingSnakeColon")]
    [InlineData("kebab-case:colon", "KebabCaseColon")]
    [InlineData("Pascal_Snake:Colon", "PascalSnakeColon")]
    [InlineData("snake.dot", "SnakeDot")]
    [InlineData("snake@at", "SnakeAt")]
    [InlineData("snake#hash", "SnakeHash")]
    [InlineData("snake$dollar", "SnakeDollar")]
    [InlineData("snake%percentage", "SnakePercentage")]
    [InlineData("snake&ampersand", "SnakeAmpersand")]
    [InlineData("snake*asterisk", "SnakeAsterisk")]
    [InlineData("_private_stuff", "PrivateStuff")]
    internal void ToPascalCaseSuccessTest(string input, string expected)
        => Assert.Equal(expected, J2SUtils.ToPascalCase(input));
}