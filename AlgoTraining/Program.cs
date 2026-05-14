namespace AlgoTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValidParenthesesAlgoTest();
            //TwoSumAlgoTest();
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
