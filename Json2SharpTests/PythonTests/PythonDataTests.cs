using Json2SharpLib;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using Json2SharpTests.PythonTests.Models.Answers;

namespace Json2SharpTests.PythonTests;

public sealed class PythonDataTests
{
    [Theory]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.Output, true)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputNoTypeHints, false)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.Output, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputNoTypeHints, false)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.Output, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputNoTypeHints, false)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.Output, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputNoTypeHints, false)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.Output, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputNoTypeHints, false)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.Output, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputNoTypeHints, false)]
    [InlineData("EmptyObject", "{}", "", true)]
    [InlineData("EmptyObject", "{}", "", false)]
    internal void OutputTest(string className, string input, string expectedOutput, bool addTypeHints)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            PythonOptions = new()
            {
                AddTypeHints = addTypeHints
            }
        };

        var actualOutput = Json2Sharp.Parse(className, input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }
}