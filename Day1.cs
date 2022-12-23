using System;
using System.Collections.Generic;
using System.Linq;

namespace advent_of_code_2022;

public class Day1 : IDay
{
    public long PartOne(string[] input)
    {
        return GetElves(input).Max();
    }

    public long PartTwo(string[] input)
    {
        return GetElves(input).OrderByDescending(e => e).Take(3).Sum();
    }

    private static List<int> GetElves(string[] input)
    {
        var elves = new List<int>();
        var currentElf = 0;
        foreach (var line in input)
        {
            if (line == string.Empty)
            {
                elves.Add(currentElf);
                currentElf = 0;
            }
            else
            {
                currentElf += int.Parse(line);
            }
        }

        if (currentElf > 0)
        {
            elves.Add(currentElf);
        }

        foreach (var elf in elves)
        {
            Console.WriteLine(elf);
        }

        return elves;
    }
}
