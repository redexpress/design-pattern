using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redexpress.DesignPatterns;

public sealed class SimpleSingleton
{
    private static readonly SimpleSingleton instance = new();

    private SimpleSingleton()
    {
    }

    public static SimpleSingleton Instance => instance;
}

public sealed class Singleton
{
    private static readonly Lazy<Singleton> instance =
        new(() => new Singleton());

    private Singleton()
    {
    }

    public static Singleton Instance => instance.Value;
}