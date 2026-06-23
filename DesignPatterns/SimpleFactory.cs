using System.Runtime.CompilerServices;

namespace Redexpress.DesignPatterns;

public abstract class Operation
{
    public double NumberA { get; set; }
    public double NumberB { get; set; }
    public abstract double GetResult();
}

public class OperationAdd : Operation
{
    public override double GetResult() => NumberA + NumberB;
}

public class OperationSub : Operation
{
    public override double GetResult() => NumberA - NumberB;
}

public class OperationMul : Operation
{
    public override double GetResult() => NumberA * NumberB;
}

public class OperationDiv : Operation
{
    public override double GetResult()
    {
        if (NumberB == 0)
            throw new DivideByZeroException("Divide by Zero");
        return NumberA / NumberB;
    }
}

public static class OperationFactory
{
    public static Operation CreateOperate(string operate) => operate switch
    {
        "+" => new OperationAdd(),
        "-" => new OperationSub(),
        "*" => new OperationMul(),
        "/" => new OperationDiv(),
        _ => throw new NotSupportedException($"Unsupported operator: {operate}")
    };
}

public class SimpleFactoryTest
{
    public static void Run()
    {
        Operation oper = OperationFactory.CreateOperate("+");
        oper.NumberA = 1;
        oper.NumberB = 2;
        double result = oper.GetResult();
        Console.WriteLine($"operator('+', 1, 2) = {result}");
    }
}

