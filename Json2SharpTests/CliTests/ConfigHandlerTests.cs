using Json2SharpApp.Handlers;
using Json2SharpLib.Enums;

namespace Json2SharpTests.CliTests;

public sealed class ConfigHandlerTests
{
    [Fact]
    public void DefaultOptions()
    {
        var result = ConfigHandler.Handle([], out var options, out var exception);

        Assert.True(result);
        Assert.Null(exception);
        Assert.NotNull(options);
        Assert.Equal(Language.CSharp, options.TargetLanguage);
        Assert.Equal(CSharpObjectType.Record, options.CSharpOptions.TargetType);
        Assert.Equal(4, options.CSharpOptions.IndentationCharacterAmount);
        Assert.Equal(IndentationCharacterType.Space, options.CSharpOptions.IndentationPaddingCharacter);
    }

    [Theory]
    [InlineData("py", Language.Python)]
    [InlineData("python", Language.Python)]
    [InlineData("java", Language.Java)]
    [InlineData("kt", Language.Kotlin)]
    [InlineData("kotlin", Language.Kotlin)]
    public void LanguageParsing(string langArg, Language expectedLanguage)
    {
        var result = ConfigHandler.Handle([langArg], out var options, out _);

        Assert.True(result);
        Assert.NotNull(options);
        Assert.Equal(expectedLanguage, options.TargetLanguage);
    }

    [Theory]
    [InlineData("class", CSharpObjectType.Class)]
    [InlineData("struct", CSharpObjectType.Struct)]
    [InlineData("record", CSharpObjectType.Record)]
    public void CSharpObjectTypeParsing(string typeArg, CSharpObjectType expectedType)
    {
        var result = ConfigHandler.Handle([typeArg], out var options, out _);

        Assert.True(result);
        Assert.NotNull(options);
        Assert.Equal(expectedType, options.CSharpOptions.TargetType);
    }

    [Theory]
    [InlineData("ind:2", 2)]
    [InlineData("ind:8", 8)]
    public void IndentationAmountParsing(string indArg, int expectedAmount)
    {
        var result = ConfigHandler.Handle([indArg], out var options, out _);

        Assert.True(result);
        Assert.NotNull(options);
        Assert.Equal(expectedAmount, options.CSharpOptions.IndentationCharacterAmount);
    }

    [Fact]
    public void TabIndentationParsing()
    {
        var result = ConfigHandler.Handle(["tab"], out var options, out _);

        Assert.True(result);
        Assert.NotNull(options);
        Assert.Equal(IndentationCharacterType.Tab, options.CSharpOptions.IndentationPaddingCharacter);
    }

    [Theory]
    [InlineData("py pyd", PythonObjectType.Pydantic)]
    [InlineData("py class", PythonObjectType.Class)]
    [InlineData("py", PythonObjectType.DataClass)]
    public void PythonObjectTypeParsing(string args, PythonObjectType expectedType)
    {
        var result = ConfigHandler.Handle(args.Split(' '), out var options, out _);

        Assert.True(result);
        Assert.NotNull(options);
        Assert.Equal(expectedType, options.PythonOptions.TargetType);
    }

    [Theory]
    [InlineData("java class", false)]
    [InlineData("java", true)]
    public void JavaUseRecordParsing(string args, bool expectedUseRecord)
    {
        var result = ConfigHandler.Handle(args.Split(' '), out var options, out _);

        Assert.True(result);
        Assert.NotNull(options);
        Assert.Equal(expectedUseRecord, options.JavaOptions.UseRecord);
    }
}
