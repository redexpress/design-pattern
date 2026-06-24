using Redexpress.DesignPatterns;
using Redexpress.DesignPatterns.AbstractFactory;
using Redexpress.DesignPatterns.Platform;
using Rexexpress.DesignPatterns;
void DemoSingleton()
{
    PrintCaption("Singleton");
    var s1 = Singleton.Instance;
    var s2 = Singleton.Instance;

    Console.WriteLine(ReferenceEquals(s1, s2));
}

void PrintLine() => Console.WriteLine("----------------------------------------");
void PrintCaption(string caption) => Console.WriteLine($"=================== {caption} ====================================");

void DemoStragegy()
{
    PrintCaption("Stragegy");
    Duck mallard = new MallardDuck();
    mallard.PerformQuack();
    mallard.PerformFly();
    PrintLine();
    Duck model = new ModelDuck();
    model.PerformFly();
    model.SetFlyBehavior(new FlyRocketPowered());
    model.PerformFly();
}

void DemoObserver()
{
    PrintCaption("Observer");
    Redexpress.DesignPatterns.WeatherStation.Run();
}

void DemoDecorator()
{
    PrintCaption("Decorator");
    StarbuzzCoffee.Run();
    PrintLine();
    Redexpress.DesignPatterns.Platform.InputTest.Run();
}

void DemoAdatper()
{
    PrintCaption("Adapter");
    DuckTestDrive.Run();
}

void DemoIterator()
{
    PrintCaption("Iterator");
    MenuTestDrive.Run();
}

void DemoBuilder()
{
    PrintCaption("Builder");
    BuiderTest.Run();
}

void DemoFactory()
{
    PrintCaption("SimpleFactory");
    SimpleFactoryTest.Run();
    PrintCaption("FactoryMethod");
    PizzaTestDriver.Run();
    PrintCaption("AbstractFactory");
    AbstractPizzaTestDriver.Run();
}

void DemoCommand()
{
    PrintCaption("Command");
    RemoteControlTest.Run();
}

void DemoTemplateMethod() {
    PrintCaption("TemplateMethod");
    BeverageTestDrive.Run();
    PrintLine();
    Console.WriteLine("sort implement IComparable is template method pattern");
    SortDemo.Run();
}

void DemoState()
{
    PrintCaption("State");
    GumballMachineTest.Run();
}

DemoSingleton();
DemoStragegy();
DemoObserver();
DemoDecorator();
DemoAdatper();
DemoIterator();
DemoBuilder();
DemoFactory();
DemoCommand();
DemoTemplateMethod();
DemoState();