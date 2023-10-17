using Json2SharpApp.Handlers;
using Json2SharpLib.Enums;
using System.CommandLine;

namespace Json2SharpApp;

internal sealed class Program
{
    private async static Task<int> Main(string[] args)
    {
        var inputOption = new Option<FileInfo?>(new[] { "--input", "-i" }, "The relative path to the JSON file in the file system.");
        var outputOption = new Option<string?>(new[] { "--output", "-o" }, "The relative path to the resulting file in the file system.");
        var configOption = new Option<string?>(new[] { "--config", "-c" }, "The conversion options.");
        var rootCommand = new RootCommand("Convert a JSON object to a language type declaration.")
        {
            inputOption,
            outputOption,
            configOption
        };

        rootCommand.SetHandler(async (inputFile, outputPath, configOptions) =>
        {
            var options = ConfigHandler.Handle(configOptions?.Split(' ', StringSplitOptions.TrimEntries));
            var inputSuccessful = InputHandler.Handle(inputFile, options, out var typeDefinition);

            if (inputSuccessful is not null)
            {
                if (!await OutputHandler.HandleAsync(outputPath, typeDefinition, !inputSuccessful.Value, Language.CSharp))
                    await OutputHandler.StderrWriteAsync("No permission to write on output folder.", ConsoleColor.Red);
            }
            else
            {
                await OutputHandler.StderrWriteAsync("Error: no input was provided." + Environment.NewLine, ConsoleColor.Red);
                await rootCommand.InvokeAsync("--help");
            }
        }, inputOption, outputOption, configOption);

        return await rootCommand.InvokeAsync(args);
    }
}