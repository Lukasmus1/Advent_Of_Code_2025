namespace AOC25.Day1;

public class Day1 : IDay
{
    private static string[] GetInput()
    {
        return File.ReadAllLines("Day1/input.txt");
    }

    public string SolvePartOne()
    {
        string[] input = GetInput();

        var dialPos = 50;

        var zeroCount = 0;
        
        foreach (string line in input)
        {
            switch (line[0])
            {
                case 'L':
                    AlterDial(-int.Parse(line[1..]), ref dialPos);
                    break;
                case 'R':
                    AlterDial(int.Parse(line[1..]), ref dialPos);
                    break;
            }

            if (dialPos == 0)
            {
                zeroCount++;
            }
        }
        
        return zeroCount.ToString();
    }

    public string SolvePartTwo()
    {
        string[] input = GetInput();

        var dialPos = 50;

        var zeroCount = 0;

        foreach (string line in input)
        {
            switch (line[0])
            {
                case 'L':
                    zeroCount += AlterDial(-int.Parse(line[1..]), ref dialPos);
                    break;
                case 'R':
                    zeroCount += AlterDial(int.Parse(line[1..]), ref dialPos);
                    break;
            }
        }
        
        return zeroCount.ToString();
    }

    private static int AlterDial(int num, ref int dial)
    {
        int zeroCount = 0;
        
        dial += num;
        
        while (dial < 0)
        {
            dial = 100 + dial;
            zeroCount++;
        }
        
        while (dial > 99)
        {
            dial -= 100;
            zeroCount++;
        }

        return zeroCount;
    }
}