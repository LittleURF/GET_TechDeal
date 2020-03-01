using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GET_TechDeal.Core.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public Deal Deal { get; set; }
        public int DealId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal PriceInitial { get; set; }
        public decimal PriceDiscounted { get; set; }
    }
}
