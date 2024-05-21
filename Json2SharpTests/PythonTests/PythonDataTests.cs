using Json2SharpLib;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using Json2SharpTests.PythonTests.Models.Answers;
using System.Diagnostics;

namespace Json2SharpTests.PythonTests;

public sealed class PythonDataTests
{
    [Theory]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.Output, true, false)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputNoTypeHints, false, false)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputNoTypeHints, false, true)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.DataClassOutput, true, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.Output, true, false)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputNoTypeHints, false, false)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputNoTypeHints, false, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.DataClassOutput, true, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.Output, true, false)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputNoTypeHints, false, false)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputNoTypeHints, false, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.DataClassOutput, true, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.Output, true, false)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputNoTypeHints, false, false)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputNoTypeHints, false, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.DataClassOutput, true, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.Output, true, false)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputNoTypeHints, false, false)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputNoTypeHints, false, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.DataClassOutput, true, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.Output, true, false)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputNoTypeHints, false, false)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputNoTypeHints, false, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.DataClassOutput, true, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.Output, true, false)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputNoTypeHints, false, false)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputNoTypeHints, false, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.DataClassOutput, true, true)]
    [InlineData("EmptyObject", "{}", "", true, false)]
    [InlineData("EmptyObject", "{}", "", false, false)]
    [InlineData("EmptyObject", "{}", "", true, true)]
    internal void OutputTest(string className, string input, string expectedOutput, bool addTypeHints, bool useDataClass)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            PythonOptions = new()
            {
                AddTypeHints = addTypeHints,
                UseDataClass = useDataClass
            }
        };

        var actualOutput = Json2Sharp.Parse(className, input, options);

        Debug.WriteLine(actualOutput);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }
}