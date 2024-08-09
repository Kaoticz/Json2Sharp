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
    public static StringBuilder AppendIndentedLine(this StringBuilder stringBuilder, string text, string indentationPadding, int indentationLevel)
    {
        for (var amount = 0; amount < indentationLevel; amount++)
            stringBuilder.Append(indentationPadding);

        return stringBuilder.AppendLine(text);
    }
}