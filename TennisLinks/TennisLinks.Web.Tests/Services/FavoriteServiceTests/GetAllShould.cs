using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.FavoriteSericeTests
{
    [TestFixture]
    public class GetAllShould
    {
        [Test]
        public void ReturnProper_Favorite_Collection()
        {
            // Arrange
            var favoritesRepoMock = new Mock<IEfRepository<Favorite>>();
            var uowMock = new Mock<ISaveContext>();

            IEnumerable<Favorite> collection = new List<Favorite>();
            favoritesRepoMock.Setup(c => c.All).Returns(() =>
            {
                return collection.AsQueryable();
            });

            var favoriteService = new FavoriteService(favoritesRepoMock.Object, uowMock.Object);

            // Act
            IEnumerable<Favorite> favorites = favoriteService.GetAll();

            // Assert
            Assert.That(favorites, Is.EqualTo(collection));
        }
    }
}
