using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace advent_of_code_2022;

internal class Program
{
    private static readonly IEnumerable<Type> DayTypes =
        typeof(Program).Assembly.GetTypes().Where(t => typeof(IDay).IsAssignableFrom(t) && t.IsClass);

    public static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            RunDay(args[0]);
        }
        else
        {
            foreach (var dayType in DayTypes)
            {
                Console.WriteLine(dayType.Name);
            }

            Console.Write("Select day: ");
            RunDay(Console.ReadLine());
        }

        static string[] GetInput(int dayNumber)
        {
            var fileName = $"Day{dayNumber}.input";
            return File.Exists(fileName) ? File.ReadAllLines(fileName) : Array.Empty<string>();
        }

        static IDay? GetDay(int dayNumber)
        {
            var dayType = DayTypes.FirstOrDefault(t => t.Name == "Day" + dayNumber);
            return dayType != null ? (IDay?)Activator.CreateInstance(dayType) : null;
        }

        static void RunDay(string? input)
        {
            if (int.TryParse(input, out var dayNumber))
            {
                var day = GetDay(dayNumber);
                if (day == null)
                {
                    Console.WriteLine($"Day {dayNumber} is not implemented");
                    return;
                }

                var dayInput = GetInput(dayNumber);
                Console.WriteLine($"Day {dayNumber} part 1: {day.PartOne(dayInput)}");
                Console.WriteLine($"Day {dayNumber} part 2: {day.PartTwo(dayInput)}");
            }
            else
            {
                Console.WriteLine("Could not parse argument to day number");
            }
        }
    }
}
