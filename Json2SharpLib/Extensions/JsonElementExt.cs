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
        else if (jsonElement.TryGetUInt32(out _))
            return typeof(uint);
        else if (jsonElement.TryGetInt64(out _))
            return typeof(long);
        else if (jsonElement.TryGetUInt64(out _))
            return typeof(ulong);
        else if (jsonElement.TryGetSingle(out var floatValue) && !float.IsInfinity(floatValue) && !HasDecimalPrecisionOver(jsonElement, 7))
            return typeof(float);
        else if (jsonElement.TryGetDouble(out _) && !HasDecimalPrecisionOver(jsonElement, 16))
            return typeof(double);
        else if (jsonElement.TryGetDecimal(out _))
            return typeof(decimal);
        else
            throw new ArgumentException("Value is not a valid number type.", nameof(jsonElement));
    }

    private static bool HasDecimalPrecisionOver(JsonElement jsonElement, int decimalPrecision)
    {
        var value = jsonElement.ToString().AsSpan();
        var endIndex = value.IndexOf('E');

        if (endIndex is -1)
            endIndex = value.Length - 1;

        return value[(value.IndexOf('.') + 1)..endIndex].Length > decimalPrecision;
    }
}