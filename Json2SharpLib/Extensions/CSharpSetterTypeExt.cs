using Json2SharpLib.Enums;
using System.Diagnostics;

namespace Json2SharpLib.Extensions;

/// <summary>
/// Defines extension methods for <see cref="CSharpSetterType"/>.
/// </summary>
internal static class CSharpSetterTypeExt
{
    /// <summary>
    /// Gets the code representation of a property setter.
    /// </summary>
    /// <param name="setterType">This setter type.</param>
    /// <returns>The property setter as valid C# code.</returns>
    /// <exception cref="UnreachableException">Occurs when a property setter is not implemented.</exception>
    internal static string ToCode(this CSharpSetterType setterType)
    {
        return setterType switch
        {
            CSharpSetterType.Set => "set",
            CSharpSetterType.Init => "init",
            _ => throw new UnreachableException($"Setter of type {setterType} was not implemented."),
        };
    }
}