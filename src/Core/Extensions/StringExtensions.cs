namespace AdventOfCode.Core.Extensions;

public static class StringExtensions
{
    public static string[] SplitBy(this string s, string separator)
        => s.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
}