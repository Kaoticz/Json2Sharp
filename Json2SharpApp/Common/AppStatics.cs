using Json2SharpLib.Enums;
using System.Collections.Frozen;

namespace Json2SharpApp.Common;

/// <summary>
/// Contains <see langword="static"/> data related to C# serialization. 
/// </summary>
internal static class CSharpStatics
{
    /// <summary>
    /// Defines CLI options for object types.
    /// </summary>
    public static FrozenDictionary<string, CSharpObjectType> ObjectTypes { get; } = new Dictionary<string, CSharpObjectType>()
    {
        ["record"] = CSharpObjectType.Record,
        ["class"] = CSharpObjectType.Class,
        ["struct"] = CSharpObjectType.Struct
    }.ToFrozenDictionary();

    /// <summary>
    /// Defines CLI options for accessibility levels.
    /// </summary>
    public static FrozenDictionary<string, CSharpAccessibilityLevel> AccessibilityLevels { get; } = new Dictionary<string, CSharpAccessibilityLevel>()
    {
        ["public"] = CSharpAccessibilityLevel.Public,
        ["internal"] = CSharpAccessibilityLevel.Internal,
        ["protected"] = CSharpAccessibilityLevel.Protected,
        ["protectedinternal"] = CSharpAccessibilityLevel.ProtectedInternal,
        ["privateprotected"] = CSharpAccessibilityLevel.PrivateProtected,
        ["private"] = CSharpAccessibilityLevel.Private
    }.ToFrozenDictionary();

    /// <summary>
    /// Defines CLI options for serialization attributes.
    /// </summary>
    public static FrozenDictionary<string, CSharpSerializationAttribute> SerializationAttributes { get; } = new Dictionary<string, CSharpSerializationAttribute>()
    {
        ["stj"] = CSharpSerializationAttribute.SystemTextJson,
        ["systemtextjson"] = CSharpSerializationAttribute.SystemTextJson,
        ["noatt"] = CSharpSerializationAttribute.NoAttribute,
        ["noattribute"] = CSharpSerializationAttribute.NoAttribute,
        ["ntj"] = CSharpSerializationAttribute.NewtonsoftJson,
        ["newtonsoft"] = CSharpSerializationAttribute.NewtonsoftJson,
        ["newtonsoftjson"] = CSharpSerializationAttribute.NewtonsoftJson,
    }.ToFrozenDictionary();
}