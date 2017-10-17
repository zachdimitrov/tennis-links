using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.UserServiceTests
{
    [TestFixture]
    class GetByIdShould
    {
        // convertion with AsQueryable() creates empty collection
        // anyway: https://stackoverflow.com/a/6647305
        // not testing the real implementation - in case of EF mocking sets is stupid approach because once you do it you change linq-to-entities to linq-to-objects. Those two are totally different and linq-to-entities is only small subset of linq-to-objects = your unit tests can pass with linq-to-objects but your code will fail at runtime.

        [Test]
        public void Return_null_if_Empty_Collection()
        {
            // Arrange
            var usersRepoMock = new Mock<IEfRepository<User>>();
            var uowMock = new Mock<ISaveContext>();
            User user = new UserMock { Id = "test" };

            IEnumerable<User> collection = new List<User>() { user };

            usersRepoMock.Setup(u => u.All).Returns(collection.AsQueryable());

            var userService = new UserService(usersRepoMock.Object, uowMock.Object);

            // Act
            User result = userService.GetById("test");

            // Assert
            Assert.That(result, Is.EqualTo(null));
        }
    }
}
