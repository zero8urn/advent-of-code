using AdventOfCode.Core;
using AdventOfCode.Core.Extensions;

string[] lines = Files.ReadAllText().SplitBy("\n");

(int[] left, int[] right) = GetColumns(lines);

IEnumerable<(int First, int Second)> smallestPairs = left.Order().Zip(right.Order());

IEnumerable<int> distances = smallestPairs
    .Select(pair => Math.Abs(pair.First - pair.Second));

int totalDistances = distances.Sum();

Console.WriteLine("Total Distances: " + totalDistances);

var rightLookup = right.ToLookup(r => r);
int similarityScore = left.Select(l => l * rightLookup[l].Count()).Sum();

Console.WriteLine("Similarity Score: " + similarityScore);

return;

static (int[] left, int[] right) GetColumns(string[] lines)
{
    var left = new int[lines.Length];
    var right = new int[lines.Length];

    for (int i = 0; i < lines.Length; i++)
    {
        var numbers = lines[i].SplitBy(" ");
        left[i] = int.Parse(numbers[0]);
        right[i] = int.Parse(numbers[1]);
    }

    return (left, right);
}