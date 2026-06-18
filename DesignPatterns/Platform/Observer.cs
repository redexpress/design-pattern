using System;

namespace Redexpress.DesignPatterns.Platform;

public class WeatherData
{
    public event Action<float, float, float>? Changed;

    private float temperature;
    private float humidity;
    private float pressure;

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;

        Changed?.Invoke(temperature, humidity, pressure);
    }
}

public class CurrentConditionsDisplay : IDisposable
{
    private readonly WeatherData weatherData;

    private float temperature;
    private float humidity;

    public CurrentConditionsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.Changed += Update;
    }

    private void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Current conditions: {temperature}F degrees and {humidity}% humidity");
    }

    public void Dispose()
    {
        weatherData.Changed -= Update;
    }
}

public class StatisticsDisplay : IDisposable
{
    private readonly WeatherData weatherData;

    private float temperature;
    private float humidity;
    private float pressure;

    public StatisticsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.Changed += Update;
    }

    private void Update(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;

        Display();
    }

    public void Display()
    {
        Console.WriteLine($"Avg/Max/Min temperature = {temperature}/{temperature}/{temperature}");
    }

    public void Dispose()
    {
        weatherData.Changed -= Update;
    }
}

public class WeatherStation
{
    public static void Run()
    {
        var weatherData = new WeatherData();

        using var current = new CurrentConditionsDisplay(weatherData);
        using var stats = new StatisticsDisplay(weatherData);

        weatherData.SetMeasurements(80, 65, 30.4f);
        weatherData.SetMeasurements(82, 70, 29.2f);
    }
}