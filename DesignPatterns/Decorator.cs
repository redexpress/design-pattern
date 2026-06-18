using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redexpress.DesignPatterns;

using System;

public abstract class Beverage
{
    public virtual string Description { get; set; } = "Unknown Beverage";

    public abstract double Cost();

    public virtual string GetDescription()
    {
        return Description;
    }
}

public class HouseBlend : Beverage
{
    public HouseBlend()
    {
        Description = "House Blend Coffee";
    }

    public override double Cost()
    {
        return 0.89;
    }
}

public class DarkRoast : Beverage
{
    public DarkRoast()
    {
        Description = "Dark Roast Coffee";
    }

    public override double Cost()
    {
        return 0.99;
    }
}

public class Espresso : Beverage
{
    public Espresso()
    {
        Description = "Espresso";
    }

    public override double Cost()
    {
        return 1.99;
    }
}

public class Decaf : Beverage
{
    public Decaf()
    {
        Description = "Decaf Coffee";
    }

    public override double Cost()
    {
        return 1.05;
    }
}

public abstract class CondimentDecorator : Beverage
{
    protected Beverage beverage;

    public CondimentDecorator(Beverage beverage)
    {
        this.beverage = beverage;
    }

    public abstract override string GetDescription();
}

public class Milk : CondimentDecorator
{
    public Milk(Beverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Milk";
    }

    public override double Cost()
    {
        return beverage.Cost() + 0.10;
    }
}

public class Mocha : CondimentDecorator
{
    public Mocha(Beverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Mocha";
    }

    public override double Cost()
    {
        return beverage.Cost() + 0.20;
    }
}

public class Soy : CondimentDecorator
{
    public Soy(Beverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Soy";
    }

    public override double Cost()
    {
        return beverage.Cost() + 0.15;
    }
}

public class Whip : CondimentDecorator
{
    public Whip(Beverage beverage) : base(beverage) { }

    public override string GetDescription()
    {
        return beverage.GetDescription() + ", Whip";
    }

    public override double Cost()
    {
        return beverage.Cost() + 0.10;
    }
}

public class StarbuzzCoffee
{
    public static void Run()
    {
        Beverage espresso = new Espresso();
        Console.WriteLine($"{espresso.GetDescription()} ${espresso.Cost():0.00}");

        Beverage darkRoast = new DarkRoast();
        darkRoast = new Mocha(darkRoast);
        darkRoast = new Mocha(darkRoast);
        darkRoast = new Whip(darkRoast);
        Console.WriteLine($"{darkRoast.GetDescription()} ${darkRoast.Cost():0.00}");

        Beverage houseBlend = new HouseBlend();
        houseBlend = new Soy(houseBlend);
        houseBlend = new Mocha(houseBlend);
        houseBlend = new Whip(houseBlend);
        Console.WriteLine($"{houseBlend.GetDescription()} ${houseBlend.Cost():0.00}");
    }
}
