using System.Diagnostics.CodeAnalysis;

namespace Json2SharpApp.Extensions;

/// <summary>
/// Utility methods.
/// </summary>
internal static class Utilities
{
    /// <summary>
    /// Safely instantiates a <typeparamref name="T"/> object. 
    /// </summary>
    /// <param name="factory">The method that creates the object.</param>
    /// <param name="newObject">The newly created object or <see langword="default"/> if creation failed.</param>
    /// <param name="exception">The exception thrown by the <paramref name="factory"/> or <see langword="null"/> if no error ocurred.</param>
    /// <typeparam name="T">The type to be instantiate.</typeparam>
    /// <returns><see langword="true"/> if the object was successfully created, <see langword="false"/> otherwise.</returns>
    public static bool TryCreate<T>(Func<T> factory, [MaybeNullWhen(false)] out T newObject, [MaybeNullWhen(true)] out Exception exception)
    {
        try
        {
            exception = default;
            newObject = factory();
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            newObject = default;
            return false;
        }
    }
}