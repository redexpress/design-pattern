namespace Redexpress.DesignPatterns;

public class User
{
    public string Name { get; set; } = "";
    public int Age { get; set; }

    public User WithName(string name)
    {
        this.Name = name;
        return this;
    }

    public User WithAge(int age)
    {
        this.Age = age;
        return this;
    }
}

public class Box
{
    public int Size { get; set; } = 0;
    public string Color { get; set; } = "";
    public static BoxBuilder Builder() => new();

    public class BoxBuilder
    {
        private readonly Box box = new();

        public BoxBuilder Size(int size)
        {
            box.Size = size;
            return this;
        }

        public BoxBuilder Color(string color)
        {
            box.Color = color;
            return this;
        }

        public Box Build() => box;
    }
}

public record Student(string Name, int Age);

public record Person
{
    public string Name { get; init; } = "";
    public int Age { get; init; }
}

public class BuiderTest
{
    public static void Run()
    {
        // fluent setter
        var user = new User().WithName("Yang").WithAge(18);
        Console.WriteLine(user.Name);

        // GoF builder
        var box = Box.Builder().Size(2).Color("Blue").Build();
        Console.WriteLine(box.Color);

        // record
        var student = new Student("Yang", 18);
        Console.WriteLine(student.Name);
        var person = new Person { Name = "Yang", Age = 18 };
        Console.WriteLine(person.Name);
    }
}
