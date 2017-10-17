using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Areas.Administration.Controllers;
using TennisLinks.Web.Areas.Administration.Models;

namespace TennisLinks.Web.Tests.Controllers.AdministrationTests
{
    [TestFixture]
    public class IndexShould
    {
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
