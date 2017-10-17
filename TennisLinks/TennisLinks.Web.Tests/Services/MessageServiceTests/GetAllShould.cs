using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.MessageSericeTests
{
    [TestFixture]
    public class GetAllShould
    {
        [Test]
        public void ReturnProper_Message_Collection()
        {
            // Arrange
            var messagesRepoMock = new Mock<IEfRepository<Message>>();
            var uowMock = new Mock<ISaveContext>();

            IEnumerable<Message> collection = new List<Message>();
            messagesRepoMock.Setup(c => c.All).Returns(() =>
            {
                return collection.AsQueryable();
            });

            var messageService = new MessageService(messagesRepoMock.Object, uowMock.Object);

            // Act
            IEnumerable<Message> messages = messageService.GetAll();

            // Assert
            Assert.That(messages, Is.EqualTo(collection));
        }
    }
}
