using Redexpress.DesignPatterns;
void demoSingleton()
{
    printCaption("Singleton");
    var s1 = Singleton.Instance;
    var s2 = Singleton.Instance;

    Console.WriteLine(ReferenceEquals(s1, s2));
}

void printLine() => Console.WriteLine("----------------------------------------");
void printCaption(string caption) => Console.WriteLine($"==== {caption} ====================================");

void demoStragegy()
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

void demoObserver()
{
    printCaption("Observer");
    WeatherStation.Run();
}

void demoDecorator()
{
    printCaption("Decorator");
    StarbuzzCoffee.Run();
}

demoSingleton();
demoStragegy();
demoObserver();
demoDecorator();