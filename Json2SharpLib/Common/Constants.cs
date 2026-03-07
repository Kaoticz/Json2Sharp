using System.Collections.Frozen;
namespace Json2SharpLib.Common;

/// <summary>
/// Defines constants for the library.
/// </summary>
internal static class Constants
{
    /// <summary>
    /// C# using for System Text Json.
    /// </summary>
    public const string StjUsing = "using System.Text.Json.Serialization;";

    /// <summary>
    /// C# using for Newtonsoft Json.
    /// </summary>
    public const string NewtonsoftUsing = "using Newtonsoft.Json;";

    /// <summary>
    /// The collection of C# keywords.
    /// </summary>
    public static FrozenSet<string> CSharpKeywords { get; } = new[]
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
    public static FrozenSet<string> PythonKeywords { get; } = new[]
    {
        "False", "None", "True", "and", "as", "assert", "async", "await", "break", "class", "continue", "def", "del",
        "elif", "else", "except", "finally", "for", "from", "global", "if", "import", "in", "is", "lambda", "nonlocal",
        "not", "or", "pass", "raise", "return", "try", "while", "with", "yield"
    }.ToFrozenSet();

    /// <summary>
    /// The collection of Java keywords.
    /// </summary>
    public static FrozenSet<string> JavaKeywords { get; } = new[]
    {
        "abstract", "assert", "boolean", "break", "byte", "case", "catch", "char", "class", "const", "continue",
        "default", "do", "double", "else", "enum", "extends", "final", "finally", "float", "for", "goto",
        "if", "implements", "import", "instanceof", "int", "interface", "long", "native", "new", "package",
        "private", "protected", "public", "return", "short", "static", "strictfp", "super", "switch",
        "synchronized", "this", "throw", "throws", "transient", "try", "void", "volatile", "while",
        "true", "false", "null"
    }.ToFrozenSet();
}
