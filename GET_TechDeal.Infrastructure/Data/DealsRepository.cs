using GET_TechDeal.Core.Data;
using GET_TechDeal.Core.Entities;
using GET_TechDeal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GET_TechDeal.Infrastructure.Data
{
    public class DealsRepository : IDealsRepository
    {
        private readonly AppDbContext _appDbContext;

        public DealsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool IsTodaysDealScraped()
        {
            return _appDbContext.Deals.Any(d => d.ScrapeTimestamp.Day == DateTime.Today.Day);
        }

        public void SaveDeal(Deal deal)
        {
            _appDbContext.Add(deal);
        }
    }
}
