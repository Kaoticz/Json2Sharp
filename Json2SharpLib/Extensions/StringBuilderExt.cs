using System.Runtime.CompilerServices;
using System.Text;

namespace Json2SharpLib.Extensions;

/// <summary>
/// Defines extension methods for <see cref="StringBuilder"/>.
/// </summary>
internal static class StringBuilderExt
{
    /// <summary>
    /// Replaces, within a substring of this instance, all occurrences of <paramref name="oldText"/> with <paramref name="newText"/>,
    /// even if <paramref name="newText"/> is a substring of <paramref name="oldText"/>.
    /// </summary>
    /// <param name="stringBuilder">This string builder.</param>
    /// <param name="oldText">The string to replace.</param>
    /// <param name="newText">The string that replaces <paramref name="oldText"/>.</param>
    /// <returns>A reference to this instance with all instances of <paramref name="oldText"/> replaced by <paramref name="newText"/>.</returns>
    /// <exception cref="ArgumentException">
    /// Occurs when <paramref name="newText"/> is longer than <paramref name="oldText"/> and contains parts of <paramref name="oldText"/>.
    /// </exception>
    public static StringBuilder ReplaceAll(this StringBuilder stringBuilder, string oldText, string newText)
        => stringBuilder.ReplaceAll(oldText, newText, 0, stringBuilder.Length);

    /// <summary>
    /// Replaces, within a substring of this instance, all occurrences of <paramref name="oldText"/> with <paramref name="newText"/>,
    /// even if <paramref name="newText"/> is a substring of <paramref name="oldText"/>.
    /// </summary>
    /// <param name="stringBuilder">This string builder.</param>
    /// <param name="oldText">The string to replace.</param>
    /// <param name="newText">The string that replaces <paramref name="oldText"/>.</param>
    /// <param name="startIndex">The position in this instance where the <paramref name="oldText"/> begins.</param>
    /// <param name="count">The length of the substring.</param>
    /// <returns>
    /// A reference to this instance with all instances of <paramref name="oldText"/> replaced by <paramref name="newText"/> in the
    /// range from <paramref name="startIndex"/> to <paramref name="startIndex"/> + <paramref name="count"/> - 1.
    /// </returns>
    /// <exception cref="ArgumentException">
    /// Occurs when <paramref name="newText"/> is longer than <paramref name="oldText"/> and contains parts of <paramref name="oldText"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">Occurs when <paramref name="count"/> is equal or less than 0.</exception>
    public static StringBuilder ReplaceAll(this StringBuilder stringBuilder, string oldText, string newText, int startIndex, int count)
    {
        if (newText.Length > oldText.Length && newText.Contains(oldText))
            throw new ArgumentException($"{nameof(newText)} must not contain {nameof(oldText)} while having greater length than {nameof(oldText)}.", nameof(newText));
        else if (stringBuilder.Length is 0)
            return stringBuilder;

        int length;

        do
        {
            length = stringBuilder.Length;
            stringBuilder.Replace(oldText, newText, startIndex, Math.Min(count, length - startIndex));
        } while (length != stringBuilder.Length);

        return stringBuilder;
    }

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
    /// Checks if the specified <paramref name="text"/> is present in this string builder.
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
    /// Removes all leading and trailing instances of a character from the current string builder.
    /// </summary>
    /// <param name="stringBuilder">This string builder.</param>
    /// <param name="trimChar">A Unicode character to remove.</param>
    /// <returns>This string builder with all leading and trailing instances of <paramref name="trimChar"/> removed.</returns>
    internal static StringBuilder Trim(this StringBuilder stringBuilder, char trimChar = ' ')
        => stringBuilder.TrimStart(trimChar).TrimEnd(trimChar);

    /// <summary>
    /// Removes all leading instances of a character from the current string builder.
    /// </summary>
    /// <param name="stringBuilder">This string builder.</param>
    /// <param name="trimChar">A Unicode character to remove.</param>
    /// <returns>This string builder with all leading instances of <paramref name="trimChar"/> removed.</returns>
    internal static StringBuilder TrimStart(this StringBuilder stringBuilder, char trimChar = ' ')
    {
        if (stringBuilder.Length is 0)
            return stringBuilder;

        while (stringBuilder.Length is not 0 && stringBuilder[0] == trimChar)
            stringBuilder.Remove(0, 1);

        return stringBuilder;
    }

    /// <summary>
    /// Removes all trailing instances of a character from the current string builder.
    /// </summary>
    /// <param name="stringBuilder">This string builder.</param>
    /// <param name="trimChar">A Unicode character to remove.</param>
    /// <returns>This string builder with all trailing instances of <paramref name="trimChar"/> removed.</returns>
    internal static StringBuilder TrimEnd(this StringBuilder stringBuilder, char trimChar = ' ')
    {
        if (stringBuilder.Length is 0)
            return stringBuilder;

        while (stringBuilder.Length is not 0 && stringBuilder[^1] == trimChar)
            stringBuilder.Remove(stringBuilder.Length - 1, 1);

        return stringBuilder;
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