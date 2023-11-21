namespace ToolBX.SmartyStrings;

public static class StringExtensions
{
    /// <summary>
    /// Removes all occurences of the specified string from the current string.
    /// </summary>
    public static string RemoveAll(this string value, string toRemove)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return value.Replace(toRemove, string.Empty);
    }

    /// <summary>
    /// Removes all occurences of the specified character from the current string.
    /// </summary>
    public static string RemoveAll(this string value, char toRemove)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return value.Replace(toRemove.ToString(), string.Empty);
    }

    /// <summary>
    /// True if the string is an integer or floating point number.
    /// </summary>
    public static bool IsNumeric(this string value)
    {
        if (value is null) throw new ArgumentNullException(nameof(value));
        return double.TryParse(value, out _);
    }

    /// <summary>
    /// Removes all occurences of the specified string from the end of the current string.
    /// </summary>
    public static string TrimEnd(this string value, string trimString, StringComparison comparison = StringComparison.InvariantCulture)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        if (trimString == null) throw new ArgumentNullException(nameof(trimString));

        while (value.EndsWith(trimString, comparison))
            value = value[..^trimString.Length];

        return value;
    }

    /// <summary>
    /// Removes all occurences of the specified string from the start of the current string.
    /// </summary>
    public static string TrimStart(this string value, string trimString, StringComparison comparison = StringComparison.InvariantCulture)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        if (trimString == null) throw new ArgumentNullException(nameof(trimString));

        while (value.StartsWith(trimString, comparison))
            value = value.StartsWith(trimString, comparison) ? value.Substring(trimString.Length, value.Length - trimString.Length) : value;
        return value;
    }

    /// <summary>
    /// Returns all indexes of the specified string in the current string.
    /// </summary>
    public static IReadOnlyList<int> IndexesOf(this string instance, string value, StringComparison comparison = StringComparison.InvariantCulture)
    {
        if (string.IsNullOrWhiteSpace(instance)) throw new ArgumentNullException(nameof(instance));
        if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

        var minIndex = instance.IndexOf(value, comparison);
        if (minIndex < 0) return Array.Empty<int>();

        var indexes = new List<int> { minIndex };
        while (minIndex > -1)
        {
            minIndex = instance.IndexOf(value, minIndex + value.Length, comparison);
            if (minIndex > -1)
                indexes.Add(minIndex);
        }

        return indexes;
    }

    /// <summary>
    /// Returns all indexes of the specified character in the current string.
    /// </summary>
    public static IReadOnlyList<int> IndexesOf(this string instance, char value, StringComparison comparison = StringComparison.InvariantCulture)
    {
        return instance.IndexesOf(value.ToString(), comparison);
    }

    public static int LastIndex(this string instance)
    {
        if (instance == null) throw new ArgumentNullException(nameof(instance));
        return instance.Length - 1;
    }
}