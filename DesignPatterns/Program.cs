using Redexpress.DesignPatterns;
void DemoSingleton()
{
    printCaption("Singleton");
    var s1 = Singleton.Instance;
    var s2 = Singleton.Instance;

    Console.WriteLine(ReferenceEquals(s1, s2));
}

void printLine() => Console.WriteLine("----------------------------------------");
void printCaption(string caption) => Console.WriteLine($"=================== {caption} ====================================");

void DemoStragegy()
{
    printCaption("Stragegy");
    Duck mallard = new MallardDuck();
    mallard.PerformQuack();
    mallard.PerformFly();
    printLine();
    Duck model = new ModelDuck();
    model.PerformFly();
    model.SetFlyBehavior(new FlyRocketPowered());
    model.PerformFly();
}

void DemoObserver()
{
    printCaption("Observer");
    WeatherStation.Run();
}

void DemoDecorator()
{
    printCaption("Decorator");
    StarbuzzCoffee.Run();
}

void DemoAdatper()
{
    printCaption("Adapter");
    DuckTestDrive.Run();
}

void DemoIterator()
{
    printCaption("Iterator");
    MenuTestDrive.Run();
}

DemoSingleton();
DemoStragegy();
DemoObserver();
DemoDecorator();
DemoAdatper();
DemoIterator();