using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redexpress.DesignPatterns.Principles.Solid;

public interface IFlyBehavior
{
    void Fly();
}

public interface IQuackBehavior
{
    void Quack();
}

public sealed class FlyWithWings : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I'm flying!");
}

public sealed class FlyNoWay : IFlyBehavior
{
    public void Fly() { }
}

public sealed class NormalQuack : IQuackBehavior
{
    public void Quack() => Console.WriteLine("Quack");
}

public abstract class Duck
{
    protected IFlyBehavior FlyBehavior = null!;
    protected IQuackBehavior QuackBehavior = null!;

    public void PerformFly() => FlyBehavior.Fly();
    public void PerformQuack() => QuackBehavior.Quack();

    public void SetFlyBehavior(IFlyBehavior flyBehavior) => FlyBehavior = flyBehavior;
    public void SetQuackBehavior(IQuackBehavior quackBehavior) => QuackBehavior = quackBehavior;

    public abstract void Display();
}

public sealed class MallardDuck : Duck
{
    public MallardDuck()
    {
        FlyBehavior = new FlyWithWings();
        QuackBehavior = new NormalQuack();
    }

    public override void Display() => Console.WriteLine("I'm a real Mallard duck.");
}