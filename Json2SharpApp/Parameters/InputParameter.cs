using Json2SharpApp.Parameters.Abstractions;
using Json2SharpLib.Common;
using System.CommandLine;
using System.Diagnostics.CodeAnalysis;

namespace Json2SharpApp.Parameters;

internal sealed class InputParameter : IParameter
{
    private readonly string[] _aliases = new[] { "--input", "-i" };
    public string Description { get; } = "The relative path to the JSON file in the file system.";
    public IReadOnlyList<string> Aliases
        => _aliases;

    public void AddParameter(Command cliCommand)
    {
        var option = new Option<FileInfo?>(_aliases, Description);

        cliCommand.AddOption(option);
        cliCommand.SetHandler(fileInfo =>
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
                StderrWrite("Error: no input was provided." + Environment.NewLine, ConsoleColor.Red);
                cliCommand.Invoke("--help");

                return;
            }

            // If conversion is successful, print to stdout.
            // If conversion is not successful, print to stderr.
            if (TryParseJson(objectName, rawJson, out var result))
                Console.Out.WriteLine(result);
            else
                StderrWrite(result, ConsoleColor.Red);

        }, option);
    }

    private void StderrWrite(string errorMessage, ConsoleColor foregroundColor)
    {
        var originalColor = Console.ForegroundColor;

        Console.ForegroundColor = foregroundColor;
        Console.Error.WriteLine(errorMessage);
        Console.ForegroundColor = originalColor;
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