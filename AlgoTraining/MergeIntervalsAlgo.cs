using System.Runtime.Serialization.Formatters;

namespace AlgoTraining;

public class MergeIntervalsAlgo
{
    public (int start, int end)[] Merge((int start, int end)[] intervals)
    {
        if (intervals.Length == 0) return [];

        var intervalsList = intervals.ToList();

        for (int i = 0; i < intervalsList.Count; i++)
        {
            for (int j = 0; j < intervalsList.Count - i - 1; j++)
            {
                if (intervalsList[j].start > intervalsList[j + 1].start)
                {
                    intervalsList.Swap(j, j+1);
                }
            }
        }

        List<(int start, int end)> result = new();
        int leftBound = 0;

        while (leftBound < intervalsList.Count)
        {
            int rightBound = leftBound;
            while (rightBound + 1 < intervalsList.Count && intervalsList[leftBound].end >= intervalsList[rightBound + 1].start)
            {
                rightBound++;
            }
            result.Add((intervalsList[leftBound].start, Math.Max(intervalsList[leftBound].end, intervalsList[rightBound].end)));
            leftBound = rightBound + 1;
        }

        return result.ToArray();
    }

    public void TestAll()
    {
        Test([(1, 10), (2, 3), (4, 8)], [(1, 10)]);
        Test([(8, 10), (1, 3), (2, 6)], [(1, 6), (8, 10)]);
        Test([(-10, -5), (-4, 0), (0, 2)], [(-10, -5), (-4, 2)]);
        Test([(5, 7), (1, 2), (3, 6)], [(1, 2), (3, 7)]);
        Test([(4, 8), (2, 3), (1, 10)], [(1, 10)]);
        Test([(1, 10), (4, 8)], [(1, 10)]);
        Test([(1, 3), (2, 6), (8, 10), (15, 18)], [(1, 6), (8, 10), (15, 18)]);
        Test([(1, 4), (4, 5)], [(1, 5)]);
        Test([(1, 100), (20, 30), (40, 50), (200, 300)], [(1, 100), (200, 300)]);
        Test([(1, 5), (1, 5), (1, 5)], [(1, 5)]);
        Test([(1, 10), (2, 3), (4, 8)], [(1, 10)]);
        Test([], []);
        Test([(1, 2)], [(1, 2)]);
    }

    private void Test((int start, int end)[] intervals, (int start, int end)[] expected)
    {
        (int start, int end)[] result = Merge(intervals);


        int index = 0;
        foreach ((int s, int e) in result)
        {
            if (index >=  expected.Length)
            {
                Console.WriteLine("error");
                return;
            }

            if (s != expected[index].start || e != expected[index].end)
            {
                Console.WriteLine("error");
                return;
            }

            index++;
        }

        Console.WriteLine("ok");
    }
}
