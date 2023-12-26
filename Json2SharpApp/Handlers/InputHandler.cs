using Json2SharpLib;
using Json2SharpLib.Models;
using System.Diagnostics.CodeAnalysis;

namespace Json2SharpApp.Handlers;

/// <summary>
/// Contains methods to handle conversion of JSON data into a language type declaration.
/// </summary>
internal static class InputHandler
{
    /// <summary>
    /// Converts JSON data into a language type definition specified by <paramref name="options"/>.
    /// </summary>
    /// <param name="fileInfo">The file that contains the JSON data or <see langword="null"/> if data is being piped instead.</param>
    /// <param name="objectName">The name of the root object.</param>
    /// <param name="jsonString">The raw JSON data or <see langword="null"/> if it was not provided.</param>
    /// <param name="options">The parsing options.</param>
    /// <param name="result">
    /// The language type definition if <see langword="true"/>,
    /// an error message if <see langword="false"/>,
    /// or an empty string if <see langword="null"/>.
    /// </param>
    /// <remarks>Piped data takes precedence over input data.</remarks>
    /// <returns>
    /// <see langword="true"/> if the JSON data was converted successfully,
    /// <see langword="false"/> if conversion failed and
    /// <see langword="null"/> if there was no JSON data to be converted.
    /// </returns>
    public static bool? Handle(FileInfo? fileInfo, string objectName, string? jsonString, Json2SharpOptions options, out string result)
    {
        var rawJson = (TryGetPipedData(out var pipedData)) ? pipedData
            : (!string.IsNullOrWhiteSpace(jsonString)) ? jsonString
            : (fileInfo is null) ? null
            : File.ReadAllText(fileInfo.FullName);

        // If no data was provided, abort.
        if (rawJson is null)
        {
            result = string.Empty;
            return null;
        }

        return TryParseJson(objectName, rawJson, options, out result);
    }

    /// <summary>
    /// Safely converts JSON data into a language type declaration.
    /// </summary>
    /// <param name="objectName">The name of the type.</param>
    /// <param name="rawJson">The JSON data.</param>
    /// <param name="options">The parsing options.</param>
    /// <param name="typeDeclarationOrExceptionMessage">The type declaration if <see langword="true"/> or an error message if <see langword="false"/>.</param>
    /// <returns><see langword="true"/> if the conversion was successful, <see langword="false"/> otherwise.</returns>
    private static bool TryParseJson(string objectName, string rawJson, Json2SharpOptions options, out string typeDeclarationOrExceptionMessage)
    {
        try
        {
            typeDeclarationOrExceptionMessage = Json2Sharp.Parse(objectName, rawJson, options);
            return true;
        }
        catch (Exception ex)
        {
            typeDeclarationOrExceptionMessage = ex.Message;
            return false;
        }
    }

    /// <summary>
    /// Safely gets piped data, if available.
    /// </summary>
    /// <param name="pipedData">The piped data or <see langword="null"/> if not available.</param>
    /// <returns><see langword="true"/> if piped data was available, <see langword="false"/> otherwise.</returns>
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