using AdventOfCode.Core;
using AdventOfCode.Core.Extensions;

string[] lines = Files.ReadAllText().SplitBy("\n");

IReadOnlyCollection<int[]> rows = GetRows(lines);

var safeRows = rows.Where(IsSafe);
var almostSafeRows = rows.Where(IsAlmostSafe);

Console.WriteLine("Safe Reports: " + safeRows.Count());
Console.WriteLine("Almost Safe Reports: " + almostSafeRows.Count());

return;

static IReadOnlyCollection<int[]> GetRows(string[] lines)
{
    List<int[]> rows = [];
    rows.AddRange(lines.Select(line => line.SplitBy(" "))
        .Select(numbers => numbers.Select(int.Parse).ToArray()));
    return rows;
}

static bool IsSafe(IReadOnlyCollection<int> row)
{
    List<int> differences = row
        .ToPairwise()
        .Select(pair => pair.First - pair.Second)
        .ToList();

    return differences.Select(Math.Abs).All(x => x is >= 1 and <= 3) && 
           (differences.All(x => x > 0) || differences.All(x => x < 0));
}

static bool IsAlmostSafe(IReadOnlyCollection<int> row)
{
    return IsSafe(row) || row
        .Select((_, x) => row.Take(x).Concat(row.Skip(x + 1)).ToList())
        .Any(IsSafe);
}