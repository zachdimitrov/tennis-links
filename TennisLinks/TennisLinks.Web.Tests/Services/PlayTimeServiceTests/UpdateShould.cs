using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.PlayTimeServiceTests
{
    [TestFixture]
    public class UpdateShould
    {
        [Test]
        public void ReturnProper_UpdatePlayTime_ResultFromCommitMethod()
        {
            // Arrange
            var playTimesRepoMock = new Mock<IEfRepository<PlayTime>>();
            var uowMock = new Mock<ISaveContext>();

            playTimesRepoMock.Setup(c => c.Update(It.IsAny<PlayTime>())).Verifiable();
            uowMock.Setup(u => u.Commit()).Returns(1);

            var playTimeService = new PlayTimeService(playTimesRepoMock.Object, uowMock.Object);

            // Act
            var result = playTimeService.Update(It.IsAny<PlayTime>());

            // Assert
            Assert.That(result.Equals(1));
        }
    }
}
