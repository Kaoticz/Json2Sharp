using Json2SharpApp.Extensions;
using Json2SharpLib.Enums;

namespace Json2SharpApp.Handlers;

internal sealed class OutputHandler
{
    public static async Task<bool> HandleAsync(string? destinationPath, string output, bool isError, Language language)
    {
        if (string.IsNullOrWhiteSpace(destinationPath))
        {
            var printTask = (isError)
                ? StderrWriteAsync(output, ConsoleColor.Red)
                : Console.Out.WriteLineAsync(output);

            await printTask;
            return true;
        }

        var fileExtension = language.GetLanguageFileExtension();

        if (!destinationPath.EndsWith(fileExtension, StringComparison.Ordinal))
            destinationPath += fileExtension;

        return await CreateFileAsync(destinationPath, output);
    }

    public static async Task StderrWriteAsync(string errorMessage, ConsoleColor foregroundColor)
    {
        var originalColor = Console.ForegroundColor;

        Console.ForegroundColor = foregroundColor;
        await Console.Error.WriteLineAsync(errorMessage);
        Console.ForegroundColor = originalColor;
    }

    private static async Task<bool> CreateFileAsync(string destinationPath, string content)
    {
        var absolutePath = Path.GetFullPath(destinationPath);
        var parentFolder = Path.GetDirectoryName(absolutePath) ?? Directory.GetDirectoryRoot(Path.DirectorySeparatorChar.ToString());
        
        Directory.CreateDirectory(parentFolder);

        if (!CanWriteTo(parentFolder))
            return false;

        await File.WriteAllTextAsync(absolutePath, content);

        return true;
    }

    /// <summary>
    /// Safely deletes a file.
    /// </summary>
    /// <param name="fileUri">The absolute path to the file.</param>
    /// <returns><see langword="true"/> if the file was deleted, <see langword="false"/> otherwise.</returns>
    /// <exception cref="ArgumentException" />
    /// <exception cref="ArgumentNullException" />
    /// <exception cref="IOException" />
    /// <exception cref="NotSupportedException" />
    /// <exception cref="PathTooLongException" />
    /// <exception cref="UnauthorizedAccessException" />
    private static bool TryDeleteFile(string fileUri)
    {
        ArgumentException.ThrowIfNullOrEmpty(fileUri, nameof(fileUri));

        if (!File.Exists(fileUri))
            return false;

        File.Delete(fileUri);
        return true;
    }

    /// <summary>
    /// Checks if this application can write to <paramref name="directoryUri"/>.
    /// </summary>
    /// <param name="directoryUri">The absolute path to a directory.</param>
    /// <returns><see langword="true"/> if writing is allowed, <see langword="false"/> otherwise.</returns>
    /// <exception cref="PathTooLongException" />
    /// <exception cref="DirectoryNotFoundException" />
    private static bool CanWriteTo(string directoryUri)
    {
        var tempFileUri = Path.Combine(directoryUri, $"{Guid.NewGuid()}.tmp");

        try
        {
            using var fileStream = File.Create(tempFileUri);
            return true;
        }
        catch (UnauthorizedAccessException)
        {
            return false;
        }
        finally
        {
            TryDeleteFile(tempFileUri);
        }
    }
}