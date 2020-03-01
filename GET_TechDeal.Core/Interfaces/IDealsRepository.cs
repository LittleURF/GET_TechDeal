using GET_TechDeal.Core.Entities;

namespace GET_TechDeal.Core.Data
{
    public interface IDealsRepository
    {
        bool IsTodaysDealScraped();
        void SaveDeal(Deal deal);
    }
}