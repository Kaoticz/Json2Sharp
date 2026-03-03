namespace Json2SharpLib.Enums;

/// <summary>
/// Represents the possible object types in the Python language.
/// </summary>
public enum PythonObjectType : byte
{
    /// <summary>
    /// A class.
    /// </summary>
    Class,

    /// <summary>
    /// A data class.
    /// </summary>
    DataClass,

    /// <summary>
    /// A Pydantic model.
    /// </summary>
    Pydantic
}
