using Json2SharpTests.CSharpTests.Models.Answers;
using Json2SharpLib.Enums;
using Json2SharpLib.Common;
using Json2SharpLib.Models;

namespace Json2SharpTests.CSharpTests;

public sealed class IntegerTests
{
    [Theory]
    [InlineData(IntegerTypes.Input, IntegerTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(IntegerTypes.Input, IntegerTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(IntegerTypes.Input, IntegerTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(IntegerTypes.Input, IntegerTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    internal void IntegerTest(string input, string expectedOutput, CSharpObjectType targetType, CSharpSerializationAttribute serializationAttribute)
    {
        var options = new Json2SharpOptions()
        {
            CSharp = new()
            {
                TargetType = targetType,
                SerializationAttribute = serializationAttribute
            }
        };

        var actualOutput = Json2Sharp.Parse(nameof(IntegerTypes), input, options);

        Assert.Equal(expectedOutput.Replace("\r", string.Empty), actualOutput.Replace("\r", string.Empty));
    }
}