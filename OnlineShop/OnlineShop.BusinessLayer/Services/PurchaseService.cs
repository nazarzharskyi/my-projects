using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.Constants;
using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    internal class PurchaseService
    {
        private InputManager _inputManager = new();
        private InputValidator _inputValidator = new();
        private OutputManager _outputManager = new();
        private IDGenerator _generatorID = new();
        private CommonEntityService<Purchase> _commonEntityService = new();

        private ProductsService productsService = new ProductsService();

        private List<Purchase> purchases = new List<Purchase>()
        {
        };
        public Purchase CreatePurchase()
        {
            int purchaseID = _generatorID.InputID(purchases);
            int productID = _inputManager.InputID(_inputValidator, _commonEntityService.GetListType()); //Це не то
            int buyerID = _inputManager.InputID(_inputValidator, _commonEntityService.GetListType()); //Це не то
            int employeeID = _inputManager.InputID(_inputValidator, _commonEntityService.GetListType()); //Це не то
            return new Purchase(purchaseID);
        }
        public void AddPurchase()
        {
            purchases.Add(CreatePurchase());
            _outputManager.OutputToConsole(NotificationConstants.ADDED, _commonEntityService.GetListType());
        }
        public void RemovePurchaseID(int purchaseID)
        {
            var purchase = purchases.FirstOrDefault(purchase => purchase.PurchaseID == purchaseID);
            if (purchase != null)
            {
                purchases.Remove(purchase);
                _outputManager.OutputToConsole(NotificationConstants.DELETED, _commonEntityService.GetListType());
            }
            else
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
        }
        public Purchase UpdatePurchase(int purchaseID)
        {
            var purchase = purchases.FirstOrDefault(purchase => purchase.PurchaseID == purchaseID);
            if (purchase == null)
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return purchase;
        }
        public Purchase GetManufacturerByID(int purchaseID)
        {
            var purchase = purchases.FirstOrDefault(purchase => purchase.PurchaseID == purchaseID);
            if (purchase == null)
            {
                _outputManager.OutputToConsole(NotificationConstants.NOT_FOUND, _commonEntityService.GetListType());
            }
            return purchase;
        }
        public void OutputPurchase()
        {
            _outputManager.OutputToConsole(_commonEntityService.OutputList(purchases), _commonEntityService.GetListType());
        }
    }
}
