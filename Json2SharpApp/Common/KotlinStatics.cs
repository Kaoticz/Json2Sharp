using Json2SharpLib.Enums;
using System.Collections.Frozen;

namespace Json2SharpApp.Common;

/// <summary>
/// Contains <see langword="static"/> data related to Kotlin serialization.
/// </summary>
internal static class KotlinStatics
{
    /// <summary>
    /// Defines CLI options for serialization annotations.
    /// </summary>
    public static FrozenDictionary<string, KotlinSerializationAnnotation> SerializationAnnotations { get; } = new Dictionary<string, KotlinSerializationAnnotation>()
    {
        ["kotlinx"] = KotlinSerializationAnnotation.Kotlinx,
        ["jackson"] = KotlinSerializationAnnotation.Jackson,
        ["gson"] = KotlinSerializationAnnotation.Gson,
        ["moshi"] = KotlinSerializationAnnotation.Moshi,
        ["noann"] = KotlinSerializationAnnotation.NoAnnotation,
        ["noannotation"] = KotlinSerializationAnnotation.NoAnnotation,
    }.ToFrozenDictionary();
}
