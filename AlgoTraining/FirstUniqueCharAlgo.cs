namespace AlgoTraining;

public class FirstUniqueCharAlgo
{
    /// <summary>
    /// Given a string, return the index of the first character that appears exactly once.
    /// so far, not working !!
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int FirstUniqueChar(string input)
    {
        Dictionary<char, int> indexByChar = new Dictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (!indexByChar.TryGetValue(input[i], out int _))
            {
                indexByChar[input[i]] = i;
            }
            else
            {
                indexByChar.Remove(input[i]);
                indexByChar[input[i]] = -1;
            }
        }

        return indexByChar.Count > 0 ? indexByChar.FirstOrDefault(x => x.Value >= 0).Value : -1;
    }

    public void TestAll()
    {
        Test("aaa", -1);
        Test("leetcode", 0);
        Test("aaab", 3);
        Test("loveleetcode", 2);
    }

    private void Test(string input, int expected)
    {
        int result = FirstUniqueChar(input);
        Console.WriteLine(result == expected ? "ok" : "error");
    }
}
