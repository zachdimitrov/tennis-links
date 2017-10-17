using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.DetailsSericeTests
{
    [TestFixture]
    public class AddShould
    {
        [Test]
        public void ReturnProper_Details_ResultFromCommitMethod()
        {
            // Arrange
            var detailsRepoMock = new Mock<IEfRepository<Details>>();
            var uowMock = new Mock<ISaveContext>();

            detailsRepoMock.Setup(c => c.Add(It.IsAny<Details>())).Verifiable();
            uowMock.Setup(u => u.Commit()).Returns(1);

            var detailsService = new DetailsService(detailsRepoMock.Object, uowMock.Object);

            // Act
            var result = detailsService.Update(It.IsAny<Details>());

            // Assert
            Assert.That(result.Equals(1));
        }
    }
}
