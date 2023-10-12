using Json2SharpLib.Enums;
using System.Diagnostics;

namespace Json2SharpLib.Extensions;

internal static class CSharpSetterTypeExt
{
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