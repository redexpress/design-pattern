
using System.Runtime.Serialization;

namespace Redexpress.DesignPatterns;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public interface IObserver
{
    void Update(float temp, float humidity, float pressure);
}

public interface IDisplay
{
    void Display();
}


public class WeatherData : ISubject
{
    private readonly List<IObserver> observers = [];
    private float temperature;
    private float humidity;
    private float pressure;

    public void NotifyObservers()
    {
        foreach (var observer in observers.ToArray())
        {
            observer.Update(temperature, humidity, pressure);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            return;
        }
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void MeasurementsChanged() => NotifyObservers();

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;
        MeasurementsChanged();
    }
}

public class CurrentConditionsDisplay : IObserver, IDisplay, System.IDisposable
{
    private float temperature;
    private float humidity;
    private ISubject weatherData;
    public CurrentConditionsDisplay(ISubject weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }

    public void Display()
    {
        Console.WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity");
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }

    public void Dispose()
    {
        weatherData.RemoveObserver(this);
    }
}

public class StatisticsDisplay : IObserver, IDisplay, System.IDisposable
{
    private float temperature;
    private ISubject weatherData;

    public StatisticsDisplay(ISubject weatherData)
    {
        this.weatherData = weatherData;
        weatherData.RegisterObserver(this);
    }
    public void Display()
    {
         Console.WriteLine($"Avg/Max/Min temperature = {temperature}/{temperature}/{temperature}");
    }

    public void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        Display();
    }

    public void Dispose()
    {
        weatherData.RemoveObserver(this);
    }
}

public class WeatherStation
{
    public static void Run()
    {
        var weatherData = new WeatherData();
        using var display = new CurrentConditionsDisplay(weatherData);
        using var stat = new StatisticsDisplay(weatherData);
        weatherData.SetMeasurements(80, 65, 30.4f);
        weatherData.SetMeasurements(82, 70, 29.2f);
    }
}

