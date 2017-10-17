using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.CitySericeTests
{
    [TestFixture]
    public class GetAllShould
    {
        [Test]
        public void ReturnProper_City_Collection()
        {
            // Arrange
            var citiesRepoMock = new Mock<IEfRepository<City>>();
            var uowMock = new Mock<ISaveContext>();

            IEnumerable<City> collection = new List<City>();
            citiesRepoMock.Setup(c => c.All).Returns(() =>
            {
                return collection.AsQueryable();
            });

            var cityService = new CityService(citiesRepoMock.Object, uowMock.Object);

            // Act
            IEnumerable<City> cities = cityService.GetAll();

            // Assert
            Assert.That(cities, Is.EqualTo(collection));
        }
    }
}
