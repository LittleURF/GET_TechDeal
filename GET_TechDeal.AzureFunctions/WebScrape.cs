using System;
using GET_TechDeal.AzureFunctions;
using GET_TechDeal.Core.Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace GET_TechDeal.WebScraper
{
    public static class WebScrape
    {
        [FunctionName("ScrapeWebsites")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer)
        {
            var a = new Deal();
        }


    }
}
