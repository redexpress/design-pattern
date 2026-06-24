
using System.Diagnostics;


namespace Redexpress.DesignPatterns.Platform;


public enum Color { BLACK, RED }

public class Node(int value, Color color = Color.BLACK) : IComparable<Node>
{
    public int Value { get; } = value;
    public Color Color { get; } = color;

    public int CompareTo(Node? other)
    {
        if (other is null) return 1;
        return Value.CompareTo(other.Value);
    }

    public override string ToString() => $"{Value}{(Color == Color.RED ? "r" : "")}";
}

public class SortDemo
{
    private const int N = 22000;

    public static void Run()
    {
        SmallDataSort();
        Benchmark();
    }

    private static void SmallDataSort()
    {
        Node[] arr = [
            new(9), new(23), new(45), new(78), new(34), new(91), new(56),
            new(67), new(29), new(41), new(83), new(11), new(15), new(19),
            new(9, Color.RED), new(11, Color.RED), new(2)
        ];

        var unstable = arr[..];
        Array.Sort(unstable);
        PrintArray(unstable);

        var stable = arr.OrderBy(x => x).ToArray();
        PrintArray(stable);
    }

    private static void Benchmark()
    {
        Node[] original = GenerateData(N, 20000);
        var sw = new Stopwatch();

        var copy1 = original[..];
        sw.Restart();
        Array.Sort(copy1);
        sw.Stop();
        Console.WriteLine($"Array.Sort: {sw.Elapsed.TotalMilliseconds * 1000:F0} us");

        sw.Restart();
        _ = original.OrderBy(x => x).ToArray();
        sw.Stop();
        Console.WriteLine($"OrderBy   : {sw.Elapsed.TotalMilliseconds * 1000:F0} us");
    }

    private static Node[] GenerateData(int n, int maxNumber)
    {
        int total = maxNumber * 2;
        int[] pool = new int[total];
        for (int i = 0; i < total; i++) pool[i] = i;

        Random.Shared.Shuffle(pool);

        Node[] arr = new Node[n];
        for (int i = 0; i < n; i++)
        {
            int val = pool[i] % maxNumber + 1;
            Color col = pool[i] / maxNumber == 0 ? Color.BLACK : Color.RED;
            arr[i] = new(val, col);
        }
        return arr;
    }

    private static void PrintArray(Node[] arr) =>
        Console.WriteLine(string.Join(" ", arr.Select(x => x.ToString())));
}