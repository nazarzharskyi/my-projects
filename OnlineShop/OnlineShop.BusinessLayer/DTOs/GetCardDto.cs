using OnlineShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.DTOs
{
    public class GetCardDto
    {
        public int DiscountCard_ID { get; init; }
        public double PercanatageDiscount { get; set; }
        public Buyer buyer { get; set; }
    }
}
