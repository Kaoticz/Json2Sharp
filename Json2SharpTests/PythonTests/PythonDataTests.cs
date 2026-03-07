using Json2SharpLib;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using Json2SharpTests.PythonTests.Models.Answers;
using Kotz.Extensions;

namespace Json2SharpTests.PythonTests;

public sealed class PythonDataTests
{
    private static readonly bool[] _boolValues = [true, false];

    public static IEnumerable<object[]> GetExhaustiveTestMatrix()
    {
        foreach (var targetType in Enum.GetValues<PythonObjectType>())
        {
            foreach (var addTypeHints in _boolValues)
            {
                foreach (var useOptional in _boolValues)
                {
                    yield return [targetType, addTypeHints, useOptional];
                }
            }
        }
    }

    [Theory]
    [MemberData(nameof(GetExhaustiveTestMatrix))]
    internal void ExhaustiveMatrixTest(PythonObjectType targetType, bool addTypeHints, bool useOptional)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            PythonOptions = new()
            {
                TargetType = targetType,
                AddTypeHints = addTypeHints,
                UseOptional = useOptional
            }
        };

        // We just want to ensure it doesn't throw and generates SOMETHING.
        var actualOutput = Json2Sharp.Parse("TestClass", BoolTypes.Input, options);
        Assert.NotEmpty(actualOutput);
    }

    [Theory]
    [InlineData(KeywordTypes.Input, KeywordTypes.Output, true, PythonObjectType.Class, true)]
    [InlineData(KeywordTypes.Input, KeywordTypes.DataClassOutput, true, PythonObjectType.DataClass, true)]
    [InlineData(KeywordTypes.Input, KeywordTypes.PydanticOutput, true, PythonObjectType.Pydantic, true)]
    internal void KeywordTest(string input, string expectedOutput, bool addTypeHints, PythonObjectType targetType, bool useOptional)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            PythonOptions = new()
            {
                AddTypeHints = addTypeHints,
                TargetType = targetType,
                UseOptional = useOptional
            }
        };

        var actualOutput = Json2Sharp.Parse("KeywordTypes", input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }

    [Theory]
    // Optional[T] tests
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputOptional, true, PythonObjectType.Class, true)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.DataClassOutputOptional, true, PythonObjectType.DataClass, true)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.PydanticOptionalOutput, true, PythonObjectType.Pydantic, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputOptional, true, PythonObjectType.Class, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.DataClassOutputOptional, true, PythonObjectType.DataClass, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.PydanticOptionalOutput, true, PythonObjectType.Pydantic, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputOptional, true, PythonObjectType.Class, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.DataClassOutputOptional, true, PythonObjectType.DataClass, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.PydanticOptionalOutput, true, PythonObjectType.Pydantic, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputOptional, true, PythonObjectType.Class, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.DataClassOutputOptional, true, PythonObjectType.DataClass, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.PydanticOptionalOutput, true, PythonObjectType.Pydantic, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputOptional, true, PythonObjectType.Class, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.DataClassOutputOptional, true, PythonObjectType.DataClass, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.PydanticOptionalOutput, true, PythonObjectType.Pydantic, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputOptional, true, PythonObjectType.Class, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.DataClassOutputOptional, true, PythonObjectType.DataClass, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.PydanticOptionalOutput, true, PythonObjectType.Pydantic, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputOptional, true, PythonObjectType.Class, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.DataClassOutputOptional, true, PythonObjectType.DataClass, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.PydanticOptionalOutput, true, PythonObjectType.Pydantic, true)]

    // T | None tests
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputPipe, true, PythonObjectType.Class, false)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.DataClassOutputPipe, true, PythonObjectType.DataClass, false)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.PydanticPipeOutput, true, PythonObjectType.Pydantic, false)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputPipe, true, PythonObjectType.Class, false)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.DataClassOutputPipe, true, PythonObjectType.DataClass, false)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.PydanticPipeOutput, true, PythonObjectType.Pydantic, false)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputPipe, true, PythonObjectType.Class, false)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.DataClassOutputPipe, true, PythonObjectType.DataClass, false)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.PydanticPipeOutput, true, PythonObjectType.Pydantic, false)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputPipe, true, PythonObjectType.Class, false)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.DataClassOutputPipe, true, PythonObjectType.DataClass, false)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.PydanticPipeOutput, true, PythonObjectType.Pydantic, false)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputPipe, true, PythonObjectType.Class, false)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.DataClassOutputPipe, true, PythonObjectType.DataClass, false)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.PydanticPipeOutput, true, PythonObjectType.Pydantic, false)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputPipe, true, PythonObjectType.Class, false)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.DataClassOutputPipe, true, PythonObjectType.DataClass, false)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.PydanticPipeOutput, true, PythonObjectType.Pydantic, false)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputPipe, true, PythonObjectType.Class, false)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.DataClassOutputPipe, true, PythonObjectType.DataClass, false)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.PydanticPipeOutput, true, PythonObjectType.Pydantic, false)]
    [InlineData(nameof(ArrayRoot), ArrayRoot.Input, ArrayRoot.OutputOptional, true, PythonObjectType.Class, true)]
    [InlineData(nameof(ArrayRoot), ArrayRoot.Input, ArrayRoot.DataClassOutputOptional, true, PythonObjectType.DataClass, true)]
    [InlineData(nameof(ArrayRoot), ArrayRoot.Input, ArrayRoot.PydanticOptionalOutput, true, PythonObjectType.Pydantic, true)]

    // No type hints tests (should be the same regardless of UseOptional)
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputNoTypeHints, false, PythonObjectType.Class, true)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.OutputNoTypeHints, false, PythonObjectType.DataClass, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputNoTypeHints, false, PythonObjectType.Class, true)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.OutputNoTypeHints, false, PythonObjectType.DataClass, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputNoTypeHints, false, PythonObjectType.Class, true)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.OutputNoTypeHints, false, PythonObjectType.DataClass, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputNoTypeHints, false, PythonObjectType.Class, true)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.OutputNoTypeHints, false, PythonObjectType.DataClass, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputNoTypeHints, false, PythonObjectType.Class, true)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.OutputNoTypeHints, false, PythonObjectType.DataClass, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputNoTypeHints, false, PythonObjectType.Class, true)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.OutputNoTypeHints, false, PythonObjectType.DataClass, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputNoTypeHints, false, PythonObjectType.Class, true)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.OutputNoTypeHints, false, PythonObjectType.DataClass, true)]

    // Empty object tests
    [InlineData("EmptyObject", "{}", "", true, PythonObjectType.Class, true)]
    [InlineData("EmptyObject", "{}", "", true, PythonObjectType.Class, false)]
    [InlineData("EmptyObject", "{}", "", false, PythonObjectType.Class, true)]
    [InlineData("EmptyObject", "{}", "", true, PythonObjectType.DataClass, true)]
    [InlineData("EmptyObject", "{}", "", true, PythonObjectType.DataClass, false)]
    internal void OutputTest(string className, string input, string expectedOutput, bool addTypeHints, PythonObjectType targetType, bool useOptional)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            PythonOptions = new()
            {
                AddTypeHints = addTypeHints,
                TargetType = targetType,
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
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.OutputOptional, PythonObjectType.Class, true)]
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.DataClassOutputOptional, PythonObjectType.DataClass, true)]
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.PydanticOptionalOutput, PythonObjectType.Pydantic, true)]
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.OutputPipe, PythonObjectType.Class, false)]
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.DataClassOutputPipe, PythonObjectType.DataClass, false)]
    [InlineData(nameof(NoneTypeHintTypes), NoneTypeHintTypes.Input, NoneTypeHintTypes.PydanticPipeOutput, PythonObjectType.Pydantic, false)]
    internal void OutputNoneTypeHintsTest(string className, string input, string expectedOutput, PythonObjectType targetType, bool useOptional)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,
            PythonOptions = new()
            {
                AddTypeHints = true,
                TargetType = targetType,
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
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.OutputOptional, true, PythonObjectType.Class, true)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.DataClassOutputOptional, true, PythonObjectType.DataClass, true)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.PydanticOptionalOutput, true, PythonObjectType.Pydantic, true)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.OutputPipe, true, PythonObjectType.Class, false)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.DataClassOutputPipe, true, PythonObjectType.DataClass, false)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.PydanticPipeOutput, true, PythonObjectType.Pydantic, false)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.OutputNoTypeHints, false, PythonObjectType.Class, true)]
    internal void TypeHandleOutputTest(string className, string input, string expectedOutput, bool addTypeHints, PythonObjectType targetType, bool useOptional)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Python,

            PythonOptions = new()
            {
                AddTypeHints = addTypeHints,
                TargetType = targetType,
                UseOptional = useOptional,
                TypeNameHandler = propertyType => propertyType.ToSnakeCase().Replace("_", "__")
            }
        };

        var actualOutput = Json2Sharp.Parse(className.ToSnakeCase().Replace("_", "__"), input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }
}