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
                    zeroCount += AlterDialPartTwo(-int.Parse(line[1..]), ref dialPos);
                    break;
                case 'R':
                    zeroCount += AlterDialPartTwo(int.Parse(line[1..]), ref dialPos);
                    break;
            }
        }
        
        return zeroCount.ToString();
    }
    
    private static void AlterDial(int num, ref int dial)
    {
        dial += num;
        
        if (dial is < 0 or > 99)
        {
            dial %= 100;
        }
    }

    //I gave up trying to do this mathematically, just simulating the dial turns instead.
    //It is not efficient and is a terrible solution, but I've spent way too long on this already.
    private static int AlterDialPartTwo(int num, ref int dial)
    {
        var zeroCount = 0;

        bool isNegative = num < 0;
        
        for (int i = 0; i < int.Abs(num); i++)
        {
            if (isNegative)
            {
                dial -= 1;
            }
            else
            {
                dial += 1;
            }
            
            if (dial < 0)
            {
                dial = 99;
            }
            else if (dial > 99)
            {
                dial = 0;
            }
            
            if (dial == 0)
            {
                zeroCount++;
            }
        }
        
        return zeroCount;
    }
}