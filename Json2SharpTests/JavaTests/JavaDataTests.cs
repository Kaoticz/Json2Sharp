using Json2SharpLib;
using Json2SharpLib.Enums;
using Json2SharpLib.Extensions;
using Json2SharpLib.Models;
using Json2SharpTests.JavaTests.Models.Answers;
using Kotz.Extensions;

namespace Json2SharpTests.JavaTests;

public sealed class JavaDataTests
{
    [Theory]
    [InlineData(KeywordTypes.Input, KeywordTypes.Output, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(KeywordTypes.Input, KeywordTypes.RecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    internal void KeywordTest(string input, string expectedOutput, bool useRecord, JavaSerializationAnnotation serializationAnnotation, JavaNullabilityAnnotation nullabilityAnnotation)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Java,
            JavaOptions = new()
            {
                UseRecord = useRecord,
                SerializationAnnotation = serializationAnnotation,
                NullabilityAnnotation = nullabilityAnnotation
            }
        };

        var actualOutput = Json2Sharp.Parse("KeywordTypes", input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }

    [Theory]
    // Integer Types
    [InlineData(IntegerTypes.Input, IntegerTypes.NoAnnotationOutput, false, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonJakartaOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonJSpecifyOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonJetBrainsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonLombokOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonFindBugsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiJakartaOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiJSpecifyOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiJetBrainsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiLombokOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiFindBugsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(IntegerTypes.Input, IntegerTypes.NoAnnotationRecordOutput, true, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(IntegerTypes.Input, IntegerTypes.JacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonJakartaRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonLombokRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(IntegerTypes.Input, IntegerTypes.GsonFindBugsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiJakartaRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiJSpecifyRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiJetBrainsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiLombokRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(IntegerTypes.Input, IntegerTypes.MoshiFindBugsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    
    // Bool Types
    [InlineData(BoolTypes.Input, BoolTypes.NoAnnotationOutput, false, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonJakartaOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonJSpecifyOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonJetBrainsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonLombokOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonFindBugsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiJakartaOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiJSpecifyOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiJetBrainsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiLombokOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiFindBugsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(BoolTypes.Input, BoolTypes.NoAnnotationRecordOutput, true, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(BoolTypes.Input, BoolTypes.JacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonJakartaRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonLombokRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(BoolTypes.Input, BoolTypes.GsonFindBugsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiJakartaRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiJSpecifyRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiJetBrainsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiLombokRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(BoolTypes.Input, BoolTypes.MoshiFindBugsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]

    // Float Types
    [InlineData(FloatTypes.Input, FloatTypes.NoAnnotationOutput, false, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonJakartaOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonJSpecifyOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonJetBrainsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonLombokOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonFindBugsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiJakartaOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiJSpecifyOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiJetBrainsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiLombokOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiFindBugsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(FloatTypes.Input, FloatTypes.NoAnnotationRecordOutput, true, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(FloatTypes.Input, FloatTypes.JacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonJakartaRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonLombokRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(FloatTypes.Input, FloatTypes.GsonFindBugsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiJakartaRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiJSpecifyRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiJetBrainsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiLombokRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(FloatTypes.Input, FloatTypes.MoshiFindBugsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]

    // Text Types
    [InlineData(TextTypes.Input, TextTypes.NoAnnotationOutput, false, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(TextTypes.Input, TextTypes.JacksonOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(TextTypes.Input, TextTypes.JacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(TextTypes.Input, TextTypes.JacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(TextTypes.Input, TextTypes.JacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(TextTypes.Input, TextTypes.JacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(TextTypes.Input, TextTypes.JacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(TextTypes.Input, TextTypes.GsonOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(TextTypes.Input, TextTypes.GsonJakartaOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(TextTypes.Input, TextTypes.GsonJSpecifyOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(TextTypes.Input, TextTypes.GsonJetBrainsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(TextTypes.Input, TextTypes.GsonLombokOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(TextTypes.Input, TextTypes.GsonFindBugsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(TextTypes.Input, TextTypes.MoshiOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(TextTypes.Input, TextTypes.MoshiJakartaOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(TextTypes.Input, TextTypes.MoshiJSpecifyOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(TextTypes.Input, TextTypes.MoshiJetBrainsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(TextTypes.Input, TextTypes.MoshiLombokOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(TextTypes.Input, TextTypes.MoshiFindBugsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(TextTypes.Input, TextTypes.NoAnnotationRecordOutput, true, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(TextTypes.Input, TextTypes.JacksonRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(TextTypes.Input, TextTypes.JacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(TextTypes.Input, TextTypes.JacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(TextTypes.Input, TextTypes.JacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(TextTypes.Input, TextTypes.JacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(TextTypes.Input, TextTypes.JacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(TextTypes.Input, TextTypes.GsonRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(TextTypes.Input, TextTypes.GsonJakartaRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(TextTypes.Input, TextTypes.GsonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(TextTypes.Input, TextTypes.GsonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(TextTypes.Input, TextTypes.GsonLombokRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(TextTypes.Input, TextTypes.GsonFindBugsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(TextTypes.Input, TextTypes.MoshiRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(TextTypes.Input, TextTypes.MoshiJakartaRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(TextTypes.Input, TextTypes.MoshiJSpecifyRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(TextTypes.Input, TextTypes.MoshiJetBrainsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(TextTypes.Input, TextTypes.MoshiLombokRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(TextTypes.Input, TextTypes.MoshiFindBugsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]

    // Array Root
    [InlineData(ArrayRoot.Input, ArrayRoot.NoAnnotationOutput, false, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonJakartaOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonJSpecifyOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonJetBrainsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonLombokOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonFindBugsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiJakartaOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiJSpecifyOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiJetBrainsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiLombokOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiFindBugsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayRoot.Input, ArrayRoot.NoAnnotationRecordOutput, true, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayRoot.Input, ArrayRoot.JacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonJakartaRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonLombokRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayRoot.Input, ArrayRoot.GsonFindBugsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiJakartaRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiJSpecifyRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiJetBrainsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiLombokRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayRoot.Input, ArrayRoot.MoshiFindBugsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]

    // Object Types
    [InlineData(ObjectTypes.Input, ObjectTypes.NoAnnotationOutput, false, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonJakartaOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonJSpecifyOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonJetBrainsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonLombokOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonFindBugsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiJakartaOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiJSpecifyOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiJetBrainsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiLombokOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiFindBugsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ObjectTypes.Input, ObjectTypes.NoAnnotationRecordOutput, true, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ObjectTypes.Input, ObjectTypes.JacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonJakartaRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonLombokRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ObjectTypes.Input, ObjectTypes.GsonFindBugsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiJakartaRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiJSpecifyRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiJetBrainsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiLombokRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ObjectTypes.Input, ObjectTypes.MoshiFindBugsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]

    // Array Types
    [InlineData(ArrayTypes.Input, ArrayTypes.NoAnnotationOutput, false, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonJakartaOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonJSpecifyOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonJetBrainsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonLombokOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonFindBugsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiJakartaOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiJSpecifyOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiJetBrainsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiLombokOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiFindBugsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayTypes.Input, ArrayTypes.NoAnnotationRecordOutput, true, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayTypes.Input, ArrayTypes.JacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonJakartaRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonLombokRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayTypes.Input, ArrayTypes.GsonFindBugsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiJakartaRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiJSpecifyRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiJetBrainsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiLombokRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(ArrayTypes.Input, ArrayTypes.MoshiFindBugsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]

    // Weird Name Types
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.NoAnnotationOutput, false, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonJakartaOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonJSpecifyOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonJetBrainsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonLombokOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonFindBugsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiJakartaOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiJSpecifyOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiJetBrainsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiLombokOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiFindBugsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.NoAnnotationRecordOutput, true, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.JacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonJakartaRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonLombokRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.GsonFindBugsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiJakartaRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiJSpecifyRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiJetBrainsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiLombokRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(WeirdNameTypes.Input, WeirdNameTypes.MoshiFindBugsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]

    // Nullability Import Types
    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]

    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(NullabilityImportTypes.NonNullableOnlyInput, NullabilityImportTypes.NonNullableOnlyJacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(NullabilityImportTypes.NullableOnlyInput, NullabilityImportTypes.NullableOnlyJacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]

    internal void OutputTest(string input, string expectedOutput, bool useRecord, JavaSerializationAnnotation serializationAnnotation, JavaNullabilityAnnotation nullabilityAnnotation)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Java,
            JavaOptions = new()
            {
                UseRecord = useRecord,
                SerializationAnnotation = serializationAnnotation,
                NullabilityAnnotation = nullabilityAnnotation
            }
        };

        var actualOutput = Json2Sharp.Parse("Root", input, options);

        Assert.Equal(
            expectedOutput.Replace("\r", string.Empty),
            actualOutput.Replace("\r", string.Empty)
        );
    }

    [Theory]
    // Custom Handle Types
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.NoAnnotationOutput, false, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonJakartaOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonJSpecifyOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonJetBrainsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonLombokOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonFindBugsOutput, false, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonJakartaOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonJSpecifyOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonJetBrainsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonLombokOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonFindBugsOutput, false, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiJakartaOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiJSpecifyOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiJetBrainsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiLombokOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiFindBugsOutput, false, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.NoAnnotationRecordOutput, true, JavaSerializationAnnotation.NoAnnotation, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonJakartaRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonLombokRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.JacksonFindBugsRecordOutput, true, JavaSerializationAnnotation.Jackson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonJakartaRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonJSpecifyRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonJetBrainsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonLombokRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.Lombok)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.GsonFindBugsRecordOutput, true, JavaSerializationAnnotation.Gson, JavaNullabilityAnnotation.FindBugs)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.NoAnnotation)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiJakartaRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Jakarta)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiJSpecifyRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JSpecify)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiJetBrainsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.JetBrains)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiLombokRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.Lombok)]
    [InlineData(nameof(CustomHandleTypes), CustomHandleTypes.Input, CustomHandleTypes.MoshiFindBugsRecordOutput, true, JavaSerializationAnnotation.Moshi, JavaNullabilityAnnotation.FindBugs)]
    internal void TypeHandleOutputTest(string className, string input, string expectedOutput, bool useRecord, JavaSerializationAnnotation serializationAnnotation, JavaNullabilityAnnotation nullabilityAnnotation)
    {
        var options = new Json2SharpOptions()
        {
            TargetLanguage = Language.Java,
            JavaOptions = new()
            {
                UseRecord = useRecord,
                SerializationAnnotation = serializationAnnotation,
                NullabilityAnnotation = nullabilityAnnotation,
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