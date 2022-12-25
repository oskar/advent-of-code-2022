using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2022;

public class Day3 : IDay
{
    public string PartOne(string[] input)
    {
        return input.Select(FindDuplicatedItem).Select(GetPriority).Sum().ToString();
    }

    private static char FindDuplicatedItem(string rucksack)
    {
        var firstCompartment = rucksack[..(rucksack.Length / 2)];
        var secondCompartment = rucksack[(rucksack.Length / 2)..];
        var itemsInFirst = new HashSet<char>(firstCompartment);
        return secondCompartment.First(item => itemsInFirst.Contains(item));
    }

    public string PartTwo(string[] input)
    {
        var badges = new List<char>();
        for (var i = 0; i < input.Length; i += 3)
        {
            badges.Add(input[i].Intersect(input[i + 1]).Intersect(input[i + 2]).Single());
        }

        return badges.Select(GetPriority).Sum().ToString();
    }

    private static int GetPriority(char c) => c >= 'a' ? c - 96 : c - 38;
}
