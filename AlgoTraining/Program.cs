namespace AlgoTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MergeIntervalsAlgoTest();
            //LongestSubstringWithoutRepeatingCharactersAlgoTest();
            //ValidParenthesesAlgoTest();
            //TwoSumAlgoTest();
        }

        private static void MergeIntervalsAlgoTest()
        {
            MergeIntervalsAlgo algo = new();
            algo.TestAll();
        }

        private static void LongestSubstringWithoutRepeatingCharactersAlgoTest()
        {
            LongestSubstringWithoutRepeatingCharactersAlgo algo = new();
            algo.TestAll();
        }

        private static void ValidParenthesesAlgoTest()
        {
            ValidParenthesesAlgo algo = new();
            algo.TestAll();
        }

        private static void TwoSumAlgoTest()
        {
            TwoSumAlgo algo = new();
            algo.TestAll();
        }
    }
}
