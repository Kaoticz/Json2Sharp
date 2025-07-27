using Json2SharpLib;
using Json2SharpLib.Enums;
using Json2SharpLib.Models;
using Json2SharpTests.CSharpTests.Models.Answers;
using Kotz.Extensions;

namespace Json2SharpTests.CSharpTests;

public sealed class CSharpDataTests
{
    [Theory]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.RecordPrimaryCtorOutputNoAtt, CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.ClassOutputNoAtt, CSharpObjectType.Class, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(IntegerTypes), IntegerTypes.Input, IntegerTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.RecordPrimaryCtorOutputNoAtt, CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.ClassOutputNoAtt, CSharpObjectType.Class, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(FloatTypes), FloatTypes.Input, FloatTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.RecordPrimaryCtorOutputNoAtt, CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.ClassOutputNoAtt, CSharpObjectType.Class, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(TextTypes), TextTypes.Input, TextTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.RecordPrimaryCtorOutputNoAtt, CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.ClassOutputNoAtt, CSharpObjectType.Class, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(BoolTypes), BoolTypes.Input, BoolTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.RecordPrimaryCtorOutputNoAtt, CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.ClassOutputNoAtt, CSharpObjectType.Class, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ObjectTypes), ObjectTypes.Input, ObjectTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.RecordPrimaryCtorOutputNoAtt, CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.ClassOutputNoAtt, CSharpObjectType.Class, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ArrayTypes), ArrayTypes.Input, ArrayTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ArrayRoot), ArrayRoot.Input, ArrayRoot.RecordPrimaryCtorOutputNoAtt, CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(ArrayRoot), ArrayRoot.Input, ArrayRoot.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(ArrayRoot), ArrayRoot.Input, ArrayRoot.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ArrayRoot), ArrayRoot.Input, ArrayRoot.ClassOutputNoAtt, CSharpObjectType.Class, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(ArrayRoot), ArrayRoot.Input, ArrayRoot.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(ArrayRoot), ArrayRoot.Input, ArrayRoot.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.RecordPrimaryCtorOutputNoAtt, CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.ClassOutputNoAtt, CSharpObjectType.Class, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(WeirdNameTypes), WeirdNameTypes.Input, WeirdNameTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData("EmptyObject", "{}", "", CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData("EmptyObject", "{}", "", CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData("EmptyObject", "{}", "", CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData("EmptyObject", "{}", "", CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData("EmptyObject", "{}", "", CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    internal void OutputTest(string className, string input, string expectedOutput, CSharpObjectType targetType, CSharpSerializationAttribute serializationAttribute)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.CSharp,
            CSharpOptions = new()
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
    
    [Theory]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.RecordPrimaryCtorOutputNoAtt, CSharpObjectType.Record, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.RecordPrimaryCtorOutput, CSharpObjectType.Record, CSharpSerializationAttribute.NewtonsoftJson)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.RecordOutput, CSharpObjectType.Record, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.ClassOutputNoAtt, CSharpObjectType.Class, CSharpSerializationAttribute.NoAttribute)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.ClassOutput, CSharpObjectType.Class, CSharpSerializationAttribute.SystemTextJson)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.StructOutput, CSharpObjectType.Struct, CSharpSerializationAttribute.SystemTextJson)]
    internal void TypeHandleOutputTest(string className, string input, string expectedOutput, CSharpObjectType targetType, CSharpSerializationAttribute serializationAttribute)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.CSharp,
            
            CSharpOptions = new()
            {
                TargetType = targetType,
                SerializationAttribute = serializationAttribute,
                TypeNameHandler = propertyType => propertyType + "Ayy"
            }
        };
        
        var actualOutput = Json2Sharp.Parse(className, input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }
    

    [Theory]
    [InlineData(ArrayRoot.BadInput1)]
    [InlineData(ArrayRoot.BadInput2)]
    [InlineData(ArrayRoot.BadInput3)]
    [InlineData(ArrayRoot.BadInput4)]
    internal void FailTest(string input)
        => Assert.Throws<InvalidOperationException>(() => Json2Sharp.Parse("Root", input));
}