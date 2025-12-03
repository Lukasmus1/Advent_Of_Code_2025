namespace AOC25.Day3;

public class Day3 : IDay
{
    private string[] GetInput()
    {
        return File.ReadAllLines("Day3/Input.txt");
    }

    public string GetDay() => "3";

    public string SolvePartOne()
    {
        string[] input = GetInput();

        int res = 0;
        
        foreach (string s in input)
        {
            List<int> numbers = s.Select(c => int.Parse(c.ToString())).ToList();
            var originalNumbers = new List<int>(numbers);
            
            int maxNum = numbers.Max();
            int maxIndex = numbers.IndexOf(maxNum);
            
            numbers.RemoveRange(0, maxIndex + 1);
            if (numbers.Count == 0)
            {
                originalNumbers.RemoveAt(maxIndex);
                res += int.Parse($"{originalNumbers.Max()}{maxNum}");
            }
            else
            {
                res += int.Parse($"{maxNum}{numbers.Max()}");
            }
        }
        
        return res.ToString();
    }

    public string SolvePartTwo()
    {
        return "";
    }
}