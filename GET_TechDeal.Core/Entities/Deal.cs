using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GET_TechDeal.Core.Entities
{
    public class Deal
    {
        [Key]
        public int DealId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public DateTime ScrapeTimestamp { get; set; }
    }
}
