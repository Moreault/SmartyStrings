namespace ToolBX.SmartyStrings;

public static partial class StringExtensions
{
    /// <summary>
    /// True if the string is an integer or floating point number.
    /// </summary>
    public static bool IsNumeric(this string value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return double.TryParse(value, out _);
    }
}