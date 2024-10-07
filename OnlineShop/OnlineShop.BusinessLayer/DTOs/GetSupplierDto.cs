using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.DTOs
{
    public class GetSupplierDto
    {
        public int SupplierID { get; init; }
        public string? SupplierName { get; set; }
        public string? SupplierEDRPOU { get; set; }
    }
}
