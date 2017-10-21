using AutoMapper;
using Moq;
using NUnit.Framework;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Areas.Administration.Controllers;

namespace TennisLinks.Web.Tests.Controllers.AdministrationTests
{
    [TestFixture]
    public class AdministrationControllerTests
    {
        [Test]
        public void Constructor_Should_ReturnCorrect_UsersAdministrationController_Instance_WhenParametersPassed()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var cityServiceMock = new Mock<ICityService>();
            var clubServiceMock = new Mock<IClubService>();

            // Act
            var controllerUT = new ManageItemsDetailsController(
                userServiceMock.Object,
                cityServiceMock.Object,
                clubServiceMock.Object);

            // Assert
            Assert.IsNotNull(controllerUT);
        }
    }
}
