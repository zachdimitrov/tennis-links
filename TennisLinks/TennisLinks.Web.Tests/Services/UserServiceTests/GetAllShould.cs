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
    class GetAllShould
    {
        [Test]
        public void ReturnProper_User_Collection()
        {
            // Arrange
            var usersRepoMock = new Mock<IEfRepository<User>>();
            var uowMock = new Mock<ISaveContext>();

            IEnumerable<User> collection = new List<User>();
            usersRepoMock.Setup(u => u.All).Returns(() =>
            {
                return collection.AsQueryable();
            });

            var userService = new UserService(usersRepoMock.Object, uowMock.Object);

            // Act
            IEnumerable<User> users = userService.GetAll();

            // Assert
            Assert.That(users, Is.EqualTo(collection));
        }
    }
}
