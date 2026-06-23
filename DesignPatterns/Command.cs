namespace Redexpress.DesignPatterns;

public interface ICommand
{
    void Execute();
}

public class Light
{
    public void On() {
        Console.WriteLine("light is ON");
    }
}

public class LightOnCommand(Light light) : ICommand
{
    public void Execute()
    {
        light.On();
    }
}

public class NoCommand: ICommand
{
    public void Execute() { }
}

public class SimpleRemoteControl
{
    ICommand slot = new NoCommand();
    public SimpleRemoteControl() { }
    public void SetCommand(ICommand command)
    {
        slot = command;
    }
    public void ButtonWasPressed()
    {
        slot.Execute();
    }
}

public class RemoteControlTest
{
    public static void Run()
    {
        var remote = new SimpleRemoteControl();
        var light = new Light();
        var lightOn = new LightOnCommand(light);
        remote.SetCommand(lightOn);
        remote.ButtonWasPressed();
    }
}
