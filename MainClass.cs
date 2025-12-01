namespace AOC25;

internal abstract class MainClass
{
    static void Main(string[] args)
    {
        IDay[] days =
        [
            new Day1.Day1()
        ];

        PrintDayResults(days);
    }

    private static void PrintDayResults(IDay[] days)
    {
        for (var i = 0; i < days.Length; i++)
        {
            Console.WriteLine("Day " + (i + 1));
            Console.WriteLine("Part One: " + days[i].SolvePartOne());
            Console.WriteLine("Part Two: " + days[i].SolvePartTwo());
            Console.WriteLine("==============================");
        }
    }
}