using GET_TechDeal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GET_TechDeal.Core.Interfaces
{
    public interface IXkomWebRepository
    {
        Deal GetCurrentDeal();
        Product GetCurrentDealProduct();
        DateTime GetDateOfNextDeal();
    }
}
