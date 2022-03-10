using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlayDotNet.DdModule;

namespace PlayDotNet.Test.DbModule;

[TestClass]
public class DbServiceUnitTest
{
    private static readonly Mock<IDbRepository> Repository = new Mock<IDbRepository>();
    private readonly DbService _dbService = new DbService(Repository.Object);

    [TestInitialize]
    public void SetUp()
    {
       Repository.Reset(); 
    }

    [TestMethod]
    public async Task GetFromDbShouldWorkWhenYes()
    {
        // Given
        var expected = Enumerable.Range(1, 5);

        // When
        Repository.Setup(it => it.TouchDb())
            .Returns(Task.FromResult(expected));
        var actual = await _dbService.GetFromDb(true);

        // Then
        Assert.AreEqual(expected, actual);
        Repository.Verify(it => it.TouchDb(), Times.Once);
    }

    [TestMethod]
    public async Task GetFromDbShouldWorkWhenNo()
    {
        // Arrange

        // Act
        var actual = await _dbService.GetFromDb(false);

        // Assert
        Assert.AreEqual(null, actual);
        Repository.Verify(it => it.TouchDb(), Times.Never);
    }
}