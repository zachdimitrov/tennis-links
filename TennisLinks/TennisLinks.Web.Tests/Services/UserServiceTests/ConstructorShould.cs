using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Return_UserService_Instance_WhenParametersSetCorrectly()
        {
            // Arrange
            var usersRepoMock = new Mock<IEfRepository<User>>();
            var uowMock = new Mock<ISaveContext>();

            // Act
            var userService = new UserService(usersRepoMock.Object, uowMock.Object);

            // Assert
            Assert.IsNotNull(userService);
        }
    }
}
