using GET_TechDeal.Core.Entities;

namespace GET_TechDeal.Core.Interfaces
{
    public interface IProductRepository
    {
        void SaveProduct(Product product);
    }
}