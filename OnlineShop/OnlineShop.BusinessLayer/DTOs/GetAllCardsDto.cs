using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.DTOs
{
    public class GetAllCardsDto
    {
        public List<GetCardDto> Cards { get; set; } = new();
    }
}