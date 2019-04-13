using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StockBoard.Function.Simulator.StockBoardServiceClient;
using StockBoard.Function.Simulator.StockBoardServiceClient.Models;

namespace StockBoard.Function.Simulator
{
    public static class Function1
    {
        static Random _random = new Random();

        [FunctionName("Function1")]
        public static void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var apiUrl = new Uri("https://localhost:44342");

            var apiClient = new StockBoardProject(apiUrl);
            //dynamic result = apiClient.GelAllStocks("1");
            var stocksList = (List<StockViewModel>) apiClient.GelAllStocks("1");



            foreach (var stock in stocksList)
            {
                var randomPrice = _random.Next(1, 100);
                var stockToUpdate = new StockViewModel(stock.Id, stock.Name, randomPrice);
                apiClient.UpdateStock("1", stockToUpdate);
            }
        }
    }
}
