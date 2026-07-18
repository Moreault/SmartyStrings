namespace ToolBX.SmartyStrings;

public static partial class StringExtensions
{
    /// <summary>
    /// Removes all occurrences of the specified string from the current string.
    /// </summary>
    public static string RemoveAll(this string value, string toRemove, StringComparison comparison = StringComparison.InvariantCulture)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentException.ThrowIfNullOrWhiteSpace(toRemove);
        return value.Replace(toRemove, string.Empty, comparison);
    }

    /// <summary>
    /// Removes all occurrences of the specified character from the current string.
    /// </summary>
    public static string RemoveAll(this string value, char toRemove, StringComparison comparison = StringComparison.InvariantCulture)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        return value.Replace(toRemove.ToString(), string.Empty, comparison);
    }
}