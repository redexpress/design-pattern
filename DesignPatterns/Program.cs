using Redexpress.DesignPatterns;
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
    WeatherStation.Run();
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

DemoSingleton();
DemoStragegy();
DemoObserver();
DemoDecorator();
DemoAdatper();
DemoIterator();
DemoBuilder();