using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Json2SharpLib.Extensions;

internal static class StringExt
{
    /// <summary>
    /// Converts a string to the PascalCase format.
    /// </summary>
    /// <param name="text">The string to be converted.</param>
    /// <returns>The <paramref name="text"/> in PascalCase format.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    internal static string? ToPascalCase(this string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        var textSpan = text.AsSpan();
        var result = new StringBuilder();
        var isNewWord = true;

        for (var index = 0; index < textSpan.Length; index++)
        {
            var currentChar = textSpan[index];

            if (!char.IsLetterOrDigit(currentChar))
            {
                isNewWord = true;
                continue;
            }

            if (isNewWord)
            {
                result.Append(char.ToUpperInvariant(currentChar));
                isNewWord = false;
            }
            else
            {
                result.Append(
                    (index < text.Length - 1 && char.IsUpper(currentChar) && char.IsLower(text[index + 1]))
                        ? currentChar
                        : char.ToLowerInvariant(currentChar)
                );
            }

            isNewWord &= index < text.Length - 1 && char.IsLower(text[index]) && char.IsUpper(text[index + 1]);
        }

        return result.ToStringAndClear();
    }

    /// <summary>
    /// Converts a string to the "snake_case" format.
    /// </summary>
    /// <param name="text">This string.</param>
    /// <returns>This <see cref="string"/> converted to snake_case.</returns>
    [return: NotNullIfNotNull(nameof(text))]
    public static string? ToSnakeCase(this string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        var textSpan = text.AsSpan();
        var buffer = new StringBuilder();

        for (var index = 0; index < textSpan.Length; index++)
        {
            var chainLength = UpperChainLength(textSpan, index);

            if (chainLength <= 0)
            {
                buffer.Append(
                    (char.IsLetterOrDigit(textSpan[index]))
                        ? char.ToLowerInvariant(textSpan[index])
                        : '_'
                );

                continue;
            }

            buffer.Append('_');

            foreach (var upperLetter in textSpan.Slice(index, chainLength))
                buffer.Append(char.ToLowerInvariant(upperLetter));

            index += chainLength - 1;
        }

        buffer.Trim('_')
            .Replace(" _", " ")
            .Replace("_ ", "_")
            .Replace(' ', '_');

        buffer.ReplaceAll("__", "_");

        return buffer.ToStringAndClear();
    }

    /// <summary>
    /// Returns the length of an "ALL CAPS" substring in the specified span.
    /// </summary>
    /// <param name="text">The span to check.</param>
    /// <param name="startIndex">The index where the substring starts.</param>
    /// <returns>The length of the substring.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Occurs when <paramref name="startIndex"/> is greater than the length of the span.</exception>
    private static int UpperChainLength(ReadOnlySpan<char> text, int startIndex)
    {
        if (startIndex > text.Length - 1)
            throw new ArgumentOutOfRangeException(nameof(startIndex), startIndex, "Start index cannot be greater than length of the span.");
        else if (text.Length is 0)
            return 0;
        else if (startIndex < 0)
            startIndex = 0;

        var result = 0;

        for (var count = startIndex; count < text.Length; count++)
        {
            if (!char.IsLetter(text[count]) || char.IsLower(text[count]))
                break;

            result++;
        }

        return result;
    }
}