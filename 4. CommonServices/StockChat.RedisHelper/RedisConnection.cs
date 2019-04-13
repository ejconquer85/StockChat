using System;
using System.Collections.Generic;
using ServiceStack.Messaging.Redis;
using ServiceStack.Redis;
using StockChat.Entities;

namespace StockChat.RedisHelper
{
    public class RedisConnection
    {
        
                private readonly RedisManagerPool _manager;
                
                public RedisConnection(string redisServer)
                {
                    _manager = new RedisManagerPool(redisServer);
                }
        
               
        

        public void SendMessage(string message)
        {
            using (var client = _manager.GetClient())
            {
                client.Db = 0;
                client.PushItemToList("Stock",message);
        
            }
        }

        public string ReceiveMessage()
        {
            using (var client = _manager.GetClient())
            {
                client.Db = 0;
                return client.PopItemFromList("Stock");

            }
        }


    }
}
