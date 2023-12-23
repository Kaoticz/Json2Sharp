using System.Runtime.CompilerServices;
using System.Text;

namespace Json2SharpLib.Extensions;

/// <summary>
/// Defines extension methods for <see cref="StringBuilder"/>.
/// </summary>
internal static class StringBuilderExt
{
    /// <summary>
    /// Appends <paramref name="text"/> with the specified <paramref name="indentationPadding"/>
    /// and <paramref name="indentationLevel"/>.
    /// </summary>
    /// <param name="stringBuilder">This string builder.</param>
    /// <param name="text">The text to be appended.</param>
    /// <param name="indentationPadding">The text to be prepended to <paramref name="text"/>.</param>
    /// <param name="indentationLevel">How many times <paramref name="indentationPadding"/> should be prepended.</param>
    /// <returns>This <see cref="StringBuilder"/>.</returns>
    internal static StringBuilder AppendIndentedLine(this StringBuilder stringBuilder, string text, string indentationPadding, int indentationLevel)
    {
        for (var amount = 0; amount < indentationLevel; amount++)
            stringBuilder.Append(indentationPadding);

        return stringBuilder.AppendLine(text);
    }

    /// <summary>
    /// Checks if <paramref name="text"/> is present in this string builder.
    /// </summary>
    /// <param name="stringBuilder">This string builder.</param>
    /// <param name="text">The text to check for.</param>
    /// <returns><see langword="true"/> if <paramref name="text"/> is present, <see langword="false"/> otherwise.</returns>
    internal static bool Contains(this StringBuilder stringBuilder, ReadOnlySpan<char> text)
    {
        var textIndex = 0;

        foreach (var chunk in stringBuilder.GetChunks())
        {
            for (var chunkIndex = 0; chunkIndex < chunk.Span.Length; chunkIndex++)
            {
                textIndex = (chunk.Span[chunkIndex] == text[textIndex])
                    ? textIndex + 1
                    : 0;

                if (textIndex == text.Length)
                    return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Converts the value of this instance to a <see langword="string"/>, then clears its buffer.
    /// </summary>
    /// <param name="stringBuilder">This builder.</param>
    /// <returns>A string whose value is the same as this instance.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static string ToStringAndClear(this StringBuilder stringBuilder)
    {
        var result = stringBuilder.ToString();
        stringBuilder.Clear();

        return result;
    }
}