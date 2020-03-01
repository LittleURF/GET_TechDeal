using GET_TechDeal.Core.Entities;
using GET_TechDeal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GET_TechDeal.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void SaveProduct(Product product)
        {
            _appDbContext.Add(product);
        }
    }
}
