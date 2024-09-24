namespace ToolBX.SmartyStrings;

public static partial class StringExtensions
{
    /// <summary>
    /// Removes all occurrences of the specified string from the current string.
    /// </summary>
    public static string RemoveAll(this string value, string toRemove)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return value.Replace(toRemove, string.Empty);
    }

    /// <summary>
    /// Removes all occurrences of the specified character from the current string.
    /// </summary>
    public static string RemoveAll(this string value, char toRemove)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return value.Replace(toRemove.ToString(), string.Empty);
    }
}