namespace AlgoTraining;

public class LongestStableSegmentAlgo
{
    /// <summary>
    /// A segment is considered stable if the difference between the maximum and minimum values inside the segment is at most k.
    /// Return the length of the longest stable contiguous segment.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public int LongestStableSegmentold(int[] nums, int k)
    {
        int min, max, delta, result = 0;

        if (nums.Length <= 1) return nums.Length;

        for (int i = 0; i < nums.Length - 1 && nums.Length - i > result; i++)
        {
            int j = i + 1;
            min = nums[i];
            max = nums[i];
            delta = max - min;
            while (delta <= k)
            {
                if (j >= nums.Length)
                {
                    j++;
                    break;
                }
                max = Math.Max(max, nums[j]);
                min = Math.Min(min, nums[j]);
                delta = max - min;
                j++;
            }
            int newLength = j - i - 1;
            result = Math.Max(result, newLength);
        }

        return result;
    }

    public int LongestStableSegment(int[] nums, int k)
    {
        if (nums.Length <= 1) return nums.Length;

        CustomLinkedList deque = new() { Nums = nums, Bound = k };

        int left = 0;
        int result = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            deque.InsertMinMax(right);

            while (!deque.IsInScope)
            {
                if (deque.Min == left) deque.RemoveMin();
                if (deque.Max == left) deque.RemoveMax();

                left++;
            }

            result = Math.Max(result, right - left + 1);
        }

        return result;
    }

    public void TestAll()
    {
        Test([5, 4, 1, 10], 4, 3);
        Test([2, 1, 3, 6, 7, 9, 10], 4, 4);
        Test([4, 3, 6, 7, 11, 13], 4, 4);
        Test([4, 4, 4, 4], 0, 4);
        Test([1, 10, 2, 3, 4], 3, 3);
        Test([], 4, 0);
        Test([1], 4, 1);
    }

    private void Test(int[] nums, int k, int expected)
    {
        Console.WriteLine(LongestStableSegment(nums, k) == expected ? "ok": "error");
    }
}
