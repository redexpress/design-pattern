using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redexpress.DesignPatterns;

public interface IState
{
    void InsertQuarter();
    void EjectQuarter();
    void TurnCrank();
    void Dispense();
}

public class GumballMachine
{
    public IState SoldOutState { get; }
    public IState NoQuarterState { get; }
    public IState HasQuarterState { get; }
    public IState SoldState { get; }

    public IState State { get; set; }

    public int Count { get; private set; }

    public GumballMachine(int count)
    {
        SoldOutState = new SoldOutState(this);
        NoQuarterState = new NoQuarterState(this);
        HasQuarterState = new HasQuarterState(this);
        SoldState = new SoldState(this);

        Count = count;
        State = count > 0 ? NoQuarterState : SoldOutState;
    }

    public void InsertQuarter()
    {
        State.InsertQuarter();
    }

    public void EjectQuarter()
    {
        State.EjectQuarter();
    }

    public void TurnCrank()
    {
        State.TurnCrank();
        State.Dispense();
    }

    public void ReleaseBall()
    {
        Console.WriteLine("A gumball comes rolling out...");
        Count--;
    }
}

public class NoQuarterState : IState
{
    private readonly GumballMachine machine;

    public NoQuarterState(GumballMachine machine)
    {
        this.machine = machine;
    }

    public void InsertQuarter()
    {
        Console.WriteLine("You inserted a quarter.");
        machine.State = machine.HasQuarterState;
    }

    public void EjectQuarter()
    {
        Console.WriteLine("You haven't inserted a quarter.");
    }

    public void TurnCrank()
    {
        Console.WriteLine("You turned, but there's no quarter.");
    }

    public void Dispense()
    {
        Console.WriteLine("You need to pay first.");
    }
}

public class HasQuarterState : IState
{
    private readonly GumballMachine machine;

    public HasQuarterState(GumballMachine machine)
    {
        this.machine = machine;
    }

    public void InsertQuarter()
    {
        Console.WriteLine("You can't insert another quarter.");
    }

    public void EjectQuarter()
    {
        Console.WriteLine("Quarter returned.");
        machine.State = machine.NoQuarterState;
    }

    public void TurnCrank()
    {
        Console.WriteLine("You turned...");
        machine.State = machine.SoldState;
    }

    public void Dispense()
    {
        Console.WriteLine("No gumball dispensed.");
    }
}

public class SoldState : IState
{
    private readonly GumballMachine machine;

    public SoldState(GumballMachine machine)
    {
        this.machine = machine;
    }

    public void InsertQuarter()
    {
        Console.WriteLine("Please wait, we're already giving you a gumball.");
    }

    public void EjectQuarter()
    {
        Console.WriteLine("Sorry, you already turned the crank.");
    }

    public void TurnCrank()
    {
        Console.WriteLine("Turning twice doesn't get another gumball.");
    }

    public void Dispense()
    {
        machine.ReleaseBall();

        if (machine.Count > 0)
            machine.State = machine.NoQuarterState;
        else
        {
            Console.WriteLine("Oops, out of gumballs!");
            machine.State = machine.SoldOutState;
        }
    }
}

public class SoldOutState : IState
{
    private readonly GumballMachine machine;

    public SoldOutState(GumballMachine machine)
    {
        this.machine = machine;
    }

    public void InsertQuarter()
    {
        Console.WriteLine("Machine is sold out.");
    }

    public void EjectQuarter()
    {
        Console.WriteLine("You can't eject, you haven't inserted a quarter.");
    }

    public void TurnCrank()
    {
        Console.WriteLine("You turned, but there are no gumballs.");
    }

    public void Dispense()
    {
        Console.WriteLine("No gumball dispensed.");
    }
}

public class GumballMachineTest
{
    public static void Run()
    {
        var machine = new GumballMachine(2);

        machine.InsertQuarter();
        machine.TurnCrank();

        Console.WriteLine();

        machine.InsertQuarter();
        machine.TurnCrank();

        Console.WriteLine();

        machine.InsertQuarter();
    }
}