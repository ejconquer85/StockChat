using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using StockChat.Entities;
using StockChat.RedisHelper;
using StockChat.Services;

namespace StockChat.Controllers
{
    public class ChatHub : Hub
    {
        
        private readonly IChatService _chatService;
        private readonly IOptions<AppConfiguration> _appConfiguration;

        
        public ChatHub(IChatService chatService, IOptions<AppConfiguration> appConfiguration)
        {
            _chatService = chatService;
            _appConfiguration = appConfiguration;
        }

        public void Send(string userName, string message)
        {
            var chatMessage = new ChatMessage {TimeStamp = DateTime.Now, Message = message, User = userName};

            if (message.StartsWith("/stock", StringComparison.Ordinal))
            {
                var connection = new RedisConnection(_appConfiguration.Value.RedisServer);
                
                connection.SendMessage(message);
            }
            else
            {
                
                _chatService.InsertAsync(chatMessage);

                Clients.All.SendAsync("send", userName, message);
            }

        }
    }
}