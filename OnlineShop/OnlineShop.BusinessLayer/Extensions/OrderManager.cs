using OnlineShop.Data;
using OnlineShop.Entities;
using OnlineShop.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BusinessLayer.Extensions
{
    public static class OrderManager
    {
        //public Order(int id, int supplierId, int productId, int employeeId, decimal productAmount, DateTime time)

        public static void AddDataToOrder (this Order order, string supplierId, string productId, string employeeId, string productAmount)
        {
            //OrderId
            order.OrderId = JsonController<Order>.LoadIndexer();
            JsonController<Order>.SaveIndexer(order.OrderId + 1);

            //supplierId
            if (JsonController<Supplier>.checkId(InputCheck.GetIdNumber(supplierId)))
            {
                order.SupplierId = InputCheck.GetIdNumber(supplierId);
            }
            else { InputCheck.ShowError("Нет такого supplierId"); }

            //productId
            if (JsonController<Product>.checkId(InputCheck.GetIdNumber(productId)))
            {
                order.ProductId = InputCheck.GetIdNumber(productId);
            }
            else { InputCheck.ShowError("Нет такого productId"); }

            //employeeId
            if (JsonController<Employee>.checkId(InputCheck.GetIdNumber(employeeId)))
            {
                order.EmployeeId = InputCheck.GetIdNumber(employeeId);
            }
            else { InputCheck.ShowError("Нет такого employeeId"); }

            order.ProductAmount = InputCheck.GetAmountDecimal(productAmount);

            order.OrderTime = DateTime.Now;
        }

    }
}
