using GET_TechDeal.Core.Data;
using GET_TechDeal.Core.Entities;
using GET_TechDeal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GET_TechDeal.Core.Services
{
    public class DealsService
    {
        private readonly IDealsRepository _dealsRepository;

        public DealsService(IDealsRepository dealsRepository)
        {
            _dealsRepository = dealsRepository;
        }

        public void SaveDealIfNew(Deal deal)
        {
            try
            {
                if (deal == null || deal.Product == null)
                    return;

                if (_dealsRepository.IsTodaysDealScraped())
                    return;
                else
                    _dealsRepository.SaveDeal(deal);
            }
            catch (Exception e)
            {
                // log
                throw;
            }
        }
    }
}
