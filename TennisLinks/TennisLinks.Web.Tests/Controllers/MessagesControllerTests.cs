using Moq;
using NUnit.Framework;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace TennisLinks.Web.Tests.Controllers
{
    [TestFixture]
    class MessagesControllerTests
    {
        [Test]
        public void All_ShouldReturn_DefaultView()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var messageServiceMock = new Mock<IMessageService>();

            // Act
            var controllerUT = new MessagesController(userServiceMock.Object, messageServiceMock.Object);

            controllerUT.WithCallTo(x => x.All())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void Constructor_Should_ReturnCorrect_MessagesController_Instance_WhenParametersPassed()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var messageServiceMock = new Mock<IMessageService>();

            // Act
            var controllerUT = new MessagesController(userServiceMock.Object, messageServiceMock.Object);
            // Assert
            Assert.IsNotNull(controllerUT);
        }

        [Test]
        public void ClubValidationFailure_Should_Return_CorrectFailureDescription()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var messageServiceMock = new Mock<IMessageService>();

            // Act
            var controllerUT = new MessagesController(userServiceMock.Object, messageServiceMock.Object);

            var failure = controllerUT.MessageValidationFailure();

            // Assert
            Assert.AreEqual(failure.StatusDescription, "Validation failed! Message was not sent!");
        }
    }
}
