namespace ToolBX.SmartyStrings;

public static partial class StringExtensions
{
    /// <summary>
    /// Returns the index of the last character in the string. Returns -1 if the string is empty.
    /// </summary>
    public static int LastIndex(this string instance)
    {
        if (instance is null) throw new ArgumentNullException(nameof(instance));
        return instance.Length - 1;
    }
}