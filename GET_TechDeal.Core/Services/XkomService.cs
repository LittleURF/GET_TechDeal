using Fizzler.Systems.HtmlAgilityPack;
using GET_TechDeal.Core.Entities;
using GET_TechDeal.Core.Interfaces;
using HtmlAgilityPack;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GET_TechDeal.Core.Services
{
    public class XkomService
    {
        private readonly IXkomWebRepository _xkomWebRepository;

        public XkomService(IXkomWebRepository xkomWebRepository)
        {
            _xkomWebRepository = xkomWebRepository;
        }

        public Deal GetCurrentDeal()
        {
            return _xkomWebRepository.GetCurrentDeal();
        }

        public Product GetCurrentDealProduct()
        {
            return _xkomWebRepository.GetCurrentDealProduct();
        }
    }

}
