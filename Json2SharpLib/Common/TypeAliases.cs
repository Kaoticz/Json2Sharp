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
    public static FrozenDictionary<Type, string> CSharpAliasTypes { get; } = new Dictionary<Type, string>()
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
        [typeof(DateTime)] = nameof(DateTime),
        [typeof(TimeSpan)] = nameof(TimeSpan),
        [typeof(DateTimeOffset)] = nameof(DateTimeOffset),
        [typeof(Guid)] = nameof(Guid),

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
        [typeof(DateTime[])] = nameof(DateTime) + "[]",
        [typeof(TimeSpan[])] = nameof(TimeSpan) + "[]",
        [typeof(DateTimeOffset[])] = nameof(DateTimeOffset) + "[]",
        [typeof(Guid[])] = nameof(Guid) + "[]",

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
        [typeof(DateTime?[])] = nameof(DateTime) + "?[]",
        [typeof(TimeSpan?[])] = nameof(TimeSpan) + "?[]",
        [typeof(DateTimeOffset?[])] = nameof(DateTimeOffset) + "?[]",
        [typeof(Guid?[])] = nameof(Guid) + "?[]",
    }.ToFrozenDictionary();

    /// <summary>
    /// Maps C# CLR types to their corresponding Python aliases.
    /// </summary>
    public static FrozenDictionary<Type, string> PythonAliasTypes { get; } = new Dictionary<Type, string>()
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
        [typeof(object)] = "object",
        [typeof(bool)] = "bool",
        [typeof(char)] = "str",
        [typeof(Guid)] = "UUID",
        [typeof(TimeSpan)] = "timedelta",
        [typeof(DateTime)] = "datetime",
        [typeof(DateTimeOffset)] = "datetime",

        [typeof(string[])] = "list[str]",
        [typeof(int[])] = "list[int]",
        [typeof(byte[])] = "bytes",
        [typeof(sbyte[])] = "bytes",
        [typeof(short[])] = "list[int]",
        [typeof(ushort[])] = "list[int]",
        [typeof(long[])] = "list[int]",
        [typeof(uint[])] = "list[int]",
        [typeof(ulong[])] = "list[int]",
        [typeof(float[])] = "list[float]",
        [typeof(double[])] = "list[float]",
        [typeof(decimal[])] = "list[float]",
        [typeof(object[])] = "list[object]",
        [typeof(bool[])] = "list[bool]",
        [typeof(char[])] = "list[str]",
        [typeof(Guid[])] = "list[UUID]",
        [typeof(TimeSpan[])] = "list[timedelta]",
        [typeof(DateTime[])] = "list[datetime]",
        [typeof(DateTimeOffset[])] = "list[datetime]",

        [typeof(int?[])] = "Optional[list[int]]",
        [typeof(byte?[])] = "Optional[bytes]",
        [typeof(sbyte?[])] = "Optional[bytes]",
        [typeof(short?[])] = "Optional[list[int]]",
        [typeof(ushort?[])] = "Optional[list[int]]",
        [typeof(long?[])] = "Optional[list[int]]",
        [typeof(uint?[])] = "Optional[list[int]]",
        [typeof(ulong?[])] = "Optional[list[int]]",
        [typeof(float?[])] = "Optional[list[float]]",
        [typeof(double?[])] = "Optional[list[float]]",
        [typeof(decimal?[])] = "Optional[list[float]]",
        [typeof(bool?[])] = "Optional[list[bool]]",
        [typeof(char?[])] = "Optional[list[str]]",
        [typeof(Guid?[])] = "Optional[list[UUID]]",
        [typeof(TimeSpan?[])] = "Optional[list[timedelta]]",
        [typeof(DateTime?[])] = "Optional[list[datetime]]",
        [typeof(DateTimeOffset?[])] = "Optional[list[datetime]]",
    }.ToFrozenDictionary();
}