namespace ToolBX.SmartyStrings;

public static partial class StringExtensions
{
    /// <summary>
    /// Removes all occurrences of the specified string from the end of the current string.
    /// </summary>
    public static string TrimEnd(this string value, string trimString, StringComparison comparison = StringComparison.InvariantCulture)
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(trimString);

        if (string.IsNullOrEmpty(trimString)) return value;
        while (value.EndsWith(trimString, comparison))
            value = value[..^trimString.Length];

        return value;
    }
}