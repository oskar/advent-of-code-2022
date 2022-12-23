using System;
using System.Linq;

namespace advent_of_code_2022;

public class Day2 : IDay
{
    public long PartOne(string[] input) => input.Select(RoundScorePartOne).Sum();

    private static int RoundScorePartOne(string round) => round switch
    {
        "A X" => 1 + 3, // rock rock,
        "A Y" => 2 + 6, // rock paper
        "A Z" => 3 + 0, // rock scissors

        "B X" => 1 + 0, // paper rock
        "B Y" => 2 + 3, // paper paper
        "B Z" => 3 + 6, // paper scissors

        "C X" => 1 + 6, // scissors rock
        "C Y" => 2 + 0, // scissors paper
        "C Z" => 3 + 3, // scissors scissors
        _ => throw new Exception()
    };

    public long PartTwo(string[] input) => input.Select(RoundScorePartTwo).Sum();

    private static int RoundScorePartTwo(string round) => round switch
    {
        "A X" => 3, // they rock, should lose (0p) => choose scissors (3p)
        "A Y" => 4, // they rock, should tie (3p) => choose rock (1p)
        "A Z" => 8, // they rock, should win (6p) => choose paper (2p)

        "B X" => 1, // they paper, should lose (0p) => choose rock (1p)
        "B Y" => 5, // they paper, should tie (3p) => choose paper (2p)
        "B Z" => 9, // they paper, should win (6p) => choose scissors (3p)

        "C X" => 2, // they scissors, should lose (0p) => choose paper (2p)
        "C Y" => 6, // they scissors, should tie (3p) => choose scissors (3p)
        "C Z" => 7, // they scissors, should win (6p) => choose rock (1p)
        _ => throw new Exception()
    };
}
