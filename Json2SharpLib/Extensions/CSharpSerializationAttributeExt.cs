using Json2SharpLib.Enums;

namespace Json2SharpLib.Extensions;

internal static class CSharpSerializationAttributeExt
{
    public static string ToCode(this CSharpSerializationAttribute serializationAttribute)
    {
        return serializationAttribute switch
        {
            CSharpSerializationAttribute.SystemTextJson => "JsonPropertyName",
            CSharpSerializationAttribute.NewtonsoftJson => "JsonProperty",
            _ => throw new NotImplementedException(),
        };
    }
}