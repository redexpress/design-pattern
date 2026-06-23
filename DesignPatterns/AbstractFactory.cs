
namespace Redexpress.DesignPatterns.AbstractFactory;
public abstract class Dough { }
public class ThinCrustDough : Dough { }
public class ThickCrustDough : Dough { }

public abstract class Sauce { }
public class MarinaraSauce : Sauce { }
public class PlumTomatoSauce : Sauce { }

public abstract class Cheese { }
public class ReggianoCheese : Cheese { }
public class MozzarellaCheese : Cheese { }

public abstract class Veggies { }
public class Garlic : Veggies { }
public class Onion : Veggies { }
public class Mushroom : Veggies { }
public class RedPepper : Veggies { }
public class BlackOlives : Veggies { }
public class Spinach : Veggies { }
public class EggPlant : Veggies { }

public abstract class Pepperoni { }
public class SlicedPepperoni : Pepperoni { }

public abstract class Clams { }
public class FreshClams : Clams { }
public class FrozenClams : Clams { }
public interface IPizzaIngredientFactory
{
    Dough CreateDough();
    Sauce CreateSauce();
    Cheese CreateCheese();
    Veggies[] CreateVeggies();
    Pepperoni CreatePepperoni();
    Clams CreateClam();
}

public class NYPizzaIngredientFactory : IPizzaIngredientFactory
{
    public Dough CreateDough() => new ThinCrustDough();
    public Sauce CreateSauce() => new MarinaraSauce();
    public Cheese CreateCheese() => new ReggianoCheese();

    public Veggies[] CreateVeggies() =>
    [
        new Garlic(),
        new Onion(),
        new Mushroom(),
        new RedPepper()
    ];

    public Pepperoni CreatePepperoni() => new SlicedPepperoni();
    public Clams CreateClam() => new FreshClams();
}

public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
{
    public Dough CreateDough() => new ThickCrustDough();
    public Sauce CreateSauce() => new PlumTomatoSauce();
    public Cheese CreateCheese() => new MozzarellaCheese();

    public Veggies[] CreateVeggies() =>
    [
        new BlackOlives(),
        new Spinach(),
        new EggPlant()
    ];

    public Pepperoni CreatePepperoni() => new SlicedPepperoni();
    public Clams CreateClam() => new FrozenClams();
}

public abstract class Pizza
{
    public string Name { get; set; } = "";

    protected Dough Dough = null!;
    protected Sauce Sauce = null!;
    protected Cheese Cheese = null!;
    protected Veggies[] Veggies = [];
    protected Pepperoni Pepperoni = null!;
    protected Clams Clam = null!;

    public abstract void Prepare();

    public virtual void Bake()
    {
        Console.WriteLine("Bake for 25 minutes at 350");
    }

    public virtual void Cut()
    {
        Console.WriteLine("Cutting the pizza into diagonal slices");
    }

    public virtual void Box()
    {
        Console.WriteLine("Place pizza in official PizzaStore box");
    }
}

public class CheesePizza : Pizza
{
    private readonly IPizzaIngredientFactory ingredientFactory;

    public CheesePizza(IPizzaIngredientFactory ingredientFactory)
    {
        this.ingredientFactory = ingredientFactory;
    }

    public override void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");

        Dough = ingredientFactory.CreateDough();
        Sauce = ingredientFactory.CreateSauce();
        Cheese = ingredientFactory.CreateCheese();
    }
}

public class ClamPizza : Pizza
{
    private readonly IPizzaIngredientFactory ingredientFactory;

    public ClamPizza(IPizzaIngredientFactory ingredientFactory)
    {
        this.ingredientFactory = ingredientFactory;
    }

    public override void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");

        Dough = ingredientFactory.CreateDough();
        Sauce = ingredientFactory.CreateSauce();
        Cheese = ingredientFactory.CreateCheese();
        Clam = ingredientFactory.CreateClam();
    }
}

public class VeggiePizza : Pizza
{
    private readonly IPizzaIngredientFactory ingredientFactory;

    public VeggiePizza(IPizzaIngredientFactory ingredientFactory)
    {
        this.ingredientFactory = ingredientFactory;
    }

    public override void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");

        Dough = ingredientFactory.CreateDough();
        Sauce = ingredientFactory.CreateSauce();
        Cheese = ingredientFactory.CreateCheese();
        Veggies = ingredientFactory.CreateVeggies();
    }
}

public class PepperoniPizza : Pizza
{
    private readonly IPizzaIngredientFactory ingredientFactory;

    public PepperoniPizza(IPizzaIngredientFactory ingredientFactory)
    {
        this.ingredientFactory = ingredientFactory;
    }

    public override void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");

        Dough = ingredientFactory.CreateDough();
        Sauce = ingredientFactory.CreateSauce();
        Cheese = ingredientFactory.CreateCheese();
        Pepperoni = ingredientFactory.CreatePepperoni();
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
        IPizzaIngredientFactory ingredientFactory = new NYPizzaIngredientFactory();

        Pizza pizza = type switch
        {
            "cheese" => new CheesePizza(ingredientFactory),
            "clam" => new ClamPizza(ingredientFactory),
            "veggie" => new VeggiePizza(ingredientFactory),
            "pepperoni" => new PepperoniPizza(ingredientFactory),
            _ => throw new ArgumentException("Unknown pizza type")
        };

        pizza.Name = $"New York Style {type} Pizza";

        return pizza;
    }
}

public class ChicagoPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        IPizzaIngredientFactory ingredientFactory = new ChicagoPizzaIngredientFactory();

        Pizza pizza = type switch
        {
            "cheese" => new CheesePizza(ingredientFactory),
            "clam" => new ClamPizza(ingredientFactory),
            "veggie" => new VeggiePizza(ingredientFactory),
            "pepperoni" => new PepperoniPizza(ingredientFactory),
            _ => throw new ArgumentException("Unknown pizza type")
        };

        pizza.Name = $"Chicago Style {type} Pizza";

        return pizza;
    }
}

public class AbstractPizzaTestDriver
{
    public static void Run()
    {
        PizzaStore nyStore = new NYPizzaStore();
        PizzaStore chicagoStore = new ChicagoPizzaStore();

        Pizza pizza = nyStore.OrderPizza("cheese");
        Console.WriteLine($"Ethan ordered a {pizza.Name}\n");

        pizza = chicagoStore.OrderPizza("clam");
        Console.WriteLine($"Joel ordered a {pizza.Name}");
    }
}
