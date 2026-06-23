using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redexpress.DesignPatterns.Uncommon;

public static class IntFlyweight
{
    private static readonly Dictionary<int, object> cache = new();

    static IntFlyweight()
    {
        for (int i = -128; i <= 127; i++)
        {
            cache[i] = i;
        }
    }

    public static object GetInstance(int num)
    {
        return cache.TryGetValue(num, out var val) ? val : num;
    }
}

public class FlyweightTest
{
    public static void Run()
    {
        object a = IntFlyweight.GetInstance(100);
        object b = IntFlyweight.GetInstance(100);
        Console.WriteLine(a == b);
    }
}
