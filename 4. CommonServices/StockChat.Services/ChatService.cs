using StockChat.Entities;
using StockChat.Repository;

namespace StockChat.Services
{
    public class ChatService : GenericService<ChatMessage>, IChatService
    {
        public ChatService(IChatMessageRepository  entityRepository) : base(entityRepository)
        {
        }
    }
}