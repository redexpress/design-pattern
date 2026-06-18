namespace Redexpress.DesignPatterns.Tests;

using Xunit;
using Redexpress.DesignPatterns;

public class SingletonTests
{
    [Fact]
    public void Should_Return_Same_Instance()
    {
        var s1 = Singleton.Instance;
        var s2 = Singleton.Instance;

        Assert.Same(s1, s2);
    }
}