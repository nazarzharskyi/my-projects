using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    internal class OrderFromSupplierList
    {
        public ListController<OrderFromSupplier> orderFromSup;
        public OrderFromSupplierList()
        {
            orderFromSup = new ListController<OrderFromSupplier>();
        }
        public void OrderSupply(OrderFromSupplier order)
        {
            orderFromSup.AddItem(order);
        }
        public List<OrderFromSupplier> GetOrdersOfSupply()
        {
            return orderFromSup.GetItems();
        }
        public override string ToString()
        {
            Console.WriteLine(orderFromSup.ToString());
            return orderFromSup.ToString();
        }
    }
}