using OnlineShop.Constants;
using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public class SuppliersService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator idGenerator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Supplier> commonEntityService = new();

        private List<Supplier> suppliers = new List<Supplier>()
        {
        new Supplier(1, "Supplier1", "SupplierEDRPOU1"),
        new Supplier(2, "Supplier2", "SupplierEDRPOU2"),
        new Supplier(3, "Supplier3", "SupplierEDRPOU3")
        };

        public Supplier CreateSupplier()
        {
            int supplierID = idGenerator.InputID(suppliers);
            string supplierName = inputManager.InputName(inputValidator, commonEntityService.GetListType());
            string supplierEDRPOU = inputManager.InputEDRPU(inputValidator, commonEntityService.GetListType());
            return new Supplier(supplierID, supplierName, supplierEDRPOU);
        }

        public void AddToSuppliers()
        {
            suppliers.Add(CreateSupplier());
            outputManager.Write(NotificationConstants.ADDED, commonEntityService.GetListType());
        }

        public Supplier GetSupplierByID(int supplierID)
        {
            var supplier = suppliers.FirstOrDefault(supplier => supplier.SupplierID == supplierID);
            if (supplier == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            return supplier;
        }

        //додати логику апдейту
        public Supplier UpdateSupplier(int supplierID)
        {
            var supplier = suppliers.FirstOrDefault(supplier => supplier.SupplierID == supplierID);
            if (supplier == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            return supplier;
        }


       public void DeleteSupplierByID(int supplierID)
        {
            var supplier = suppliers.FirstOrDefault(supplier => supplier.SupplierID == supplierID);
            if (supplier != null)
            {
                suppliers.Remove(supplier);
                outputManager.Write(NotificationConstants.DELETED, commonEntityService.GetListType());
            }
            else
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
        }

        public void OutputSuppliers()
        {
            outputManager.Write(commonEntityService.OutputList(suppliers), commonEntityService.GetListType());
        }
    }
}