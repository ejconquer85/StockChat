using System;
using System.Collections.Generic;
using ServiceStack.Messaging.Redis;
using ServiceStack.Redis;
using StockChat.Entities;

namespace StockChat.RedisHelper
{
    public class RedisConnection
    {
        RedisMqServer _mqHost; 

        public RedisConnection(string redisServer)
        {
            var redisFactory = new PooledRedisClientManager(redisServer);

            _mqHost = new RedisMqServer(redisFactory, 2);
        }

        public void SendMessage(string message)
        {
            _mqHost.RegisterHandler<string>(m => message);
            _mqHost.Start();
        }

        public string ReceiveMessage()
        {
            var message = string.Empty;
            _mqHost.RegisterHandler<string>(m =>
            {
                message = m.GetBody();
                return message;
            });
            _mqHost.Start();
            return message;
        }


    }
}
