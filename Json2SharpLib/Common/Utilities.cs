using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Json2SharpLib.Common;

internal static class Utilities
{
    private static readonly IReadOnlyDictionary<Type, string> _aliasTypes = new Dictionary<Type, string>()
    {
        [typeof(string)] = "string",
        [typeof(int)] = "int",
        [typeof(byte)] = "byte",
        [typeof(sbyte)] = "sbyte",
        [typeof(short)] = "short",
        [typeof(ushort)] = "ushort",
        [typeof(long)] = "long",
        [typeof(uint)] = "uint",
        [typeof(ulong)] = "ulong",
        [typeof(float)] = "float",
        [typeof(double)] = "double",
        [typeof(decimal)] = "decimal",
        [typeof(object)] = "object",
        [typeof(bool)] = "bool",
        [typeof(char)] = "char",

        [typeof(string[])] = "string[]",
        [typeof(int[])] = "int[]",
        [typeof(byte[])] = "byte[]",
        [typeof(sbyte[])] = "sbyte[]",
        [typeof(short[])] = "short[]",
        [typeof(ushort[])] = "ushort[]",
        [typeof(long[])] = "long[]",
        [typeof(uint[])] = "uint[]",
        [typeof(ulong[])] = "ulong[]",
        [typeof(float[])] = "float[]",
        [typeof(double[])] = "double[]",
        [typeof(decimal[])] = "decimal[]",
        [typeof(object[])] = "object[]",
        [typeof(bool[])] = "bool[]",
        [typeof(char[])] = "char[]",

        [typeof(string?[])] = "string?[]",
        [typeof(int?[])] = "int?[]",
        [typeof(byte?[])] = "byte?[]",
        [typeof(sbyte?[])] = "sbyte?[]",
        [typeof(short?[])] = "short?[]",
        [typeof(ushort?[])] = "ushort?[]",
        [typeof(long?[])] = "long?[]",
        [typeof(uint?[])] = "uint?[]",
        [typeof(ulong?[])] = "ulong?[]",
        [typeof(float?[])] = "float?[]",
        [typeof(double?[])] = "double?[]",
        [typeof(decimal?[])] = "decimal?[]",
        [typeof(object?[])] = "object?[]",
        [typeof(bool?[])] = "bool?[]",
        [typeof(char?[])] = "char?[]",
    };

    public static string ToPascalCase(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        var stringBuilder = new StringBuilder(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text))
            .Replace("_", string.Empty);

        var result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }

    public static bool TryGetAliasName(Type type, [MaybeNullWhen(false)] out string aliasName)
    {
        if (_aliasTypes.TryGetValue(type, out aliasName))
            return true;

        aliasName = default;
        return false;
    }
}