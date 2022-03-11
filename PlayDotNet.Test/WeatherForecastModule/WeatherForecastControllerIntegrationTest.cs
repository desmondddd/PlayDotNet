using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayDotNet.WeatherForecastModule;

namespace PlayDotNet.Test.WeatherForecastModule;

[TestClass]
public class WeatherForecastControllerIntegrationTest : AbstractIntegrationTest
{
    [TestMethod]
    public async Task WeatherForecastShouldWork()
    {
        var response = await Client.GetAsync("/weather-forecast");
        var actual = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

        Assert.AreEqual(5, actual?.ToList().Count);
        // Assert.AreEqual("Warm", actual.ToList()[0].Summary);
        // Assert.AreEqual(16, actual.ToList()[0].TemperatureC);
        // Assert.AreEqual(60, actual.ToList()[0].TemperatureF);
    }
}