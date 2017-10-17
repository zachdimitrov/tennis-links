using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.CitySericeTests
{
    [TestFixture]
    public class AddShould
    {
        [Test]
        public void ReturnProper_AddCity_ResultFromCommitMethod()
        {
            // Arrange
            var citiesRepoMock = new Mock<IEfRepository<City>>();
            var uowMock = new Mock<ISaveContext>();

            citiesRepoMock.Setup(c => c.Add(It.IsAny<City>())).Verifiable();
            uowMock.Setup(u => u.Commit()).Returns(1);

            var cityService = new CityService(citiesRepoMock.Object, uowMock.Object);

            // Act
            var result = cityService.Add(It.IsAny<City>());

            // Assert
            Assert.That(result.Equals(1));
        }
    }
}
