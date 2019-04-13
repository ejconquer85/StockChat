using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using StockChat.RedisHelper;

namespace StockChat.Bot
{
    class Program
    {

        static void SendMessage(string messageTosend)
        {
            try
            {
                var connection = new HubConnectionBuilder()
                    .WithUrl("http://localhost:5005/signalr")
                    .Build();

                
                    connection.StartAsync().Wait();
                    connection.InvokeAsync("Send","Bot", messageTosend).Wait();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        static string GetCSV(string url)
        {
            var req = (HttpWebRequest)WebRequest.Create(url);
            var resp = (HttpWebResponse)req.GetResponse();

            var sr = new StreamReader(resp.GetResponseStream());

            var result = string.Empty;

            var results = new List<string>();

            do
            {
                result = sr.ReadLine();

                if (!string.IsNullOrEmpty(result))
                    results.Add(result);

            } while (!string.IsNullOrEmpty(result));
            sr.Close();

            return results[1];
        } 
        
        static string GetStock(string stockToGet)
        {
            var url  = "https://stooq.com/q/l/?s=[stock]&f=sd2t2ohlcv&h&e=csv";

            url = url.Replace("[stock]", stockToGet);

            var csvText = GetCSV(url);

            var valuesLine = csvText.Split(',')[4];

            return valuesLine;


        }

        static void Main(string[] args)
        {
            var connection = new RedisConnection("localhost:6379");

            while (true)
            {
               var message = connection.ReceiveMessage();

               var messageSplitted = message?.Split('=');

               if (messageSplitted is null || messageSplitted.Length < 2)
               {
                   Thread.Sleep(100);
                   continue;
               }

               var stockToGet = messageSplitted[1];

               var stockPrice = GetStock(stockToGet);
               
               SendMessage($"{stockToGet.ToUpper()} quote is ${stockPrice} per share");
            }


        }
    }
}
