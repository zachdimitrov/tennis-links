using Moq;
using NUnit.Framework;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Controllers;

namespace TennisLinks.Web.Tests.Controllers
{
    [TestFixture]
    class FavoritesControllerTests
    {
        [Test]
        public void Constructor_Should_ReturnCorrect_FavoritesController_Instance_WhenParametersPassed()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var detailsServiceMock = new Mock<IDetailsService>();
            var favServiceMock = new Mock<IFavoriteService>();

            // Act
            var controllerUT = new FavoritesController(userServiceMock.Object, detailsServiceMock.Object, favServiceMock.Object);

            // Assert
            Assert.IsNotNull(controllerUT);
        }
    }
}
