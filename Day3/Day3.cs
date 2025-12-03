namespace AOC25.Day3;

public class Day3 : IDay
{
    private string[] GetInput()
    {
        return File.ReadAllLines("Day3/Input.txt");
    }

    public string GetDay()
    {
        return "3";
    }

    public string SolvePartOne()
    {
        string[] input = GetInput();

        int res = 0;
        
        foreach (string s in input)
        {
            List<int> numbers = s.Select(c => int.Parse(c.ToString())).ToList();
            
        }
        
        return res.ToString();
    }

    public string SolvePartTwo()
    {
        return "";
    }
}