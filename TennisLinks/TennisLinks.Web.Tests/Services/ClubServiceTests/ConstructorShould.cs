using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

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
            var uowMock = new Mock<ISaveContext>();

            // Act
            var clubService = new ClubService(clubsRepoMock.Object, uowMock.Object);

            // Assert
            Assert.IsNotNull(clubService);
        }
    }
}
