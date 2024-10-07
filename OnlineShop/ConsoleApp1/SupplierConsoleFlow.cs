
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Entities;


namespace ConsoleApp1
{
    internal class SupplierConsoleFlow
    {
        SuppliersService suppliersService = new();
        InputManager inputManager = new();
        OutputManager outputManager = new();
        InputValidator inputValidator = new();
        CommonEntityService<Supplier> commonEntityService = new();
        Supplier supplier = new();

        //Menu 1
        public async Task CreateNewSupplier(string connectionString)
        {
           await suppliersService.CreateSupplier(inputManager.InputName(inputValidator, commonEntityService.GetListType()), inputManager.InputEDRPU(inputValidator, commonEntityService.GetListType()), connectionString);
        }

        //Menu 2
        public async Task OutputAllSuppliers(string connectionString)
        {
            var suppliers = await suppliersService.GetAllSuppliers(connectionString);
            outputManager.OutputToConsole(commonEntityService.OutputList(suppliers), commonEntityService.GetListType());
        }

        //Menu 3
        public async Task GetSupplierByID(string connectionString)
        {
            supplier = await suppliersService.GetSupplierByID(inputManager.InputID(inputValidator, commonEntityService.GetListType()), connectionString);
            if (supplier != null)
            {
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }

        }

        //Menu 4
        public async Task GetSupplierByName(string connectionString)
        {
            Console.Write($"Enter Supplier Name for search: ");
            var supplierName = Console.ReadLine();
            supplier = await suppliersService.GetSupplierByName(supplierName, connectionString);
            if (supplier != null)
            {
                Console.Write("Supplier: ");
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        //Menu 5
        public async Task GetSupplierByCode(string connectionString) 
        {
            Console.Write($"Enter Supplier code EDRPOU for search: ");
            var codeEDRPOU = Console.ReadLine();
            supplier = await suppliersService.GetSupplierByCode(codeEDRPOU, connectionString);
            if (supplier != null)
            {
                Console.WriteLine("EDRPOU: ");
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        //Menu 6
        public async Task UpdateSupplierNameByID(string connectionString)
        {
            Console.Write($"Enter Supplier ID to update Name: ");
            var supplierID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Supplier Name to update: ");
            var supplierName = Console.ReadLine();
            supplier = await suppliersService.UpdateSupplierNameByID(supplierID, supplierName, connectionString);
            if (supplier != null)
            {
                Console.Write("updated Supplier: ");
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        //Menu 7
        public async Task UpdateSupplierCodeByID(string connectionString) 
        {
            Console.Write($"Enter Supplier ID for update EDRPOU: ");
            var supplierID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Supplier EDRPOU to update: ");
            var supplierEDRPOU = Console.ReadLine();
            supplier = await suppliersService.UpdateSupplierCodeByID(supplierID, supplierEDRPOU, connectionString);
            if (supplier != null)
            {
                Console.Write("updated Supplier: ");
                Console.WriteLine(supplier.ToString());
            }
            else
            {
                Console.WriteLine("Supplier not found.");
            }
        }

        //Menu 8
        public async Task DeleteSupplierByID(string connectionString)
        {
            Console.WriteLine(await suppliersService.DeleteSupplierByID(inputManager.InputID(inputValidator, commonEntityService.GetListType()), connectionString));
        }
    }
}
