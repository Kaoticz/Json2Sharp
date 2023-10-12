using Json2SharpLib.Enums;

namespace Json2SharpLib.Models;

public sealed class Json2SharpCSharpOptions
{
    public CSharpObjectType TargetType { get; init; } = CSharpObjectType.Record;
    public CSharpAccessibilityLevel AccessibilityLevel { get; init; } = CSharpAccessibilityLevel.Public;
    public CSharpSerializationAttribute SerializationAttribute { get; init; } = CSharpSerializationAttribute.SystemTextJson;
    public bool IsSealed { get; init; } = true;
    public string IndentationPadding { get; init; } = "    ";
}