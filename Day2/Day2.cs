namespace AOC25.Day2;

//Really inefficient solution but it's acceptable for me
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
                if (CheckForInvalidPartOne(i))
                {
                    res += i;
                }
            }
        }

        return res.ToString();
    }

    private static bool CheckForInvalidPartOne(long id)
    {
        var idStr = id.ToString();
        int idLen = idStr.Length;

        bool res = idStr[..(idLen / 2)] == idStr[(idLen / 2)..];

        return idStr.Length % 2 != 1 && res;
    }
    
    public string SolvePartTwo()
    {
        string[] input = GetInput();

        long res = 0;
        
        foreach (string id in input)
        {
            var idRanges = id.Split('-');
            for (long i = long.Parse(idRanges[0]); i <= long.Parse(idRanges[1]); i++)
            {
                if (CheckForInvalidPartTwo(i))
                {
                    res += i;
                }
            }
        }

        return res.ToString();
    }

    private static bool CheckForInvalidPartTwo(long id)
    {
        string idStr = id.ToString();
        int idLen = idStr.Length;

        bool isInvalid = false;
        
        for (var i = 1; i <= idLen / 2; i++)
        {
            if (idLen % i != 0)
            {
                continue;
            }
            
            List<string> parts = SplitByIndex(idStr,i);

            if (parts.Distinct().Count() == 1)
            {
                isInvalid = true;
                break;
            }
        }

        return isInvalid;
    }

    private static List<string> SplitByIndex(string text, int index)
    {
        List<string> parts = [];
        
        for (var i = 0; i < text.Length; i += index)
        {
            parts.Add(text[i..(i+index)]);
        }

        return parts;
    }
}