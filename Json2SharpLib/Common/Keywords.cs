using System.Collections.Frozen;
namespace Json2SharpLib.Common;

/// <summary>
/// Defines keywords for multiple programming languages.
/// </summary>
internal static class Keywords
{
    /// <summary>
    /// The collection of C# keywords.
    /// </summary>
    public static FrozenSet<string> CSharp { get; } = new[]
    {
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const",
        "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit",
        "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in",
        "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator",
        "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte",
        "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw",
        "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void",
        "volatile", "while", "add", "alias", "ascending", "async", "await", "by", "descending", "dynamic",
        "equals", "from", "get", "global", "group", "into", "join", "let", "managed", "nameof", "on",
        "orderby", "partial", "remove", "select", "set", "unmanaged", "value", "var", "when", "where", "yield"
    }.ToFrozenSet();

    /// <summary>
    /// The collection of Python keywords.
    /// </summary>
    public static FrozenSet<string> Python { get; } = new[]
    {
        "False", "None", "True", "and", "as", "assert", "async", "await", "break", "class", "continue", "def", "del",
        "elif", "else", "except", "finally", "for", "from", "global", "if", "import", "in", "is", "lambda", "nonlocal",
        "not", "or", "pass", "raise", "return", "try", "while", "with", "yield"
    }.ToFrozenSet();

    /// <summary>
    /// The collection of Java keywords.
    /// </summary>
    public static FrozenSet<string> Java { get; } = new[]
    {
        "abstract", "assert", "boolean", "break", "byte", "case", "catch", "char", "class", "const", "continue",
        "default", "do", "double", "else", "enum", "extends", "final", "finally", "float", "for", "goto",
        "if", "implements", "import", "instanceof", "int", "interface", "long", "native", "new", "package",
        "private", "protected", "public", "return", "short", "static", "strictfp", "super", "switch",
        "synchronized", "this", "throw", "throws", "transient", "try", "void", "volatile", "while",
        "true", "false", "null"
    }.ToFrozenSet();

    /// <summary>
    /// The collection of Kotlin keywords.
    /// </summary>
    public static FrozenSet<string> Kotlin { get; } = new[]
    {
        "as", "as?", "break", "class", "continue", "do", "else", "false", "for", "fun", "if", "in", "!in", "interface",
        "is", "!is", "null", "object", "package", "return", "super", "this", "throw", "true", "try", "typealias", "val",
        "var", "when", "while", "by", "constructor", "delegate", "dynamic", "field", "file", "get", "init", "import",
        "it", "operator", "property", "receiver", "set", "setparam", "where", "actual", "abstract", "annotation",
        "companion", "crossinline", "data", "enum", "expect", "external", "final", "infix", "inline", "inner",
        "internal", "lateinit", "noinline", "open", "out", "override", "private", "protected", "public",
        "reified", "sealed", "suspend", "tailrec", "vararg"
    }.ToFrozenSet();
}
