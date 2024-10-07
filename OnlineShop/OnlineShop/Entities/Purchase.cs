using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OnlineShop.Data.Entities;

namespace OnlineShop.Entities
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        private Product _productID = new();
        private Buyer _buyerID = new();
        private Employee _employeeID = new();

        public Purchase()
        {

        }
        public Purchase(int purchaseID)
        {
            PurchaseID = purchaseID;
        }
        public Purchase(int purchaseID, Product productID, Buyer buyerID, Employee employeeID)
        {
            PurchaseID = purchaseID;
            _productID = productID;
            _buyerID = buyerID;
            _employeeID = employeeID;
        }
        public override string ToString()
        {
            return $"PurchaseID: {PurchaseID}, buyerID: {_buyerID}, empliyeeID: {_employeeID} and productID: {_productID}";
        }
    }
}
