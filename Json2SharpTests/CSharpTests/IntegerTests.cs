using Json2SharpTests.CSharpTests.Models.Answers;
using Json2SharpLib.Enums;
using Json2SharpLib.Common;
using Json2SharpLib.Models;

namespace Json2SharpTests.CSharpTests;

public sealed class IntegerTests
{
    [Theory]
    [InlineData(IntegerTypes.Input, IntegerTypes.RecordOutput, CSharpObjectType.Record)]
    [InlineData(IntegerTypes.Input, IntegerTypes.ClassOutput, CSharpObjectType.Class)]
    internal void IntegerTest(string input, string expectedOutput, CSharpObjectType targetType)
    {
        var options = new Json2SharpOptions() { CSharp = new() { TargetType = targetType } };
        var actualOutput = Json2Sharp.Parse(nameof(IntegerTypes), input, options);

        Assert.Equal(expectedOutput.Replace("\r", string.Empty), actualOutput.Replace("\r", string.Empty));
    }
}