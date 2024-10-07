using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public class OrderSupply
    {
        public int SupplyOrderID { get; init; }
        public Supplier? _supplier { get; set; }
        public Product? _product { get; set; }
        public int ProductAmount { get; init; }
        public DateTime OrderTime { get; set; }
        public Employee? _employee { get; set; }


        public OrderSupply()
        {

        }

        public OrderSupply(int orderID, int productAmount)
        {
            SupplyOrderID = orderID;
            ProductAmount = productAmount;
        }

        public OrderSupply(int orderID, int productAmount, DateTime orderTime)
        {
            SupplyOrderID = orderID;
            ProductAmount = productAmount;
            OrderTime = orderTime;
        }

        public OrderSupply(int orderID, Supplier supplier, Product product, int productAmount, DateTime orderTime, Employee employee)
        {
            SupplyOrderID = orderID;
            _supplier = supplier;
            _product = product;
            ProductAmount = productAmount;
            OrderTime = orderTime;
            _employee = employee;
        }

        public override string ToString()
        {
            return $"Supply order ID: {SupplyOrderID}, Supplier: {_supplier}, Product: {_product}, Product Amount: {ProductAmount}, Order time: {OrderTime}, Employee: {_employee}";
        }
    }
}