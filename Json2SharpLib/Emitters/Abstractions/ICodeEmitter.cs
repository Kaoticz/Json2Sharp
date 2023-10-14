using System.Text.Json;

namespace Json2SharpLib.Emitters.Abstractions;

/// <summary>
/// Represents an object that converts JSON data into a language type definition.
/// </summary>
public interface ICodeEmitter
{
    /// <summary>
    /// Parse JSON data into a type definition.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="jsonElement">The JSON element to be processed.</param>
    /// <returns>The type definition.</returns>
    string Parse(string objectName, JsonElement jsonElement);
}