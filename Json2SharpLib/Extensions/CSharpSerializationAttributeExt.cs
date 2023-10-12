using Json2SharpLib.Enums;
using System.Diagnostics;

namespace Json2SharpLib.Extensions;

internal static class CSharpSerializationAttributeExt
{
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