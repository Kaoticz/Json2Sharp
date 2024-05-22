using Json2SharpLib.Enums;
using System.Diagnostics;

namespace Json2SharpLib.Extensions;

/// <summary>
/// Defines extension methods for <see cref="CSharpAccessibilityLevel"/>.
/// </summary>
internal static class CSharpAccessibilityTypeExt
{
    /// <summary>
    /// Gets the code representation of an accessibility level.
    /// </summary>
    /// <param name="accessibilityLevel">This accessibility level.</param>
    /// <returns>The accessibility level as valid C# code.</returns>
    /// <exception cref="UnreachableException">Occurs when an accessibility level is not implemented.</exception>
    public static string ToCode(this CSharpAccessibilityLevel accessibilityLevel)
    {
        return accessibilityLevel switch
        {
            CSharpAccessibilityLevel.Public => "public",
            CSharpAccessibilityLevel.Protected => "protected",
            CSharpAccessibilityLevel.Internal => "internal",
            CSharpAccessibilityLevel.ProtectedInternal => "protected internal",
            CSharpAccessibilityLevel.Private => "private",
            CSharpAccessibilityLevel.PrivateProtected => "private protected",
            _ => throw new UnreachableException($"Accessibility level {accessibilityLevel} is not implemented."),
        };
    }
}