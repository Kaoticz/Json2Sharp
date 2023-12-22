using Json2SharpLib;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using Json2SharpTests.PythonTests.Models.Answers;

namespace Json2SharpTests.PythonTests;

public sealed class PythonDataTests
{
    [Theory]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.Output)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.Output)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.Output)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.Output)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.Output)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.Output)]
    [InlineData("EmptyObject", "{}", "")]
    internal void OutputTest(string className, string input, string expectedOutput)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            PythonOptions = new()
        };

        var actualOutput = Json2Sharp.Parse(className, input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }
}