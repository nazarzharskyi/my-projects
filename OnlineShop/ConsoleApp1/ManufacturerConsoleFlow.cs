
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Entities;
using OnlineShop.Records;

namespace ConsoleApp1
{
    internal class ManufacturerConsoleFlow
    {
        ManufacturersService manufacturersService = new();
        InputManager inputManager = new();
        InputValidator inputValidator = new();
        OutputManager outputManager = new();
        CommonEntityService<Manufacturer> commonEntityService = new();
        Manufacturer manufacturer = new();

        //Menu 1
        public async Task CreateNewManufacturer(string connectionString)
        {
            await manufacturersService.CreateManufacturer(inputManager.InputName(inputValidator, commonEntityService.GetListType()),
                inputManager.InputEDRPU(inputValidator, commonEntityService.GetListType()), connectionString);
        }

        //Menu 2
        public async Task OutputAllManufacturers(string connectionString)
        {
            var manufacturers = await manufacturersService.GetAllManufacturers(connectionString);
            outputManager.OutputToConsole(commonEntityService.OutputList(manufacturers), commonEntityService.GetListType()); ;
        }

        //Menu 3
        public async Task GetManufacturerByID(string connectionString)
        {
            manufacturer = await manufacturersService.GetManufacturerByID(inputManager.InputID(inputValidator, commonEntityService.GetListType()), connectionString);
            if (manufacturer != null)
            {
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }

        }

        //Menu 4
        public async Task GetManufacturerByName(string connectionString)
        {
            Console.Write($"Enter Manufacturer Name for search: ");
            var manufacturerName = Console.ReadLine();
            manufacturer = await manufacturersService.GetManufacturerByName(manufacturerName, connectionString);
            if (manufacturer != null)
            {
                Console.Write("Manufacturer: ");
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }
        }

        //Menu 5
        public async Task GetManufacturerByCode(string connectionString)
        {
            Console.Write($"Enter Manufacturer code EDRPOU for search: ");
            var codeEDRPOU = Console.ReadLine();
            manufacturer = await manufacturersService.GetManufacturerByCode(codeEDRPOU, connectionString);
            if (manufacturer != null)
            {
                Console.WriteLine("EDRPOU: ");
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }
        }

        //Menu 6
        public async Task UpdateManufacturerNameByID(string connectionString)
        {
            Console.Write($"Enter Manufacturer ID to update Name: ");
            var manufacturerID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Manufacturer Name to update: ");
            var manufacturerName = Console.ReadLine();
            manufacturer = await manufacturersService.UpdateManufacturerNameByID(manufacturerID, manufacturerName, connectionString);
            if (manufacturer != null)
            {
                Console.Write("updated Manufacturer: ");
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }
        }

        //Menu 7
        public async Task UpdateManufacturerCodeByID(string connectionString)
        {
            Console.Write($"Enter Manufacturer ID for update EDRPOU: ");
            var manufacturerID = int.Parse(Console.ReadLine());
            Console.Write($"Enter new Manufacturer EDRPOU to update: ");
            var manufacturerEDRPOU = Console.ReadLine();
            manufacturer = await manufacturersService.UpdateManufacturerCodeByID(manufacturerID, manufacturerEDRPOU, connectionString);
            if (manufacturer != null)
            {
                Console.Write("updated Manufacturer: ");
                Console.WriteLine(manufacturer.ToString());
            }
            else
            {
                Console.WriteLine("Manufacturer not found.");
            }
        }

        //Menu 8
        public async Task DeleteManufacturerByID(string connectionString)
        {
            Console.WriteLine(await manufacturersService.DeleteManufacturerByID(inputManager.InputID(inputValidator, commonEntityService.GetListType()), connectionString));
        }
    }
}
