using NUnit.Framework;
using Moq;
using StockChat.Repository;
using StockChat.Services;

namespace Tests
{
    public class ChatServiceTests
    {
        private readonly IChatService _chatService;
        
        private readonly Mock<IChatMessageRepository> _chatMessageRepositoryMock = new Mock<IChatMessageRepository>();


        public ChatServiceTests()
        {
            _chatService = new ChatService(_chatMessageRepositoryMock.Object);
        }


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}