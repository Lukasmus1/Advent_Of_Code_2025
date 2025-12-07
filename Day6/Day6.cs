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
    
    private List<List<string>> GetInputPartTwo()
    {
        List<string> lines = File.ReadAllLines("Day6/input.txt").ToList();

        return lines.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
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
        List<List<string>> input = GetInputPartOne();

        List<long> res = [];

        StringBuilder sb = new();
        
        for (var x = 0; x < input[0].Count; x++)
        {
            List<string> nums = [];
            nums.AddRange(input.Select(t => t[x]));

            string largest = nums.MaxBy(s => s.Length)!;
            string operation = nums[^1];
            
            List<long> numbers = [];
            for (int i = 0; i < largest.Length; i++)
            {
                for (int numIndex = 0; numIndex < nums.Count - 1; numIndex++)
                {
                    if (nums[numIndex].Length - i - 1 < 0)
                    {
                        continue;
                    }

                    sb.Append(nums[numIndex][^(i + 1)]);
                }
                
                numbers.Add(long.Parse(sb.ToString()));
                sb.Clear();
            }
            
            res.Add(operation switch 
            {
                "+" => numbers.Sum(),
                "*" => numbers.Aggregate((a, b) => a * b),
                _ => 0
            });
        }

        return res.Sum().ToString();
    }
}