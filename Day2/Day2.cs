namespace AOC25.Day2;

public class Day2 : IDay
{
    private string[] GetInput()
    {
        return File.ReadAllText("Day2/Input.txt").Split(',');
    }
    
    public string SolvePartOne()
    { 
        string[] input = GetInput();

        long res = 0;
        
        foreach (var id in input)
        {
            var idRanges = id.Split('-');
            for (long i = long.Parse(idRanges[0]); i <= long.Parse(idRanges[1]); i++)
            {
                if (CheckForInvalid(i))
                {
                    res += i;
                }
            }
        }

        return res.ToString();
    }

    private bool CheckForInvalid(long id)
    {
        string idStr = id.ToString();
        int idLen = idStr.Length;

        bool res = idStr[..(idLen / 2)] == idStr[(idLen / 2)..];

        return idStr.Length % 2 != 1 && res;
    }
    
    public string SolvePartTwo()
    {
        return "nothing yet";
    }
}