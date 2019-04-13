using System;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Serialization;
using StockChat.Entities;
using StockChat.Services;

namespace StockChat.Controllers
{
    public class ChatHub : Hub
    {
        
        private readonly IChatService _chatService;
        
        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public void SendToAll(string userName, string message)
        {
            var chatMessage = new ChatMessage {TimeStamp = DateTime.Now, Message = message, User = userName};

            _chatService.InsertAsync(chatMessage);

            Clients.All.SendAsync("sendToAll", userName, message);
        }
    }
}