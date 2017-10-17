using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.FavoriteSericeTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Return_FavoriteService_Instance_WhenParametersSetCorrectly()
        {
            // Arrange
            var favoriteRepoMock = new Mock<IEfRepository<Favorite>>();
            var uowMock = new Mock<ISaveContext>();

            // Act
            var favoriteService = new FavoriteService(favoriteRepoMock.Object, uowMock.Object);

            // Assert
            Assert.IsNotNull(favoriteService);
        }
    }
}
