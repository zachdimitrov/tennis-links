using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.ClubSericeTests
{
    [TestFixture]
    public class UpdateShould
    {
        [Test]
        public void ReturnProper_UpdateClub_ResultFromCommitMethod()
        {
            // Arrange
            var clubsRepoMock = new Mock<IEfRepository<Club>>();
            var uowMock = new Mock<ISaveContext>();

            clubsRepoMock.Setup(c => c.Update(It.IsAny<Club>())).Verifiable();
            uowMock.Setup(u => u.Commit()).Returns(1);

            var clubService = new ClubService(clubsRepoMock.Object, uowMock.Object);

            // Act
            var result = clubService.Add(It.IsAny<Club>());

            // Assert
            Assert.That(result.Equals(1));
        }
    }
}
