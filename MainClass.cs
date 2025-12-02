using System.Diagnostics;

namespace AOC25;

internal abstract class MainClass
{
    static void Main(string[] args)
    {
        IDay[] days =
        [
            new Day1.Day1(),
            new Day2.Day2()
        ];

        PrintDayResults(days);
    }

    private static void PrintDayResults(IDay[] days)
    {
        var sw = new Stopwatch();
        for (var i = 0; i < days.Length; i++)
        {
            Console.WriteLine("Day " + (i + 1));
            sw.Start();
            Console.Write("Part One: " + days[i].SolvePartOne());
            sw.Stop();
            Console.Write(" Time: " + sw.ElapsedMilliseconds / 1000f + "s\n");
            sw.Reset();
            sw.Start();
            Console.Write("Part Two: " + days[i].SolvePartTwo());
            sw.Stop();
            Console.Write(" Time: " + sw.ElapsedMilliseconds / 1000f + "s\n");
            sw.Reset();
            Console.WriteLine("==============================");
        }
    }
}