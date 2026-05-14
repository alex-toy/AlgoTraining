namespace AlgoTraining;

public class LongestSubstringWithoutRepeatingCharactersAlgo
{
    /// <summary>
    /// Given a string input, find the length of the longest substring that contains no repeating characters.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public int LengthOfLongestSubstring(string input)
    {
        Dictionary<char, int> indexByChar = new Dictionary<char, int>();

        int maxLength = 0;
        int leftBound = 0;

        if (input.Length == 0) return 0;

        int scanningIndex = 0;
        while (scanningIndex < input.Length)
        {
            if (indexByChar.TryGetValue(input[scanningIndex], out int indexChar) && indexChar >= leftBound)
            {
                leftBound = indexChar + 1;
            }

            indexByChar[input[scanningIndex]] = scanningIndex;
            maxLength = Math.Max(maxLength, scanningIndex - leftBound + 1);
            scanningIndex++;
        }

        return maxLength;
    }

    public void TestAll()
    {
        Test("au", 2);
        Test("bacadeb", 5);
        Test("pwwkew", 3);
        Test("abcdbacd", 4);
        Test("", 0);
        Test("abcabcbb", 3);
        Test("bbbbb", 1);
        Test("dvdf", 3);
        Test("abcadeb", 5);
    }

    private void Test(string input, int length)
    {
        Console.WriteLine(LengthOfLongestSubstring(input) == length ? "ok" : "error");
    }
}
