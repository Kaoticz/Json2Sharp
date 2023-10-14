using Json2SharpLib.Enums;
using System.Diagnostics;

namespace Json2SharpLib.Extensions;

/// <summary>
/// Defines extension methods for <see cref="CSharpSerializationAttribute"/>.
/// </summary>
internal static class CSharpSerializationAttributeExt
{
    /// <summary>
    /// Gets the code representation of a library serialization attribute.
    /// </summary>
    /// <param name="serializationAttribute">The serialization library.</param>
    /// <returns>The serialization attribute's name.</returns>
    /// <exception cref="UnreachableException">Occurs when a serialization library is not implemented.</exception>
    internal static string ToCode(this CSharpSerializationAttribute serializationAttribute)
    {
        return serializationAttribute switch
        {
            CSharpSerializationAttribute.SystemTextJson => "JsonPropertyName",
            CSharpSerializationAttribute.NewtonsoftJson => "JsonProperty",
            _ => throw new UnreachableException($"Serialization attribute of type {serializationAttribute} is not implemented."),
        };
    }
}