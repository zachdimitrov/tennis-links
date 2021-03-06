﻿using Moq;
using NUnit.Framework;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services;

namespace TennisLinks.Web.Tests.Services.MessageSericeTests
{
    [TestFixture]
    public class DeleteShould
    {
        [Test]
        public void ReturnProper_DeleteMessage_ResultFromCommitMethod()
        {
            // Arrange
            var messagesRepoMock = new Mock<IEfRepository<Message>>();
            var uowMock = new Mock<ISaveContext>();

            messagesRepoMock.Setup(c => c.Delete(It.IsAny<Message>())).Verifiable();
            uowMock.Setup(u => u.Commit()).Returns(1);

            var messageService = new MessageService(messagesRepoMock.Object, uowMock.Object);

            // Act
            var result = messageService.Add(It.IsAny<Message>());

            // Assert
            Assert.That(result.Equals(1));
        }
    }
}
