using OnlineShop.Constants;
using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public class ManufacturesService
    {
        private InputManager inputManager = new();
        private InputValidator inputValidator = new();
        private IDGenerator idGenerator = new();
        private OutputManager outputManager = new();
        private CommonEntityService<Manufacturer> commonEntityService = new();

        private List<Manufacturer> manufacturers = new List<Manufacturer>() 
        {
           new(1, "Manufacturer1", "ManufacturerEDRPOU1"),
           new(2, "Manufacturer2", "ManufacturerEDRPOU2"),
           new(3, "Manufacturer3", "ManufacturerEDRPOU3")
        };
        public Manufacturer CreateManufacturer()
        {
            int manufacturerID = idGenerator.InputID(manufacturers);
            string manufacturerName = inputManager.InputName(inputValidator, commonEntityService.GetListType());
            string manufacturerEDRPOU = inputManager.InputEDRPU(inputValidator, commonEntityService.GetListType());
            return new Manufacturer(manufacturerID, manufacturerName, manufacturerEDRPOU);
        }

        public void AddToManufacturers()
        {
            manufacturers.Add(CreateManufacturer());
            outputManager.Write(NotificationConstants.ADDED, commonEntityService.GetListType());
        }
        public Manufacturer GetManufacturerByID(int manufacturerID)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturers => manufacturers.ManufacturerID == manufacturerID);
            if (manufacturer == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            return manufacturer;
        }

        public Manufacturer GetManufacturerByName(string  manufacturerName)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturers => manufacturers.ManufacturerName == manufacturerName);
            if (manufacturer == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            return manufacturer;
        }

        public Manufacturer UpdateManufacturer(int manufacturerID)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturer => manufacturer.ManufacturerID == manufacturerID);
            if (manufacturer == null)
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
            return manufacturer;
        }

        public void DeleteManufacturerByID(int manufacturerID)
        {
            var manufacturer = manufacturers.FirstOrDefault(manufacturer => manufacturer.ManufacturerID == manufacturerID);
            if (manufacturer != null)
            {
                manufacturers.Remove(manufacturer);
                outputManager.Write(NotificationConstants.DELETED, commonEntityService.GetListType());
            }
            else
            {
                outputManager.Write(NotificationConstants.NOT_FOUND, commonEntityService.GetListType());
            }
        }

        public void OutputManufacturers()
        {
            outputManager.Write(commonEntityService.OutputList(manufacturers), commonEntityService.GetListType());
        }
    }
}
