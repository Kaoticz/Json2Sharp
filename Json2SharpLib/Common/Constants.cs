namespace Json2SharpLib.Common;

/// <summary>
/// Defines constants for the library.
/// </summary>
internal static class Constants
{
    /// <summary>
    /// C# using for System Text Json.
    /// </summary>
    public const string StjUsing = "using System.Text.Json.Serialization;";

    /// <summary>
    /// C# using for Newtonsoft Json.
    /// </summary>
    public const string NewtonsoftUsing = "using Newtonsoft.Json;";

    /// <summary>
    /// Python import base for type hints.
    /// </summary>
    public const string PythonTypeImportBase = "from typing import ";
}