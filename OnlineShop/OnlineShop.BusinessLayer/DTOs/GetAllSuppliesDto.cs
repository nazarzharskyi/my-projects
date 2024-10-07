

namespace OnlineShop.BusinessLayer.DTOs
{
    public class GetAllSuppliesDto
    {
        public List<OrderSupplyDto> Supplies { get; set; } = new();
    }
}
