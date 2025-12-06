namespace AOC25.Day4;

public class Day4 : IDay
{
    public string GetDay() => "4";

    private List<string> GetInput()
    {
        return File.ReadAllLines("Day4/Input.txt").ToList();
    }

    public string SolvePartOne()
    {
        List<string> input = GetInput();
        List<(int, int)> directions =
        [
            (0, 1),
            (1, 0),
            (1, 1),
            (0, -1),
            (-1, 0),
            (-1, -1),
            (1, -1),
            (-1, 1)
        ];

        var res = 0;

        for (var x = 0; x < input[0].Length; x++)
        {
            for (var y = 0; y < input.Count; y++)
            {
                if (input[x][y] != '@')
                {
                    continue;
                }

                var rollCount = 0;
                foreach ((int, int) dir in directions)
                {
                    if (input[x][y] != '@')
                    {
                        break;
                    }
                    
                    if (x + dir.Item1 < 0 || 
                        x + dir.Item1 >= input[0].Length || 
                        y + dir.Item2 < 0 ||
                        y + dir.Item2 >= input.Count)
                    {
                        continue;
                    }
                    
                    if (input[x + dir.Item1][y + dir.Item2] != '@')
                    {
                        continue;
                    }
                    
                    rollCount++;
                }

                if (rollCount < 4)
                {
                    res++;
                }
            }
        }

        return res.ToString();
    }

    public string SolvePartTwo()
    {
        List<string> input = GetInput();
        List<(int, int)> directions =
        [
            (0, 1),
            (1, 0),
            (1, 1),
            (0, -1),
            (-1, 0),
            (-1, -1),
            (1, -1),
            (-1, 1)
        ];

        var res = 0;

        bool loopRoll;
        do
        {
            loopRoll = false;
            for (var x = 0; x < input[0].Length; x++)
            {
                for (var y = 0; y < input.Count; y++)
                {
                    if (input[x][y] != '@')
                    {
                        continue;
                    }

                    var rollCount = 0;
                    foreach ((int, int) dir in directions)
                    {
                        if (input[x][y] != '@')
                        {
                            break;
                        }

                        if (x + dir.Item1 < 0 ||
                            x + dir.Item1 >= input[0].Length ||
                            y + dir.Item2 < 0 ||
                            y + dir.Item2 >= input.Count)
                        {
                            continue;
                        }

                        if (input[x + dir.Item1][y + dir.Item2] != '@')
                        {
                            continue;
                        }

                        rollCount++;
                    }

                    if (rollCount < 4)
                    {
                        char[] row = input[x].ToCharArray();
                        row[y] = '.';
                        input[x] = new string(row);
                        res++;
                        
                        loopRoll = true;
                    }
                }
            }
        }
        while (loopRoll);

        return res.ToString();
    }
}