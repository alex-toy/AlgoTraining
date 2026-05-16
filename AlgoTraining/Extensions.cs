namespace AlgoTraining;

public static class Extensions
{
    private static readonly char[] openings = ['(', '{', '['];

    public static bool IsOpeningParenthesis(this char input)
    {
        return openings.Contains(input);
    }

    public static void Combine(this List<(int start, int end)> result, int i, int j)
    {
        var newInterval = (Math.Min(result[i].start, result[j].start), Math.Max(result[i].end, result[j].end));
        result.RemoveAt(i);
        result.Insert(i, newInterval);
        result.RemoveAt(j);
    }

    public static void Swap(this List<(int start, int end)> result, int i, int j)
    {
        var temp = result[i];
        result[i] = result[j];
        result[j] = temp;
    }
}
