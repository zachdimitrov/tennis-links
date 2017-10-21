using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Web.Tests.Services.ClubSericeTests
{
    [TestFixture]
    public class GetAllShould
    {
        [Test]
        public void ReturnProper_Clubs_Collection()
        {
            // Arrange
            var clubsRepoMock = new Mock<IEfRepository<Club>>();
            var cityServiceMock = new Mock<ICityService>();
            var uowMock = new Mock<ISaveContext>();

            IEnumerable<Club> collection = new List<Club>();
            clubsRepoMock.Setup(c => c.All).Returns(() =>
            {
                return collection.AsQueryable();
            });

            var clubService = new ClubService(clubsRepoMock.Object, cityServiceMock.Object, uowMock.Object);

            // Act
            IEnumerable<Club> clubs = clubService.GetAll();

            // Assert
            Assert.That(clubs, Is.EqualTo(collection));
        }
    }
}
