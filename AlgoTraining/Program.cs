namespace AlgoTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LongestSubstringWithoutRepeatingCharactersAlgoTest();
            //ValidParenthesesAlgoTest();
            //TwoSumAlgoTest();
        }

        private static void LongestSubstringWithoutRepeatingCharactersAlgoTest()
        {
            LongestSubstringWithoutRepeatingCharactersAlgo longest = new();
            longest.TestAll();
        }

        private static void ValidParenthesesAlgoTest()
        {
            ValidParenthesesAlgo parenthesisAlgo = new();
            parenthesisAlgo.TestAll();
        }

        private static void TwoSumAlgoTest()
        {
            TwoSumAlgo twoSum = new();
            twoSum.TestAll();
        }
    }
}
