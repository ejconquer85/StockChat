using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Microsoft.AspNet.SignalR.Client;
using StockChat.RedisHelper;

namespace StockChat.Bot
{
    class Program
    {

        static void SendMessage(string message)
        {
            var connection = new HubConnection("http://localhost:5005/chat");
            //Make proxy to hub based on hub name on server
            var myHub = connection.CreateHubProxy("CustomHub");
            //Start connection

            connection.Start().ContinueWith(task => {
                if (task.IsFaulted) {
                    Console.WriteLine("There was an error opening the connection:{0}",
                        task.Exception.GetBaseException());
                } else {
                    Console.WriteLine("Connected");
                }

            }).Wait();

            myHub.Invoke<string>("Send", "Bot",message).ContinueWith(task => {
                if (task.IsFaulted) {
                    Console.WriteLine("There was an error calling send: {0}",
                        task.Exception.GetBaseException());
                } else {
                    Console.WriteLine(task.Result);
                }
            });
            connection.Stop();
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
               
               var stockToGet = message.Split('=')[1];

               var stockPrice = GetStock(stockToGet);
               
               SendMessage($"{stockToGet.ToUpper()} quote is ${stockPrice} per share");
            }


        }
    }
}
