namespace Json2SharpLib.Enums;

/// <summary>
/// Represents the libraries whose serialization attributes are necessary
/// for the correct de/serialization of JSON objects.
/// </summary>
public enum CSharpSerializationAttribute : byte
{
    /// <summary>
    /// No serialization attribute.
    /// </summary>
    NoAttribute,

    /// <summary>
    /// System.Text.Json - JsonPropertyName
    /// </summary>
    SystemTextJson,

    /// <summary>
    /// Newtonsoft.Json - JsonProperty
    /// </summary>
    NewtonsoftJson
}