using Moq;
using NUnit.Framework;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Controllers;

namespace TennisLinks.Web.Tests.Controllers
{
    [TestFixture]
    class PlayerControllerTests
    {
        [Test]
        public void Constructor_Should_ReturnCorrect_PlayerController_Instance_WhenParametersPassed()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var detailsServiceMock = new Mock<IDetailsService>();
            var clubServiceMock = new Mock<IClubService>();
            var cityServiceMock = new Mock<ICityService>();
            var playTimeServiceMock = new Mock<IPlayTimeService>();

            // Act
            var controllerUT = new PlayerController(
                userServiceMock.Object, 
                detailsServiceMock.Object,
                clubServiceMock.Object,
                cityServiceMock.Object,
                playTimeServiceMock.Object);

            // Assert
            Assert.IsNotNull(controllerUT);
        }

        [Test]
        public void DetailsValidationFailure_Should_Return_CorrectFailureDescription()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var detailsServiceMock = new Mock<IDetailsService>();
            var clubServiceMock = new Mock<IClubService>();
            var cityServiceMock = new Mock<ICityService>();
            var playTimeServiceMock = new Mock<IPlayTimeService>();

            // Act
            var controllerUT = new PlayerController(
                userServiceMock.Object, 
                detailsServiceMock.Object,
                clubServiceMock.Object,
                cityServiceMock.Object,
                playTimeServiceMock.Object);

            var failure = controllerUT.DetailsValidationFailure();

            // Assert
            Assert.AreEqual(failure.StatusDescription, "User details validation failed");
        }

        [Test]
        public void ClubValidationFailure_Should_Return_CorrectFailureDescription()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var detailsServiceMock = new Mock<IDetailsService>();
            var clubServiceMock = new Mock<IClubService>();
            var cityServiceMock = new Mock<ICityService>();
            var playTimeServiceMock = new Mock<IPlayTimeService>();

            // Act
            var controllerUT = new PlayerController(
                userServiceMock.Object,
                detailsServiceMock.Object,
                clubServiceMock.Object,
                cityServiceMock.Object,
                playTimeServiceMock.Object);

            var failure = controllerUT.ClubValidationFailure("Pesho");

            // Assert
            Assert.AreEqual(failure.StatusDescription, "Club \"Pesho\" does not exist. Add it first.");
        }
    }
}