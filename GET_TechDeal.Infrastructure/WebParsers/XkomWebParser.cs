using Fizzler.Systems.HtmlAgilityPack;
using GET_TechDeal.Core.Exceptions;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GET_TechDeal.Infrastructure.WebParsers
{
    public class XkomWebParser
    {
        private readonly HtmlWeb _htmlWeb = new HtmlWeb();
        private readonly HtmlNode _website;
        private readonly HtmlNode _dealWrapper;


        public XkomWebParser()
        {
            _website = GetWebsite();
            _dealWrapper = GetDealWrapper();
        }

        public string GetName()
        {
            var itemNameNode = _dealWrapper.QuerySelector(".product-name");

            return itemNameNode?.InnerText ?? "";
        }

        public int GetDiscountPercentage()
        {
            var discountNode = _dealWrapper.QuerySelector(".discount-tip-value");
            if (discountNode == null || String.IsNullOrWhiteSpace(discountNode.InnerText))
                return 0;

            var discount = discountNode.InnerHtml;

            if (discount.Contains("%"))
                return Int32.Parse(discount.Replace("%", ""));

            if (discount.Contains("zł"))
                return CalculateDiscountPercentageByPrices();

            return 0;
        }

        private int CalculateDiscountPercentageByPrices()
        {
            var initialPrice = GetInitialPrice();
            var priceAfterDiscount = GetDiscountedPrice();

            var discountPercentage = CalculateDifferencePercentage(initialPrice, priceAfterDiscount);
            return discountPercentage;
        }

        private int CalculateDifferencePercentage(decimal initialPrice, decimal priceAfterDiscount)
        {
            var discount = initialPrice - priceAfterDiscount;
            var discountPercentage = discount / initialPrice * 100;

            return Decimal.ToInt32(discountPercentage);
        }

        public decimal GetInitialPrice()
        {
            var initialPriceNode = _dealWrapper.QuerySelector(".old-price");
            string initialPriceString = RemoveCurrencySuffix(initialPriceNode?.InnerText);

            Decimal.TryParse(initialPriceString, out decimal initialPrice);

            return initialPrice;
        }

        public decimal GetDiscountedPrice()
        {
            var discountedPriceNode = _dealWrapper.QuerySelector(".new-price");
            string discountedPriceString = RemoveCurrencySuffix(discountedPriceNode?.InnerText);

            Decimal.TryParse(discountedPriceString, out decimal discountedPrice);
            return discountedPrice;
        }

        // Website displays 2 counters of items sold and items still available, we just add them up to get the total amount
        public int GetAmountOfProducts()
        {
            var amountCounters = _dealWrapper.QuerySelectorAll(".gs-quantity").Select(r => r.NextSibling);

            var amountTotal = amountCounters.Select(r => r.InnerText).Sum(r => Int32.Parse(r));

            return amountTotal;
        }

        // Date is set by JS scripts, not worth scraping
        // Deals refresh every 24hrs at 10PM.
        public DateTime GetDateOfNextDeal()
        {
            var today10PMDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 0);
            return today10PMDate;
        }

        private HtmlNode GetWebsite()
        {
            var url = "https://www.x-kom.pl/";
            var doc = _htmlWeb.Load(url);
            var docNode = doc?.DocumentNode;

            if (docNode == null || docNode.ChildNodes == null || docNode.ChildNodes.Count < 1)
                throw new WebScrapingException("Getting Website document failed");

            return docNode;
        }

        private HtmlNode GetDealWrapper()
        {
            var dealWrapper = _website.QuerySelector("#hotShot");

            if (dealWrapper == null || dealWrapper.ChildNodes == null || dealWrapper.ChildNodes.Count < 1)
                throw new WebScrapingException("Getting the wrapper of the deal from the website document failed");

            return dealWrapper;
        }

        private string RemoveCurrencySuffix(string argument)
        {
            return argument.Replace("zł", "").Trim();
        }
    }
}
