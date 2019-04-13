using System;
using System.ComponentModel.DataAnnotations;

namespace StockChat.Entities
{
    public class ChatMessage
    {
        [Required]
        [Key]
        public int IdChatMessage { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }

        public string User { get; set; }
    }
}