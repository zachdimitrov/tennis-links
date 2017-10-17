using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.MessageSericeTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void Return_MessageService_Instance_WhenParametersSetCorrectly()
        {
            // Arrange
            var messagesRepoMock = new Mock<IEfRepository<Message>>();
            var uowMock = new Mock<ISaveContext>();

            // Act
            var messageService = new MessageService(messagesRepoMock.Object, uowMock.Object);

            // Assert
            Assert.IsNotNull(messageService);
        }
    }
}
