using Json2SharpLib.Common;
using System.Diagnostics.CodeAnalysis;

namespace Json2SharpApp.Handlers;

internal static class InputHandler
{
    public static bool? Handle(FileInfo? fileInfo, out string result)
    {
        var objectName = fileInfo?.Name.Replace(".json", string.Empty) ?? "MyType";
        var rawJson = TryGetPipedData(out var pipedData)
            ? pipedData
            : (fileInfo is null)
                ? null
                : File.ReadAllText(fileInfo.FullName);

        // If no data was provided, abort.
        if (rawJson is null)
        {
            result = string.Empty;
            return null;
        }

        return TryParseJson(objectName, rawJson, out result);
    }


    private static bool TryParseJson(string objectName, string rawJson, out string typeDefinitionOrExceptionMessage)
    {
        try
        {
            typeDefinitionOrExceptionMessage = Json2Sharp.Parse(objectName, rawJson);
            return true;
        }
        catch (Exception ex)
        {
            typeDefinitionOrExceptionMessage = ex.Message;
            return false;
        }
    }

    private static bool TryGetPipedData([MaybeNullWhen(false)] out string pipedData)
    {
        if (Console.IsInputRedirected)
        {
            pipedData = Console.In.ReadToEnd();
            return true;
        }

        pipedData = default;
        return false;
    }
}