namespace AOC25.Day5;

public class Day5 : IDay
{
    public string GetDay() => "5";

    private (List<string>, List<string>) GetInput()
    {
        List<string> lines = File.ReadAllLines("Day5/Input.txt").ToList();

        List<string> ranged = lines.TakeWhile(x => x != "").ToList();
        List<string> ids = lines.Skip(ranged.Count + 1).ToList();

        return (ranged, ids);
    }

    public string SolvePartOne()
    {
        (List<string> ranged, List<string> ids) = GetInput();

        Dictionary<long, long> ranges = new();

        int fresh = 0;

        foreach (string s in ranged)
        {
            string[] split = s.Split('-');

            long start = long.Parse(split[0]);
            long end = long.Parse(split[1]);

            if (ranges.TryGetValue(start, out long value))
            {
                if (value < end)
                {
                    ranges[start] = end;
                }
            }
            else
            {
                ranges.Add(start, end);
            }
        }

        foreach (string id in ids)
        {
            long idInt = long.Parse(id);

            if (ranges.Any(range => range.Key <= idInt && range.Value >= idInt))
            {
                fresh++;
            }
        }

        return fresh.ToString();
    }

    public string SolvePartTwo()
    {
        return "";
    }
}