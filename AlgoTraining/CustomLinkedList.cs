using System.Diagnostics;

namespace AlgoTraining;

public class CustomLinkedList
{
    public LinkedList<int> MinDeque { get; set; }
    public LinkedList<int> MaxDeque { get; set; }
    public int Min => MinDeque.First!.Value;
    public int Max => MaxDeque.First!.Value;
    public required int[] Nums { get; set; }
    public required int Bound { get; set; }
    public bool IsInScope => Nums[Max] - Nums[Min] <= Bound;

    public CustomLinkedList()
    {
        MinDeque = new LinkedList<int>();
        MaxDeque = new LinkedList<int>();
    }

    public void RemoveMin() => MinDeque.RemoveFirst();
    public void RemoveMax() => MaxDeque.RemoveFirst();

    public void InsertMinMax(int rigth)
    {
        InsertMin(rigth);
        InsertMax(rigth);
    }

    public void InsertMin(int right)
    {
        while (MinDeque.Count > 0 && Nums[MinDeque.Last!.Value] > Nums[right])
        {
            MinDeque.RemoveLast();
        }

        MinDeque.AddLast(right);
    }

    public void InsertMax(int right)
    {

        while (MaxDeque.Count > 0 && Nums[MaxDeque.Last!.Value] < Nums[right])
        {
            MaxDeque.RemoveLast();
        }

        MaxDeque.AddLast(right);
    }
}
