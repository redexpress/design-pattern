namespace Redexpress.DesignPatterns;

public abstract class CaffeineBeverage
{
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (CustomerWantsCondiments())
        {
            AddCondiments();
        }
    }

    public void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    public void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }

    public abstract void Brew();
    public abstract void AddCondiments();

    bool CustomerWantsCondiments()
    {
        return true;
    }
}

public class Coffee : CaffeineBeverage
{

    public override void Brew()
    {
        Console.WriteLine("Dripping Coffee throght filter");
    }

    public override void AddCondiments()
    {
        Console.WriteLine("Adding Sugar and Milk");
    }
}

public class Tea : CaffeineBeverage
{
    public override void Brew()
    {
        Console.WriteLine("Steeping the tea");
    }

    public override void AddCondiments()
    {
        Console.WriteLine("Adding Lemon");
    }
}

public class BeverageTestDrive
{
    public static void Run()
    {
        var tea = new Tea();
        var coffee = new Coffee();
        Console.WriteLine("Making tea...");
        tea.PrepareRecipe();
        Console.WriteLine("Making coffee...");
        coffee.PrepareRecipe();
    }
}



