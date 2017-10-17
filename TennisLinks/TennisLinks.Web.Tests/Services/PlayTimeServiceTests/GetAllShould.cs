using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.PlayTimeSericeTests
{
    [TestFixture]
    public class GetAllShould
    {
        [Test]
        public void ReturnProper_PlayTime_Collection()
        {
            // Arrange
            var playTimesRepoMock = new Mock<IEfRepository<PlayTime>>();
            var uowMock = new Mock<ISaveContext>();

            IEnumerable<PlayTime> collection = new List<PlayTime>();
            playTimesRepoMock.Setup(c => c.All).Returns(() =>
            {
                return collection.AsQueryable();
            });

            var playTimeService = new PlayTimeService(playTimesRepoMock.Object, uowMock.Object);

            // Act
            IEnumerable<PlayTime> playTimes = playTimeService.GetAll();

            // Assert
            Assert.That(playTimes, Is.EqualTo(collection));
        }
    }
}
