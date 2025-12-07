using System.Text;

namespace AOC25.Day6;

public class Day6 : IDay
{
    public string GetDay() => "6";

    private List<List<string>> GetInputPartOne()
    {
        List<string> lines = File.ReadAllLines("Day6/input.txt").ToList();

        return lines.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
    }
    
    private List<string> GetInputPartTwo()
    {
        return File.ReadAllLines("Day6/input.txt").ToList();
    }
    
    public string SolvePartOne()
    {
        List<List<string>> input = GetInputPartOne();

        List<long> res = [];
        
        for (var x = 0; x < input[0].Count; x++)
        {
            List<long> nums = [];
            for (var y = 0; y < input.Count - 1; y++)
            {
                nums.Add(long.Parse(input[y][x]));
            }

            res.Add(input[^1][x] switch 
            {
                "+" => nums.Sum(),
                "*" => nums.Aggregate((a, b) => a * b),
                _ => 0
            });
        }
        
        
        return res.Sum().ToString();
    }

    public string SolvePartTwo()
    {
        List<string> input = GetInputPartTwo();

        List<long> nums = [];
        long res = 0;
        
        StringBuilder sb = new();
        char operation = '.';
        for (var i = 0; i < input[0].Length; i++)
        {
            if (SplitCheck(input, i))
            {
                res += operation switch
                {
                    '+' => nums.Sum(),
                    '*' => nums.Aggregate((a, b) => a * b),
                    _ => 0
                };
                
                nums.Clear();
                continue;
            }

            foreach (string t in input)
            {
                if (t[i] == '*')
                {
                    operation = '*';
                    break;
                }
                if (t[i] == '+')
                {
                    operation = '+';
                    break;
                }
                
                sb.Append(t[i]);
            }
            
            nums.Add(long.Parse(sb.ToString()));
            sb.Clear();
        }
        
        res += operation switch
        {
            '+' => nums.Sum(),
            '*' => nums.Aggregate((a, b) => a * b),
            _ => 0
        };

        return res.ToString();
    }

    private static bool SplitCheck(List<string> input, int index)
    {
        if (input.Any(t => t[index] != ' '))
        {
            return false;
        }
        
        return true;
    }
}