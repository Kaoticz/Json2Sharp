using Json2SharpLib.Enums;

namespace Json2SharpLib.Models;

public sealed record Json2SharpOptions
{
    public Language TargetLanguage { get; set; } = Language.CSharp;
    public Json2SharpCSharpOptions CSharp { get; init; } = new();
}