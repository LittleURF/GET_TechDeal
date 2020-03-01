using GET_TechDeal.Core.Entities;
using GET_TechDeal.Core.Interfaces;
using GET_TechDeal.Infrastructure.WebParsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GET_TechDeal.Infrastructure.Data
{
    public class XkomWebRepository : IXkomWebRepository
    {
        private readonly XkomWebParser _xkomWebParser = new XkomWebParser();

        public Deal GetCurrentDeal()
        {
            var deal = new Deal()
            {
                ScrapeTimestamp = DateTime.Now,
                Product = GetCurrentDealProduct(),
            };

            return deal;
        }

        public Product GetCurrentDealProduct()
        {
            var product = new Product()
            {
                Name = _xkomWebParser.GetName(),
                Amount = _xkomWebParser.GetAmountOfProducts(),
                DiscountPercentage = _xkomWebParser.GetDiscountPercentage(),
                PriceInitial = _xkomWebParser.GetInitialPrice(),
                PriceDiscounted = _xkomWebParser.GetDiscountedPrice(),
            };

            return product;
        }

        public DateTime GetDateOfNextDeal()
        {
            return _xkomWebParser.GetDateOfNextDeal();
        }
    }
}
