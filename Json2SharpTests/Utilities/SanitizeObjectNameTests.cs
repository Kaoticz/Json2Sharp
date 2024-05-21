using Json2SharpLib.Common;

namespace Json2SharpTests.Utilities;

public sealed class SanitizeObjectNameTests
{
    [Theory]
    [InlineData("hello:world", "hello_world", "_")]
    [InlineData("hello.world", "hello_world", "_")]
    [InlineData("hello$world", "hello_world", "_")]
    [InlineData("hello%world", "hello_world", "_")]
    [InlineData("hello!world", "hello_world", "_")]
    [InlineData("Hello:World", "HelloWorld", "")]
    [InlineData("Hello&World", "HelloWorld", "")]
    [InlineData("Hello*World", "HelloWorld", "")]
    [InlineData("Hello#World", "HelloWorld", "")]
    [InlineData("Hello;World", "HelloWorld", "")]
    internal void SanitizeObjectNameSuccessTests(string input, string expected, string replacement)
        => Assert.Equal(expected, J2SUtils.SanitizeObjectName(input, replacement));

    [Fact]
    internal void SanitizeObjectNameFailTest()
        => Assert.Throws<ArgumentNullException>(() => J2SUtils.SanitizeObjectName("Hello_World", null!));
}