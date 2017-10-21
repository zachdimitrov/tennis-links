using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Web.Tests.Services.ClubSericeTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Return_ClubService_Instance_WhenParametersSetCorrectly()
        {
            // Arrange
            var clubsRepoMock = new Mock<IEfRepository<Club>>();
            var cityServiceMock = new Mock<ICityService>();
            var uowMock = new Mock<ISaveContext>();

            // Act
            var clubService = new ClubService(clubsRepoMock.Object, cityServiceMock.Object, uowMock.Object);

            // Assert
            Assert.IsNotNull(clubService);
        }
    }
}
