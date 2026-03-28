namespace ToolBX.SmartyStrings;

public static partial class StringExtensions
{
    /// <summary>
    /// Removes all occurrences of the specified string from the start of the current string.
    /// </summary>
    public static string TrimStart(this string value, string trimString, StringComparison comparison = StringComparison.InvariantCulture)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        if (trimString is null) throw new ArgumentNullException(nameof(trimString));

        if (string.IsNullOrEmpty(trimString)) return value;
        while (value.StartsWith(trimString, comparison))
            value = value[trimString.Length..];
        return value;
    }
}