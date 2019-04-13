using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using StockChat.Entities;

namespace StockChat.Repository
{
    public interface IChatMessageRepository :IGenericRepository<ChatMessage>
    {

        IEnumerable<ChatMessage> GetTop(int top);

    }
}