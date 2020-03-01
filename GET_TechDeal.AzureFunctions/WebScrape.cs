using System;
using GET_TechDeal.AzureFunctions;
using GET_TechDeal.Core.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace GET_TechDeal.WebScraper
{
    public static class WebScrape
    {
        [FunctionName("ScrapeWebsites")]
        public static void Run([TimerTrigger("0 */30 * * * *")]TimerInfo myTimer, ILogger log)
        {

        }


    }
}
