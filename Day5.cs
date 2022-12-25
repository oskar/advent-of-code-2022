using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace advent_of_code_2022;

public class Day5 : IDay
{
    public string PartOne(string[] input)
    {
        // Find row index with crate numbers
        var indexForCrateNumbers = FindIndexForCrateNumbers(input);
        
        // Init stacks and populate with crates
        var stacks = PopulateStacks(input, indexForCrateNumbers);

        // Move crates between stacks
        foreach (var instruction in input[(indexForCrateNumbers + 2)..])
        {
            var (count, from, to) = ParseInstruction(instruction);
            for (var i = 0; i < count; i++)
            {
                stacks[to - 1].Push(stacks[from - 1].Pop());
            }
        }

        return new string(stacks.Select(s => s.Peek()).ToArray());
    }

    public string PartTwo(string[] input)
    {
        // Find row index with crate numbers
        var indexForCrateNumbers = FindIndexForCrateNumbers(input);
        
        // Init stacks and populate with crates
        var stacks = PopulateStacks(input, indexForCrateNumbers);

        // Move crates between stacks
        foreach (var instruction in input[(indexForCrateNumbers + 2)..])
        {
            var (count, from, to) = ParseInstruction(instruction);

            var crates = new Stack<char>();
            for (var i = 0; i < count; i++)
            {
                crates.Push(stacks[from - 1].Pop());
            }

            foreach (var crate in crates)
            {
                stacks[to - 1].Push(crate);
            }
        }

        return new string(stacks.Select(s => s.Peek()).ToArray());
    }

    private static (int Count, int From, int To) ParseInstruction(string instruction)
    {
        var matches = Regex.Matches(instruction, @"\d+").Select(m => int.Parse(m.Value)).ToArray();
        return (matches[0], matches[1], matches[2]);
    }

    private static List<Stack<char>> PopulateStacks(string[] input, int indexForCrateNumbers)
    {
        var stacks = new List<Stack<char>>();
        var stackCount = Regex.Matches(input[indexForCrateNumbers], @"\s\d\s").Count;

        for (var i = 0; i < stackCount; i++)
        {
            stacks.Add(new Stack<char>());
        }

        for (var inputRow = indexForCrateNumbers - 1; inputRow >= 0; inputRow--)
        {
            for (var stackIndex = 0; stackIndex < stacks.Count; stackIndex++)
            {
                var column = stackIndex * 4 + 1;
                var c = input[inputRow][column];
                if (char.IsLetter(c))
                {
                    stacks[stackIndex].Push(c);
                }
            }
        }

        return stacks;
    }

    private static int FindIndexForCrateNumbers(string[] input) 
        => Array.FindIndex(input, i => Regex.IsMatch(i, @"^\s*\d+"));
}
