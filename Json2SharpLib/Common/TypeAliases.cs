using System.Collections.Frozen;

namespace Json2SharpLib.Common;

/// <summary>
/// Contains type aliases for multiple programming languages.
/// </summary>
internal static class TypeAliases
{
    /// <summary>
    /// Maps C# CLR types to their corresponding C# aliases.
    /// </summary>
    internal static FrozenDictionary<Type, string> CSharpAliasTypes { get; } = new Dictionary<Type, string>()
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
    }.ToFrozenDictionary();

    /// <summary>
    /// Maps C# CLR types to their corresponding Python aliases.
    /// </summary>
    internal static FrozenDictionary<Type, string> PythonAliasTypes { get; } = new Dictionary<Type, string>()
    {
        [typeof(string)] = "str",
        [typeof(int)] = "int",
        [typeof(byte)] = "bytes",
        [typeof(sbyte)] = "bytes",
        [typeof(short)] = "int",
        [typeof(ushort)] = "int",
        [typeof(long)] = "int",
        [typeof(uint)] = "int",
        [typeof(ulong)] = "int",
        [typeof(float)] = "float",
        [typeof(double)] = "float",
        [typeof(decimal)] = "float",
        [typeof(object)] = "Any",
        [typeof(bool)] = "bool",
        [typeof(char)] = "str",

        [typeof(string[])] = "List[str]",
        [typeof(int[])] = "List[int]",
        [typeof(byte[])] = "bytes",
        [typeof(sbyte[])] = "bytes",
        [typeof(short[])] = "List[int]",
        [typeof(ushort[])] = "List[int]",
        [typeof(long[])] = "List[int]",
        [typeof(uint[])] = "List[int]",
        [typeof(ulong[])] = "List[int]",
        [typeof(float[])] = "List[float]",
        [typeof(double[])] = "List[float]",
        [typeof(decimal[])] = "List[float]",
        [typeof(object[])] = "List[Any]",
        [typeof(bool[])] = "List[bool]",
        [typeof(char[])] = "List[str]",

        [typeof(int?[])] = "Optional[List[int]]",
        [typeof(byte?[])] = "Optional[bytes]",
        [typeof(sbyte?[])] = "Optional[bytes]",
        [typeof(short?[])] = "Optional[List[int]]",
        [typeof(ushort?[])] = "Optional[List[int]]",
        [typeof(long?[])] = "Optional[List[int]]",
        [typeof(uint?[])] = "Optional[List[int]]",
        [typeof(ulong?[])] = "Optional[List[int]]",
        [typeof(float?[])] = "Optional[List[float]]",
        [typeof(double?[])] = "Optional[List[float]]",
        [typeof(decimal?[])] = "Optional[List[float]]",
        [typeof(bool?[])] = "Optional[List[bool]]",
        [typeof(char?[])] = "Optional[List[str]]",
    }.ToFrozenDictionary();
}