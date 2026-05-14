namespace AlgoTraining;

public class TwoSumAlgo
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> indexByLack = new Dictionary<int, int>();

        for(int i = 0; i < nums.Length; i++)
        {
            if (indexByLack.TryGetValue(target - nums[i], out int index))
            {
                return [i, index];
            }
            else
            {
                if (!indexByLack.TryGetValue(nums[i], out _))
                {
                    indexByLack.Add(nums[i], i);
                }
            }
        }

        return [];
    }

    public void TestAll()
    {
        Test([3, 4, 4, 4], 9);
        Test([3, 2, 4], 6);
        Test([3, 3], 6);
        Test([2, 7, 11, 15], 9);
        Test([-1, -2, -3, -4, -5], -8);
    }

    private void Test(int[] nums, int target)
    {
        int[] result = TwoSum(nums, target);
        if (result.Length > 0)
        {
            Console.WriteLine(nums[result[0]] + nums[result[1]] == target ? "ok" : "error");
        }
        else
        {
            Console.WriteLine("No solution");
        }
    }
}
