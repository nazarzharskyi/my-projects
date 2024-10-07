using OnlineShop.Entities;

namespace OnlineShop.BusinessLayer.DTOs
{
    public class OrderSupplyDto
    {
        public Supplier? _supplier { get; set; }
        public Product? _product { get; set; }
        public int ProductAmount { get; init; }
        public DateTime OrderTime { get; set; }
        public Employee? _employee { get; set; }
    }
}
