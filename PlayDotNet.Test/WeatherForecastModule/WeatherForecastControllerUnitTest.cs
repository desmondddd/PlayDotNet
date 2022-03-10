using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlayDotNet.WeatherForecastModule;

namespace PlayDotNet.Test.WeatherForecastModule;

[TestClass]
public class WeatherForecastControllerUnitTest
{
    private static readonly Mock<ILogger<WeatherForecastController>> Logger = new();
    private static readonly Mock<IWeatherForecastService> WeatherForecastService = new();

    private readonly WeatherForecastController _weatherForecastController =
        new WeatherForecastController(Logger.Object, WeatherForecastService.Object);

    [TestInitialize]
    public void SetUp()
    {
        Logger.Reset();
        WeatherForecastService.Reset();
    }

    [TestMethod]
    public async Task GetShouldWork()
    {
        // Given
        var expected = new List<WeatherForecast>
        {
            new(date: DateTime.Now, summary: "s1", temperatureC: 10)
        }.AsEnumerable();

        WeatherForecastService.Setup(it => it.Get()).Returns(Task.FromResult(expected));

        // When
        var actual = await _weatherForecastController.Get();

        // Then
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public async Task GetShouldWorkWhenException()
    {
        // Given
        WeatherForecastService.Setup(it => it.Get()).Throws(new Exception("Error"));

        // When
        var actual = await Assert.ThrowsExceptionAsync<Exception>(async () => await _weatherForecastController.Get());
        
        // Then
        Assert.AreEqual("Error", actual.Message);
    }
}