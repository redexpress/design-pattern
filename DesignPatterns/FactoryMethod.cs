namespace Rexexpress.DesignPatterns;

public abstract class Pizza
{
    public string Name { get; protected set; } = "";

    public virtual void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");
    }

    public virtual void Bake()
    {
        Console.WriteLine("Bake for 25 minutes");
    }

    public virtual void Cut()
    {
        Console.WriteLine("Cutting the pizza");
    }

    public virtual void Box()
    {
        Console.WriteLine("Place pizza in official box");
    }
}

public class NYStyleCheesePizza : Pizza
{
    public NYStyleCheesePizza()
    {
        Name = "New York Style Cheese Pizza";
    }
}

public class ChicagoStyleCheesePizza : Pizza
{
    public ChicagoStyleCheesePizza()
    {
        Name = "Chicago Style Cheese Pizza";
    }

    public override void Cut()
    {
        Console.WriteLine("Cutting the pizza into square slices");
    }
}

public abstract class PizzaStore
{
    public Pizza OrderPizza(string type)
    {
        Pizza pizza = CreatePizza(type);

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();

        return pizza;
    }

    protected abstract Pizza CreatePizza(string type);
}

public class NYPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        if (type == "cheese")
            return new NYStyleCheesePizza();

        throw new ArgumentException("Unknown pizza type");
    }
}

public class ChicagoPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        if (type == "cheese")
            return new ChicagoStyleCheesePizza();

        throw new ArgumentException("Unknown pizza type");
    }
}

public class PizzaTestDriver
{
    public static void Run()
    {
        PizzaStore nyStore = new NYPizzaStore();
        PizzaStore chicagoStore = new ChicagoPizzaStore();

        Pizza pizza = nyStore.OrderPizza("cheese");
        Console.WriteLine($"Ethan ordered a {pizza.Name}\n");

        pizza = chicagoStore.OrderPizza("cheese");
        Console.WriteLine($"Joel ordered a {pizza.Name}");
    }
}
