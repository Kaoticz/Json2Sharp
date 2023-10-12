using Json2SharpLib.Enums;
using System.Diagnostics;

namespace Json2SharpLib.Extensions;

internal static class CSharpAccessibilityTypeExt
{
    internal static string ToCode(this CSharpAccessibilityLevel accessibilityLevel)
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