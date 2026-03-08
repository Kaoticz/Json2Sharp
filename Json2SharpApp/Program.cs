using Json2SharpApp.Enums;
using Json2SharpApp.Handlers;
using System.CommandLine;

namespace Json2SharpApp;

/// <summary>
/// Entry point class.
/// </summary>
internal sealed class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    /// <param name="args">CLI arguments.</param>
    /// <returns>Exit code.</returns>
    private static async Task<int> Main(string[] args)
    {
        var inputOption = new Option<FileInfo?>("--input", "-i") { Description = "The relative path to the JSON file in the file system." };
        var outputOption = new Option<string?>("--output", "-o") { Description = "The relative path to the resulting file in the file system." };
        var nameOption = new Option<string?>("--name", "-n") { Description = "The name of the root object." };
        var jsonOption = new Option<string?>("--json", "-j") { Description = "The JSON object to convert." };
        var configOption = new Option<string?>("--config", "-c") { Description = "The conversion options." };
        var rootCommand = new RootCommand("Convert a JSON object to a language type definition.")
        {
            inputOption,
            outputOption,
            nameOption,
            jsonOption,
            configOption
        };

        rootCommand.SetAction(async (parseResult, cancellationToken) =>
        {
            var inputFile = parseResult.GetValue(inputOption);
            var outputPath = parseResult.GetValue(outputOption);
            var name = parseResult.GetValue(nameOption);
            var json = parseResult.GetValue(jsonOption);
            var config = parseResult.GetValue(configOption);
            await RootHandlerAsync(rootCommand, inputFile, outputPath, name, json, config);
        });

        return await rootCommand.Parse(args).InvokeAsync();
    }

    /// <summary>
    /// Handles invocation of the root command.
    /// </summary>
    /// <param name="rootCommand">The root command.</param>
    /// <param name="inputFile">The file that contains the JSON data or <see langword="null"/> if data is being piped.</param>
    /// <param name="outputPath">
    /// The path where the file should be created or <see langword="null"/>
    /// if the output should be printed to stdout.
    /// </param>
    /// <param name="rootObjectName">The name of the root object or <see langword="null"/> if it was not provided.</param>
    /// <param name="jsonString">The raw JSON data or <see langword="null"/> if it was not provided.</param>
    /// <param name="configOptions">The command-line configuration options.</param>
    private static async Task RootHandlerAsync(RootCommand rootCommand, FileInfo? inputFile, string? outputPath, string? rootObjectName, string? jsonString, string? configOptions)
    {
        rootObjectName ??= Path.GetFileNameWithoutExtension(outputPath ?? inputFile?.Name) ?? "Root";
        var rawOptions = configOptions?.ToLowerInvariant().Split(' ', StringSplitOptions.TrimEntries) ?? [];

        if (!ConfigHandler.Handle(rawOptions, out var options, out var optionsException))
        {
            await OutputHandler.StderrWriteAsync(optionsException.Message, ConsoleColor.Red);
            Environment.Exit((int)ExitCode.OptionError);
        }

        var inputSuccessful = InputHandler.Handle(inputFile, rootObjectName, jsonString, options, out var typeDefinition);

        if (inputSuccessful is not null)
        {
            if (!await OutputHandler.HandleAsync(outputPath, typeDefinition, !inputSuccessful.Value, options.TargetLanguage))
            {
                await OutputHandler.StderrWriteAsync("No permission to write to output directory.", ConsoleColor.Red);
                Environment.Exit((int)ExitCode.NoWritePermission);
            }
        }
        else
        {
            await OutputHandler.StderrWriteAsync("Error: no valid input was provided." + Environment.NewLine, ConsoleColor.Red);
            await rootCommand.Parse("--help").InvokeAsync();
            Environment.Exit((int)ExitCode.InvalidInput);
        }
    }
}