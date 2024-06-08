using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Entities
{
    internal class OrderSupply
    {
        public int OrderID { get; init; }
        public int SupplierID { get; init; }
        public int ProductID { get; set; }
        public int ProductAmount { get; set; }
        public string OrderTime { get; set; }
        public int EmployeeID { get; set; }
        public Product product { get; set; }
        public OrderSupply(int orderID, int supplierID, int productID, int productAmount, string orderTime, int employeeID)
        {
            OrderID = orderID;
            SupplierID = supplierID;
            ProductID = productID;
            ProductAmount = productAmount;
            OrderTime = orderTime;
            EmployeeID = employeeID;
        }
        public override string ToString()
        {
            return $"Order ID: {OrderID}, Supplier ID: {SupplierID}, Product ID: {ProductID}, Product Amount: {ProductAmount}, Order time: {OrderTime}, Employee ID: {EmployeeID}, Product: {product}";
        }
    } 
}
