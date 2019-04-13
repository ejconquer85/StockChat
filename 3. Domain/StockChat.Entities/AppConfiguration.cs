using System;
namespace StockChat.Entities
{
    public class AppConfiguration
    {
        public string SiteUrl { get; set; }
        public string Key { get; set; }
        public string RedisServer { get; set; }
        public string RedisDb { get; set; }
    }
}
