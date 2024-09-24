namespace ToolBX.SmartyStrings;

public static partial class StringExtensions
{
    /// <summary>
    /// Removes all occurrences of the specified string from the start of the current string.
    /// </summary>
    public static string TrimStart(this string value, string trimString, StringComparison comparison = StringComparison.InvariantCulture)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        if (trimString == null) throw new ArgumentNullException(nameof(trimString));

        if (string.IsNullOrEmpty(trimString)) return value;
        while (value.StartsWith(trimString, comparison))
            value = value.StartsWith(trimString, comparison) ? value.Substring(trimString.Length, value.Length - trimString.Length) : value;
        return value;
    }
}