using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.CitySericeTests
{
    [TestFixture]
    public class UpdateShould
    {
        [Test]
        public void ReturnProper_UpdateCity_ResultFromCommitMethod()
        {
            // Arrange
            var citiesRepoMock = new Mock<IEfRepository<City>>();
            var uowMock = new Mock<ISaveContext>();

            citiesRepoMock.Setup(c => c.Update(It.IsAny<City>())).Verifiable();
            uowMock.Setup(u => u.Commit()).Returns(1);

            var cityService = new CityService(citiesRepoMock.Object, uowMock.Object);

            // Act
            var result = cityService.Update(It.IsAny<City>());

            // Assert
            Assert.That(result.Equals(1));
        }
    }
}
