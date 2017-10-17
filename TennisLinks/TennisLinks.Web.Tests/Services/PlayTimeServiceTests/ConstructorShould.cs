using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.PlayTimeServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Return_PlayTimeService_Instance_WhenParametersSetCorrectly()
        {
            // Arrange
            var playTimesRepoMock = new Mock<IEfRepository<PlayTime>>();
            var uowMock = new Mock<ISaveContext>();

            // Act
            var playTimeService = new PlayTimeService(playTimesRepoMock.Object, uowMock.Object);

            // Assert
            Assert.IsNotNull(playTimeService);
        }
    }
}
