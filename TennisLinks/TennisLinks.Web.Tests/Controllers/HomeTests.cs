using Moq;
using NUnit.Framework;
using System.Linq;
using System.Web.Mvc;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Controllers;

namespace TennisLinks.Web.Tests.Controllers.HomeTests
{
    [SetUpFixture]
    class IndexShould
    {
        private Mock<IUserService> userServiceMock;
        private Mock<IFavoriteService> favServiceMock;

        [SetUp]
        public void Initialize()
        {
            this.userServiceMock = new Mock<IUserService>();
            this.favServiceMock = new Mock<IFavoriteService>();
        }

        [Test]
        public void ReturnCorrect_Index_View()
        {
            // Arrange
            var controllerUT = new HomeController(userServiceMock.Object, favServiceMock.Object);

            userServiceMock.Setup(u => u.GetAll()).Returns(It.IsAny<IQueryable<User>>());

            // Act
            var result = controllerUT.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [Test]
        public void ReturnCorrect_About_View()
        {
            // Arrange
            var controllerUT = new HomeController(userServiceMock.Object, favServiceMock.Object);

            userServiceMock.Setup(u => u.GetAll()).Returns(It.IsAny<IQueryable<User>>());

            // Act
            var result = controllerUT.About() as ViewResult;

            // Assert
            Assert.AreEqual("About", result.ViewName);
        }

        [Test]
        public void ReturnCorrect_Contact_View()
        {
            // Arrange
            var controllerUT = new HomeController(userServiceMock.Object, favServiceMock.Object);

            userServiceMock.Setup(u => u.GetAll()).Returns(It.IsAny<IQueryable<User>>());

            // Act
            var result = controllerUT.Contact() as ViewResult;

            // Assert
            Assert.AreEqual("Contact", result.ViewName);
        }
    }
}
