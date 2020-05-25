using System;
using GET_TechDeal.Core.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer)
        {
            var deal = new Deal();
            deal.ScrapeTimestamp = DateTime.Now;
        }
    }
}
