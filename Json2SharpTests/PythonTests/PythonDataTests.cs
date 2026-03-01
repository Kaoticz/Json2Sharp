using Json2SharpLib;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using Json2SharpTests.PythonTests.Models.Answers;
using Kotz.Extensions;

namespace Json2SharpTests.PythonTests;

public sealed class PythonDataTests
{
    [Theory]
    // Optional[T] tests
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputOptional, true, false, true)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.DataClassOutputOptional, true, true, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputOptional, true, false, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.DataClassOutputOptional, true, true, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputOptional, true, false, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.DataClassOutputOptional, true, true, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputOptional, true, false, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.DataClassOutputOptional, true, true, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputOptional, true, false, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.DataClassOutputOptional, true, true, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputOptional, true, false, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.DataClassOutputOptional, true, true, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputOptional, true, false, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.DataClassOutputOptional, true, true, true)]
    
    // T | None tests
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputPipe, true, false, false)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.DataClassOutputPipe, true, true, false)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputPipe, true, false, false)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.DataClassOutputPipe, true, true, false)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputPipe, true, false, false)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.DataClassOutputPipe, true, true, false)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputPipe, true, false, false)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.DataClassOutputPipe, true, true, false)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputPipe, true, false, false)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.DataClassOutputPipe, true, true, false)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputPipe, true, false, false)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.DataClassOutputPipe, true, true, false)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputPipe, true, false, false)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.DataClassOutputPipe, true, true, false)]

    // No type hints tests (should be the same regardless of UseOptional)
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputNoTypeHints, false, false, true)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputNoTypeHints, false, true, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputNoTypeHints, false, false, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputNoTypeHints, false, true, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputNoTypeHints, false, false, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputNoTypeHints, false, true, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputNoTypeHints, false, false, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputNoTypeHints, false, true, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputNoTypeHints, false, false, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputNoTypeHints, false, true, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputNoTypeHints, false, false, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputNoTypeHints, false, true, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputNoTypeHints, false, false, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputNoTypeHints, false, true, true)]

    // Empty object tests
    [InlineData("EmptyObject", "{}", "", true, false, true)]
    [InlineData("EmptyObject", "{}", "", true, false, false)]
    [InlineData("EmptyObject", "{}", "", false, false, true)]
    [InlineData("EmptyObject", "{}", "", true, true, true)]
    [InlineData("EmptyObject", "{}", "", true, true, false)]
    internal void OutputTest(string className, string input, string expectedOutput, bool addTypeHints, bool useDataClass, bool useOptional)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            PythonOptions = new()
            {
                AddTypeHints = addTypeHints,
                UseDataClass = useDataClass,
                UseOptional = useOptional
            }
        };

        var actualOutput = Json2Sharp.Parse(className, input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }

    [Theory]
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.OutputOptional, false, true)]
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.DataClassOutputOptional, true, true)]
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.OutputPipe, false, false)]
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.DataClassOutputPipe, true, false)]
    internal void OutputNoneTypeHintsTest(string className, string input, string expectedOutput, bool useDataClass, bool useOptional)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            PythonOptions = new()
            {
                AddTypeHints = true,
                UseDataClass = useDataClass,
                UseOptional = useOptional
            }
        };

        var actualOutput = Json2Sharp.Parse(className, input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }
    
        
    [Theory]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.OutputOptional, true, false, true)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.DataClassOutputOptional, true, true, true)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.OutputPipe, true, false, false)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.DataClassOutputPipe, true, true, false)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.OutputNoTypeHints, false, false, true)]
    internal void TypeHandleOutputTest(string className, string input, string expectedOutput, bool addTypeHints, bool useDataClass, bool useOptional)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            
            PythonOptions = new()
            {
                AddTypeHints = addTypeHints,
                UseDataClass = useDataClass,
                UseOptional = useOptional,
                TypeNameHandler = propertyType => propertyType.ToSnakeCase()
            }
        };
        
        var actualOutput = Json2Sharp.Parse(className.ToSnakeCase(), input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }
}
