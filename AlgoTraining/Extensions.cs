namespace AlgoTraining;

public static class Extensions
{
    private static readonly char[] openings = ['(', '{', '['];

    public static bool IsOpeningParenthesis(this char input)
    {
        return openings.Contains(input);
    }
}
