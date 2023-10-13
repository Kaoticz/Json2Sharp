using Json2SharpTests.CSharpTests.Models.Answers;
using Json2SharpLib.Enums;
using Json2SharpLib.Common;
using Json2SharpLib.Models;

namespace Json2SharpTests.CSharpTests;

public sealed class DataTests
{
    [Theory]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    internal void OutputTest(string className, string input, string expectedOutput, CSharpObjectType targetType, CSharpSerializationAttribute serializationAttribute)
    {
        var options = new Json2SharpOptions()
        {
            CSharp = new()
            {
                TargetType = targetType,
                SerializationAttribute = serializationAttribute
            }
        };

        var actualOutput = Json2Sharp.Parse(className, input, options);

        Assert.Equal(expectedOutput.Replace("\r", string.Empty), actualOutput.Replace("\r", string.Empty));
    }
}