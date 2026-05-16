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
        int leftBoundIndex = 0;
        int maxRightBound = intervalsList[leftBoundIndex].end;

        while (leftBoundIndex < intervalsList.Count)
        {
            int rightBoundIndex = leftBoundIndex;
            while (rightBoundIndex + 1 < intervalsList.Count && maxRightBound >= intervalsList[rightBoundIndex + 1].start)
            {
                rightBoundIndex++;
                maxRightBound = Math.Max(maxRightBound, intervalsList[rightBoundIndex].end);
            }
            result.Add((intervalsList[leftBoundIndex].start, maxRightBound));

            leftBoundIndex = rightBoundIndex + 1;
            if (leftBoundIndex < intervalsList.Count) maxRightBound = intervalsList[leftBoundIndex].end;
        }

        return result.ToArray();
    }

    public void TestAll()
    {
        Test([(1, 2), (2, 10), (9, 9)], [(1, 10)]);
        Test([(-10, -5), (-4, 0), (-2, 1), (0, 2)], [(-10, -5), (-4, 2)]);
        Test([(-10, -5), (-4, 0), (0, 2)], [(-10, -5), (-4, 2)]);
        Test([(1, 7), (5, 10), (8, 12)], [(1, 12)]);
        Test([(1, 10), (2, 3), (4, 8)], [(1, 10)]);
        Test([(8, 10), (1, 3), (2, 6)], [(1, 6), (8, 10)]);
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
