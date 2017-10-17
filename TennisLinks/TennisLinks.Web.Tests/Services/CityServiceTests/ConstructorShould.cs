using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.CitySericeTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Return_CityService_Instance_WhenParametersSetCorrectly()
        {
            // Arrange
            var citiesRepoMock = new Mock<IEfRepository<City>>();
            var uowMock = new Mock<ISaveContext>();

            // Act
            var cityService = new CityService(citiesRepoMock.Object, uowMock.Object);

            // Assert
            Assert.IsNotNull(cityService);
        }
    }
}
