using System.Text.Json;

namespace Json2SharpLib.Extensions;

/// <summary>
/// Defines extension methods for <see cref="JsonElement"/>.
/// </summary>
internal static class JsonElementExt
{
    /// <summary>
    /// Gets the C# BCL type that represents the value stored in this <paramref name="jsonElement"/>.
    /// </summary>
    /// <param name="jsonElement">This JSON element.</param>
    /// <returns>The BCL type that represents this <paramref name="jsonElement"/>.</returns>
    public static Type ToBclType(this JsonElement jsonElement)
    {
        return jsonElement.ValueKind switch
        {
            JsonValueKind.Object => typeof(object),
            JsonValueKind.True or JsonValueKind.False => typeof(bool),
            JsonValueKind.Array => GetArrayType(jsonElement),
            JsonValueKind.String => GetTextType(jsonElement),
            JsonValueKind.Number => GetNumberType(jsonElement),
            _ => typeof(object)
        };
    }

    /// <summary>
    /// Gets the C# BCL array type that represents the specified <paramref name="jsonElement"/>.
    /// </summary>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <returns>The BCL type that represents the <paramref name="jsonElement"/>.</returns>
    private static Type GetArrayType(JsonElement jsonElement)
    {
        var types = jsonElement.EnumerateArray()
            .Select(ToBclType)
            .Distinct()
            .ToArray();

        return (types.Length is not 1)
            ? typeof(object[])
            : types[0].MakeArrayType();
    }

    /// <summary>
    /// Gets the C# BCL text type that represents the specified <paramref name="jsonElement"/>.
    /// </summary>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <returns>The BCL type that represents the <paramref name="jsonElement"/>.</returns>
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

    /// <summary>
    /// Gets the C# BCL number type that represents the specified <paramref name="jsonElement"/>.
    /// </summary>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <returns>The BCL type that represents the <paramref name="jsonElement"/>.</returns>
    /// <exception cref="ArgumentException">Occurs when <paramref name="jsonElement"/> is not a number type.</exception>
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

    /// <summary>
    /// Determines whether the specified <paramref name="jsonElement"/> has a decimal precision over <paramref name="decimalPrecision"/>.
    /// </summary>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <param name="decimalPrecision">The amount of decimal digits the value must at least have.</param>
    /// <returns><see langword="true"/> if the value has over the specified amount of decimal digits, <see langword="false"/> otherwise.</returns>
    private static bool HasDecimalPrecisionOver(JsonElement jsonElement, int decimalPrecision)
    {
        var value = jsonElement.ToString().AsSpan();
        var endIndex = value.IndexOf('E');

        if (endIndex is -1)
            endIndex = value.Length - 1;

        return value[(value.IndexOf('.') + 1)..endIndex].Length > decimalPrecision;
    }
}