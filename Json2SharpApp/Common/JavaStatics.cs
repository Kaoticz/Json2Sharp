using Json2SharpLib.Enums;
using System.Collections.Frozen;

namespace Json2SharpApp.Common;

/// <summary>
/// Contains <see langword="static"/> data related to Java serialization.
/// </summary>
internal static class JavaStatics
{
    /// <summary>
    /// Defines CLI options for serialization annotations.
    /// </summary>
    public static FrozenDictionary<string, JavaSerializationAnnotation> SerializationAnnotations { get; } = new Dictionary<string, JavaSerializationAnnotation>()
    {
        ["jackson"] = JavaSerializationAnnotation.Jackson,
        ["gson"] = JavaSerializationAnnotation.Gson,
        ["moshi"] = JavaSerializationAnnotation.Moshi,
        ["noann"] = JavaSerializationAnnotation.NoAnnotation,
        ["noannotation"] = JavaSerializationAnnotation.NoAnnotation,
    }.ToFrozenDictionary();

    /// <summary>
    /// Defines CLI options for nullability annotations.
    /// </summary>
    public static FrozenDictionary<string, JavaNullabilityAnnotation> NullabilityAnnotations { get; } = new Dictionary<string, JavaNullabilityAnnotation>()
    {
        ["jakarta"] = JavaNullabilityAnnotation.Jakarta,
        ["jspecify"] = JavaNullabilityAnnotation.JSpecify,
        ["jetbrains"] = JavaNullabilityAnnotation.JetBrains,
        ["lombok"] = JavaNullabilityAnnotation.Lombok,
        ["findbugs"] = JavaNullabilityAnnotation.FindBugs,
        ["nonull"] = JavaNullabilityAnnotation.NoAnnotation,
        ["nonullability"] = JavaNullabilityAnnotation.NoAnnotation,
    }.ToFrozenDictionary();
}