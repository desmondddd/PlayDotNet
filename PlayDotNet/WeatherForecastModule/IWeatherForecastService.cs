namespace PlayDotNet.WeatherForecastModule;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> Get();
}