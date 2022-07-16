namespace ToolBX.SmartyStrings;

public static class StringExtensions
{
    public static string RemoveAll(this string value, string toRemove) => value.Replace(toRemove, string.Empty);

    public static string RemoveAll(this string value, char toRemove) => value.Replace(toRemove, '\0');

    public static bool IsNumeric(this string value) => value.ToDouble().IsSuccess;

    public static string TrimEnd(this string value, string trimString, StringComparison comparison = StringComparison.InvariantCulture)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        if (trimString == null) throw new ArgumentNullException(nameof(trimString));

        while (value.EndsWith(trimString, comparison))
            value = value.Substring(0, value.Length - trimString.Length);

        return value;
    }

    public static string TrimStart(this string value, string trimString, StringComparison comparison = StringComparison.InvariantCulture)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        if (trimString == null) throw new ArgumentNullException(nameof(trimString));

        while (value.StartsWith(trimString, comparison))
            value = value.StartsWith(trimString, comparison) ? value.Substring(trimString.Length, value.Length - trimString.Length) : value;
        return value;
    }

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