namespace AlgoTraining;

public class ValidParenthesesAlgo
{
    private readonly Dictionary<char, char> openingByClosing = new Dictionary<char, char>()
    {
        { ')', '(' },
        { ']', '[' },
        { '}', '{' },
    };

    public bool IsValid(string input)
    {
        Stack<char> currentOpenings = new Stack<char>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].IsOpeningParenthesis())
            {
                currentOpenings.Push(input[i]);
            }
            else
            {
                if (currentOpenings.Count == 0 || !openingByClosing.TryGetValue(input[i], out char opening))
                {
                    return false;
                }

                if (opening != currentOpenings.Peek()) return false;

                currentOpenings.Pop();
            }
        }

        return currentOpenings.Count == 0;
    }

    public void TestAll()
    {
        Test("", true);
        Test("()", true);
        Test("()[]{}", true);
        Test("(]", false);
        Test("([)]", false);
        Test("{[]}", true);
        Test("(((", false);
        Test("((())]", false);
    }

    private void Test(string input, bool isValid)
    {
        Console.WriteLine(IsValid(input) == isValid ? "ok" : "error");
    }
}
