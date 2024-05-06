using System.Text.Json;

namespace Json2SharpLib.Models;

/// <summary>
/// Represents a JSON property that has been processed.
/// </summary>
public sealed record ParsedJsonProperty
{
    /// <summary>
    /// The original name of the JSON property or
    /// <see langword="null"/> if this is a root array element.
    /// </summary>
    public string? JsonName { get; }

    /// <summary>
    /// The JSON element.
    /// </summary>
    public JsonElement JsonElement { get; }

    /// <summary>
    /// The C# BLC type that represents this JSON property.
    /// </summary>
    public Type BclType { get; }

    /// <summary>
    /// The children properties of this property or
    /// an empty collection if there aren't any.
    /// </summary>
    public IReadOnlyList<ParsedJsonProperty> Children { get; }

    /// <summary>
    /// Creates a JSON property that has been processed.
    /// </summary>
    /// <param name="jsonName">
    /// The original name of the JSON property or
    /// <see langword="null"/> if this is an array element.
    /// </param>
    /// <param name="jsonElement">The JSON element.</param>
    /// <param name="bclType">The C# BLC type that represents this JSON property.</param>
    /// <param name="children">
    /// The children properties of this property or
    /// an empty collection if there aren't any.
    /// </param>
    internal ParsedJsonProperty(string? jsonName, JsonElement jsonElement, Type bclType, IReadOnlyList<ParsedJsonProperty> children)
    {
        JsonName = jsonName;
        JsonElement = jsonElement;
        BclType = bclType;
        Children = children;
    }
}