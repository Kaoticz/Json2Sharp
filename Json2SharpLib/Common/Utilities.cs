using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Json2SharpLib.Common;

/// <summary>
/// Utility methods.
/// </summary>
internal static class Utilities
{
    /// <summary>
    /// Maps CLR types to their corresponding language aliases.
    /// </summary>
    private static readonly IReadOnlyDictionary<Type, string> _csharpAliasTypes = new Dictionary<Type, string>()
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
        [typeof(bool?[])] = "bool?[]",
        [typeof(char?[])] = "char?[]",
    };

    /// <summary>
    /// Converts a string to the PascalCase format.
    /// </summary>
    /// <param name="text">The string to be converted.</param>
    /// <returns>The <paramref name="text"/> in PascalCase format.</returns>
    internal static string ToPascalCase(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        var stringBuilder = new StringBuilder(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(text))
            .Replace("_", string.Empty);

        var result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }

    /// <summary>
    /// Attempts to get the alias for the given <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type to get the alias name from.</param>
    /// <param name="aliasName">The alias name of <paramref name="type"/>.</param>
    /// <returns><see langword="true"/> if the alias was successfully found, <see langword="false"/> otherwise.</returns>
    internal static bool TryGetAliasName(Type type, [MaybeNullWhen(false)] out string aliasName)
    {
        if (_csharpAliasTypes.TryGetValue(type, out aliasName))
            return true;

        aliasName = default;
        return false;
    }
}