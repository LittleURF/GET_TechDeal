using GET_TechDeal.Core.Entities;
using GET_TechDeal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GET_TechDeal.AzureFunctions
{
    public class Scraper
    {
        private readonly IXkomWebRepository _xkomWebRepository;

        public Scraper(IXkomWebRepository xkomWebRepository)
        {
            _xkomWebRepository = xkomWebRepository;
        }

        public Deal GetDeal()
        {
            return _xkomWebRepository.GetCurrentDeal();
        }
    }
}
