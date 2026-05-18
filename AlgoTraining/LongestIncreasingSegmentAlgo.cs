namespace AlgoTraining;

internal class LongestIncreasingSegmentAlgo
{
    /// <summary>
    /// A segment is considered increasing if for every j > i, nums[j] >= nums[i].
    /// Return the length of the longest increasing segment.
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int LongestIncreasingSegment(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int i = 0, j = 1, maxLength = 1;
        while (i < nums.Length)
        {
            if (j >= nums.Length) break;

            while (j < nums.Length && nums[j] >= nums[j-1])
            {
                maxLength = Math.Max(maxLength, j - i + 1);
                j++;
            }

            i = j;
            j = i + 1;
        }

        return maxLength;
    }

    public void TestAll()
    {
        Test([], 0);
        Test([2], 1);
        Test([2, 3], 2);
        Test([5, 2, 3, 10, 7], 3);
        Test([5, 4, 1, 10], 2);
        Test([5, 4, 1, 5, 10, 9, 6, 12, 15, 16], 4);
    }

    private void Test(int[] nums, int expected)
    {
        Console.WriteLine(LongestIncreasingSegment(nums) == expected ? "ok" : "error");
    }
}
