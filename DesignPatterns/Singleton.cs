using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redexpress.DesignPatterns;

public sealed class Singleton
{
    private static readonly Singleton instance = new Singleton();

    private Singleton()
    {
    }

    public static Singleton Instance => instance;
}