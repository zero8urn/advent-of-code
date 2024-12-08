using System.Text.RegularExpressions;
using AdventOfCode.Core;

string input = Files.ReadAllText();

var mulRegex = new Regex(@"(?<instruction>mul\((?<number1>\d+),(?<number2>\d+)\)|do\(\)|don't\(\))");

var result = mulRegex.Matches(input)
    .Aggregate(new Result(false, 0, 0), (acc, match) => 
    {
        string instruction = match.Groups["instruction"].Value;

        return instruction switch
        {
            "do()" => acc with { Disabled = false },
            "don't()" => acc with { Disabled = true },
            _ => new Func<Result>(() => 
            { 
                var number1 = int.Parse(match.Groups["number1"].Value);
                var number2 = int.Parse(match.Groups["number2"].Value);
                var mul = number1 * number2;
                return acc with
                {
                    Sum = acc.Sum + mul,
                    SumEnabled = acc.Disabled ? acc.SumEnabled : acc.SumEnabled + mul
                };
            })()
        };
    });

Console.WriteLine($"Part 1: {result.Sum}");
Console.WriteLine($"Part 2: {result.SumEnabled}");

record Result(bool Disabled, int Sum, int SumEnabled);
