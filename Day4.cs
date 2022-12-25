using System.Linq;
using System.Text.RegularExpressions;

namespace advent_of_code_2022;

public class Day4 : IDay
{
    private static readonly Regex Pattern = new Regex("(\\d+)-(\\d+),(\\d+)-(\\d+)");

    public string PartOne(string[] input)
    {
        return input.Select(Parse).Count(l =>
            (l.FirstLower <= l.SecondLower && l.FirstUpper >= l.SecondUpper) ||
            (l.FirstLower >= l.SecondLower && l.FirstUpper <= l.SecondUpper)).ToString();
    }

    public string PartTwo(string[] input)
    {
        return input.Select(Parse).Count(l => l.FirstUpper >= l.SecondLower && l.SecondUpper >= l.FirstLower).ToString();
    }

    private static (int FirstLower, int FirstUpper, int SecondLower, int SecondUpper) Parse(string line)
    {
        var match = Pattern.Match(line);
        return (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value),
            int.Parse(match.Groups[3].Value), int.Parse(match.Groups[4].Value));
    }
}
