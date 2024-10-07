using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.DTOs
{
    public class GetStockDTO
    {
        public Product? productDTO { get; set; }
        public int ProductAmount { get; set; }
        public int StockItemID { get; set; }
    }
}
