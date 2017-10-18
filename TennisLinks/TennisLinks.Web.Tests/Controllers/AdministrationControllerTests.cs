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
            var mapperMock = new Mock<IMapper>();

            // Act
            var controllerUT = new ManageUserDetailsController(userServiceMock.Object, mapperMock.Object);

            // Assert
            Assert.IsNotNull(controllerUT);
        }

        [Test]
        public void ReturnCorrect_View()
        {
            //// Arrange
            //var userServiceMock = new Mock<IUserService>();
            //var mapperMock = new Mock<IMapper>();

            //var controllerUT = new ManageUserDetailsController(userServiceMock.Object, mapperMock.Object);

            //mapperMock.Setup(m => m.Map<object>(It.IsAny<object>())).Verifiable();
            //userServiceMock.Setup(u => u.GetAll()).Returns(It.IsAny<IQueryable<User>>());

            //// Act
            //var result = controllerUT.Index() as ViewResult;

            //// Assert
            //Assert.AreEqual("Index", result.ViewName);
        }
    }
}
