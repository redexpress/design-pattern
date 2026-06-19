namespace Redexpress.DesignPatterns;

public interface IDuck
{
    void Quack();
    void Fly();
}

public class WhiteDuck : IDuck
{
    public void Fly() => Console.WriteLine("I'm flying");

    public void Quack() => Console.WriteLine("Quack");
}

public interface ITurkey
{
    void Fly();
    void Goobble();
}

public class WildTurkey : ITurkey
{
    public void Fly() => Console.WriteLine("I'm flying");

    public void Goobble() => Console.WriteLine("Gobble gobble");
}

public class TurkeyAdapter(ITurkey turkey) : IDuck
{
    public void Quack() => turkey.Goobble();
    public void Fly()
    {
        for (int i = 0; i < 3; i++)
        {
            turkey.Fly();
        }
    }
}

public class DuckTestDrive
{
    public static void Run()
    {
        var duck = new WhiteDuck();
        var turkey = new WildTurkey();
        var turkeyAdapter = new TurkeyAdapter(turkey);
        Console.WriteLine("The Turkey says...");
        turkey.Goobble();
        turkey.Fly();

        Console.WriteLine("\nThe Duck says...");
        TestDuck(duck);

        Console.WriteLine("\nThe TurkeyAdapter says...");
        TestDuck(turkeyAdapter);
    }

    static void TestDuck(IDuck duck)
    {
        duck.Quack();
        duck.Fly();
    }
}
