using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.DTOs
{
    public class GetAllSuppliersDto
    {
        public List<GetSupplierDto> Suppliers { get; set; } = new();
    }
}
