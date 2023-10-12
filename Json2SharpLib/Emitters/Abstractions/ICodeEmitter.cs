using System.Text.Json;

namespace Json2SharpLib.Emitters.Abstractions;

public interface ICodeEmitter
{
    string Parse(string objectName, JsonElement jsonElement);
}