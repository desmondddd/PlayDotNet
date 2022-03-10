namespace PlayDotNet.WeatherForecastModule;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> Get();
}