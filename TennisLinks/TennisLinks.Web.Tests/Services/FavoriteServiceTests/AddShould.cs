﻿using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.FavoritesSericeTests
{
    [TestFixture]
    public class AddShould
    {
        [Test]
        public void ReturnProper_AddFavorite_ResultFromCommitMethod()
        {
            // Arrange
            var favoritesRepoMock = new Mock<IEfRepository<Favorite>>();
            var uowMock = new Mock<ISaveContext>();

            favoritesRepoMock.Setup(c => c.Add(It.IsAny<Favorite>())).Verifiable();
            uowMock.Setup(u => u.Commit()).Returns(1);

            var favoriteService = new FavoriteService(favoritesRepoMock.Object, uowMock.Object);

            // Act
            var result = favoriteService.Add(It.IsAny<Favorite>());

            // Assert
            Assert.That(result.Equals(1));
        }
    }
}
