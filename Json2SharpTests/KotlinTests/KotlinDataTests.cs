using Json2SharpLib;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using Json2SharpTests.KotlinTests.Models.Answers;
using Kotz.Extensions;

namespace Json2SharpTests.KotlinTests;

public sealed class KotlinDataTests
{
    [Theory]
    // Integer Types
    [InlineData(IntegerTypes.Input, IntegerTypes.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(IntegerTypes.Input, IntegerTypes.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    // Bool Types
    [InlineData(BoolTypes.Input, BoolTypes.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(BoolTypes.Input, BoolTypes.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    // Float Types
    [InlineData(FloatTypes.Input, FloatTypes.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(FloatTypes.Input, FloatTypes.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    // Text Types
    [InlineData(TextTypes.Input, TextTypes.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(TextTypes.Input, TextTypes.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(TextTypes.Input, TextTypes.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(TextTypes.Input, TextTypes.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(TextTypes.Input, TextTypes.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    // Array Root
    [InlineData(ArrayRoot.Input, ArrayRoot.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(ArrayRoot.Input, ArrayRoot.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    // Object Types
    [InlineData(ObjectTypes.Input, ObjectTypes.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(ObjectTypes.Input, ObjectTypes.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    // Array Types
    [InlineData(ArrayTypes.Input, ArrayTypes.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(ArrayTypes.Input, ArrayTypes.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    // Weird Name Types
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    // Keyword Types
    [InlineData(KeywordTypes.Input, KeywordTypes.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(KeywordTypes.Input, KeywordTypes.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(KeywordTypes.Input, KeywordTypes.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(KeywordTypes.Input, KeywordTypes.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(KeywordTypes.Input, KeywordTypes.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    internal void OutputTest(string input, string expectedOutput, KotlinSerializationAnnotation serializationAnnotation)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Kotlin,
            KotlinOptions = new()
            {
                SerializationAnnotation = serializationAnnotation
            }
        };

        var actualOutput = Json2Sharp.Parse("Root", input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty).Trim(),
            actualOutput.Replace("\r", string.Empty).Trim()
        );
    }

    [Theory]
    // Custom Handle Types
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.NoAnnotationOutput, KotlinSerializationAnnotation.NoAnnotation)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.KotlinxOutput, KotlinSerializationAnnotation.Kotlinx)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonOutput, KotlinSerializationAnnotation.Jackson)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonOutput, KotlinSerializationAnnotation.Gson)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiOutput, KotlinSerializationAnnotation.Moshi)]
    internal void TypeHandleOutputTest(string className, string input, string expectedOutput, KotlinSerializationAnnotation serializationAnnotation)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Kotlin,
            KotlinOptions = new()
            {
                SerializationAnnotation = serializationAnnotation,
                TypeNameHandler = propertyType => propertyType.ToSnakeCase()
            }
        };

        var actualOutput = Json2Sharp.Parse(className.ToSnakeCase(), input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty).Trim(),
            actualOutput.Replace("\r", string.Empty).Trim()
        );
    }
}
