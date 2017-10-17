using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.DetailsSericeTests
{
    [TestFixture]
    public class GetAllShould
    {
        [Test]
        public void ReturnProper_Details_Collection()
        {
            // Arrange
            var detailsRepoMock = new Mock<IEfRepository<Details>>();
            var uowMock = new Mock<ISaveContext>();

            IEnumerable<Details> collection = new List<Details>();
            detailsRepoMock.Setup(c => c.All).Returns(() =>
            {
                return collection.AsQueryable();
            });

            var detailsService = new DetailsService(detailsRepoMock.Object, uowMock.Object);

            // Act
            IEnumerable<Details> details = detailsService.GetAll();

            // Assert
            Assert.That(details, Is.EqualTo(collection));
        }
    }
}
