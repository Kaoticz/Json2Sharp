using System.Text.Json;

namespace Json2SharpLib.Models;

public sealed record JsonClassProperty
{
    public string? JsonName { get; }
    public string? FinalName { get; }
    public JsonElement JsonElement { get; }
    public Type BclType { get; }
    public IReadOnlyList<JsonClassProperty> Children { get; }

    internal JsonClassProperty(string? jsonName, string? finalName, JsonElement jsonElement, Type bclType, IReadOnlyList<JsonClassProperty> children)
    {
        JsonName = jsonName;
        FinalName = finalName;
        JsonElement = jsonElement;
        BclType = bclType;
        Children = children;
    }
}
