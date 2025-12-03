using System.Text;

namespace AOC25.Day3;

// I am actually quite proud of this one
public class Day3 : IDay
{
    private string[] GetInput()
    {
        return File.ReadAllLines("Day3/Input.txt");
    }

    public string GetDay() => "3";

    public string SolvePartOne()
    {
        return Solve(true);
    }

    public string SolvePartTwo()
    {
        return Solve(false);
    }

    private string Solve(bool partOne)
    {
        string[] input = GetInput();

        long res = 0;

        foreach (string s in input)
        {
            List<long> numbers = s.Select(c => long.Parse(c.ToString())).ToList();

            StringBuilder sb = new();
            
            for (int i = partOne ? 1 : 11; i >= 0; i--)
            {
                List<long> debug = numbers.GetRange(0, numbers.Count - i);
                
                long maxNum = debug.Max(); 
                sb.Append(maxNum);
                
                int maxNumInd = numbers.IndexOf(maxNum);
                numbers.RemoveRange(0, maxNumInd + 1);
            }
            
            res += long.Parse(sb.ToString());
        }

        return res.ToString();
    }
}