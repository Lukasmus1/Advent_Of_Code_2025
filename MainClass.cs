using System.Diagnostics;

namespace AOC25;

internal abstract class MainClass
{
    static void Main(string[] args)
    {
        IDay[] days =
        [
            //new Day1.Day1(),
            //new Day2.Day2(),
            new Day3.Day3()
        ];

        PrintDayResults(days);
    }

    private static void PrintDayResults(IDay[] days)
    {
        var sw = new Stopwatch();
        foreach (var t in days)
        {
            Console.WriteLine("Day " + t.GetDay());
            sw.Start();
            Console.Write("Part One: " + t.SolvePartOne());
            sw.Stop();
            Console.Write(" Time: " + sw.ElapsedMilliseconds / 1000f + "s\n");
            sw.Reset();
            sw.Start();
            Console.Write("Part Two: " + t.SolvePartTwo());
            sw.Stop();
            Console.Write(" Time: " + sw.ElapsedMilliseconds / 1000f + "s\n");
            sw.Reset();
            Console.WriteLine("==============================");
        }
    }
}