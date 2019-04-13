using StockChat.Entities;
using StockChat.Repository;

namespace StockChat.Services
{
    public class ChatService : GenericService<ChatMessage>, IChatService
    {
        public ChatService(IGenericRepository<ChatMessage> entityRepository) : base(entityRepository)
        {
        }
    }
}