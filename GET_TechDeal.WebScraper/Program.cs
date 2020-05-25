using GET_TechDeal.Core.Entities;
using GET_TechDeal.Core.Services;
using GET_TechDeal.Infrastructure.Data;
using System;

namespace GET_TechDeal.WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Deal();
            var dealsService = new DealsService(new DealsRepository(new AppDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<AppDbContext>())));
            var xkomService = new XkomService(new XkomWebRepository());

            var deal = xkomService.GetCurrentDeal();
            dealsService.SaveDealIfNew(deal);

        }
    }
}
