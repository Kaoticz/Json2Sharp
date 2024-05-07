namespace Json2SharpApp.Enums;

/// <summary>
/// The exit codes for the application.
/// </summary>
internal enum ExitCode
{
    /// <summary>
    /// The application executed successfully.
    /// </summary>
    Success,

    /// <summary>
    /// The application tried to parse broken Json.
    /// </summary>
    InvalidInput,

    /// <summary>
    /// The application has no write permissions for the target folder.
    /// </summary>
    NoWritePermission,

    /// <summary>
    /// The application tried to parse invalid options.
    /// </summary>
    OptionError
}