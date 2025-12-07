namespace AOC25.Day6;

public class Day6 : IDay
{
    public string GetDay() => "6";

    private List<List<string>> GetInput()
    {
        List<string> lines = File.ReadAllLines("Day6/input.txt").ToList();

        return lines.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList()).ToList();
    }
    
    public string SolvePartOne()
    {
        List<List<string>> input = GetInput();

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
        throw new NotImplementedException();
    }
}