using Json2SharpLib;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using Json2SharpTests.CSharpTests.Models.Answers;

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
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData("EmptyObject", "{}", "", CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData("EmptyObject", "{}", "", CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData("EmptyObject", "{}", "", CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData("EmptyObject", "{}", "", CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
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

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }
}