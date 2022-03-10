namespace PlayDotNet.WeatherForecastModule;

public class WeatherForecast
{
    public WeatherForecast()
    {
    }

    public WeatherForecast(DateTime date, string? summary, int temperatureC)
    {
        Date = date;
        Summary = summary;
        TemperatureC = temperatureC;
    }

    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}