using System.Text.Json;

namespace Json2SharpLib.Extensions;

internal static class JsonElementExt
{
    public static Type ToBclType(this JsonElement jsonElement)
    {
        return jsonElement.ValueKind switch
        {
            JsonValueKind.Object => typeof(object),
            JsonValueKind.Array => GetArrayType(jsonElement),
            JsonValueKind.String => GetTextType(jsonElement),
            JsonValueKind.Number => GetNumberType(jsonElement),
            JsonValueKind.True or JsonValueKind.False => typeof(bool),
            _ => typeof(object)
        };
    }

    private static Type GetArrayType(JsonElement jsonElement)
    {
        var types = jsonElement.EnumerateArray()
            .Select(ToBclType)
            .Distinct()
            .ToArray();

        return types.Length is not 1
            ? typeof(object[])
            : types[0].MakeArrayType();
    }

    private static Type GetTextType(JsonElement jsonElement)
    {
        if (jsonElement.TryGetGuid(out _))
            return typeof(Guid);
        else if (jsonElement.TryGetDateTime(out _))
            return typeof(DateTime);
        else if (jsonElement.TryGetDateTimeOffset(out _))
            return typeof(DateTimeOffset);
        else
            return typeof(string);
    }

    private static Type GetNumberType(JsonElement jsonElement)
    {
        if (jsonElement.TryGetInt32(out _))
            return typeof(int);
        else if (jsonElement.TryGetInt64(out _))
            return typeof(long);
        else if (jsonElement.TryGetSingle(out _))
            return typeof(float);
        else if (jsonElement.TryGetDouble(out _))
            return typeof(double);
        else if (jsonElement.TryGetUInt32(out _))
            return typeof(uint);
        else if (jsonElement.TryGetUInt32(out _))
            return typeof(ulong);
        else if (jsonElement.TryGetDecimal(out _))
            return typeof(decimal);
        else
            throw new ArgumentException("Value is not a valid number type.", nameof(jsonElement));
    }
}