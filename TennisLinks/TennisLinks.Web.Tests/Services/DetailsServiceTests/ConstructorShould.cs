using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.DetailsServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Return_DetailsService_Instance_WhenParametersSetCorrectly()
        {
            // Arrange
            var detailsRepoMock = new Mock<IEfRepository<Details>>();
            var uowMock = new Mock<ISaveContext>();

            // Act
            var detailsService = new DetailsService(detailsRepoMock.Object, uowMock.Object);

            // Assert
            Assert.IsNotNull(detailsService);
        }
    }
}
