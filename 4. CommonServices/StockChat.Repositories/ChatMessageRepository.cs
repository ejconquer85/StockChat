using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockChat.Entities;

namespace StockChat.Repository
{
    public class ChatMessageRepository : GenericRepository<ChatMessage>, IChatMessageRepository
    {
        public IEnumerable<ChatMessage> GetTop(int top)
        {
            return  DbContext.Messages.OrderBy(c => c.TimeStamp).Take(top);
        }
    }
}