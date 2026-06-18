using Redexpress.DesignPatterns;

var s1 = Singleton.Instance;
var s2 = Singleton.Instance;

Console.WriteLine(ReferenceEquals(s1, s2));