using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.BusinessLayer.Managers;
using OnlineShop.BusinessLayer.Services;
using OnlineShop.BusinessLayer.Validators;
using OnlineShop.Entities;

namespace ConsoleApp1
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            ManufacturersService ManufacturersService = new();
            InputManager inputManager = new();
            InputValidator inputValidator = new();
            CommonEntityService<Supplier> commonEntityServiceS = new();
            CommonEntityService<Manufacturer> commonEntityServiceM = new();
            SupplierConsoleFlow supplierFlow = new SupplierConsoleFlow();
            ManufacturerConsoleFlow manufacturerFlow = new ManufacturerConsoleFlow();
            ProductConsoleFlow productFlow = new ProductConsoleFlow();
            DiscountCardConsoleFlow discountCardConsoleFlow = new DiscountCardConsoleFlow();
            OutputManager outputManager = new OutputManager();

            // Configurations
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.SvitlanaL.json")
                .AddJsonFile("appsettings.Nazar.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Master");
            if (connectionString == null)
            {
                Console.WriteLine("Something went wrong with connection");
                return;
            }
         
            var datAssembly = AppDomain.CurrentDomain.GetAssemblies()
                .FirstOrDefault(x => x.GetName().Name == "OnlineShop.Data");

            // Migrations
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddLogging(c => c.AddFluentMigratorConsole())
                    .AddFluentMigratorCore()
                    .ConfigureRunner(rb => rb.AddSqlServer2012()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(datAssembly).For.Migrations());
                })
                .Build();

            host.MigrateDatabase();

            // Menu
            bool exit = false;

            while (!exit)
            {
                outputManager.OutputToConsoleWriteLn("What do you want to work with? Please, make your choice: ");
                outputManager.OutputToConsoleWriteLn("Main Menu:");
                outputManager.OutputToConsoleWriteLn("S: Supplier");
                outputManager.OutputToConsoleWriteLn("M: Manufacturer");
                outputManager.OutputToConsoleWriteLn("P: Product");
                outputManager.OutputToConsoleWriteLn("DC: Discount Card");



                string? mainChoice = Console.ReadLine();
                switch (mainChoice)
                {
                    case "S":
                        {
                            Console.WriteLine("Supplier Menu:");
                            Console.WriteLine("1. Add new Supplier");
                            Console.WriteLine("2. Get all suppliers list");
                            Console.WriteLine("3. Search Supplier by ID");
                            Console.WriteLine("4. Search Supplier by Name");
                            Console.WriteLine("5. Search Supplier by EDRPOU");
                            Console.WriteLine("6. Update Supplier name");
                            Console.WriteLine("7. Update Supplier EDRPOU");
                            Console.WriteLine("8. Delete Supplier");
                            Console.WriteLine("9. Exit");
                            Console.Write("Please, make your choice: ");

                            string? choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    await supplierFlow.CreateNewSupplier(connectionString);
                                    break;
                                case "2":
                                    await supplierFlow.OutputAllSuppliers(connectionString);
                                    break;
                                case "3":
                                    await supplierFlow.GetSupplierByID(connectionString);
                                    break;
                                case "4":
                                    await supplierFlow.GetSupplierByName(connectionString);
                                    break;
                                case "5":
                                    await supplierFlow.GetSupplierByCode(connectionString);
                                    break;
                                case "6":
                                    await supplierFlow.UpdateSupplierNameByID(connectionString);
                                    break;
                                case "7":
                                    await supplierFlow.UpdateSupplierCodeByID(connectionString);
                                    break;
                                case "8":
                                    await supplierFlow.DeleteSupplierByID(connectionString);
                                    break;
                                case "9":
                                    exit = true;
                                    Console.WriteLine("Exit...");
                                    break;
                                default:
                                    Console.WriteLine("Wrong choice. Try again.");
                                    break;
                            }
                            Console.WriteLine();
                            break;
                        }

                    case "M":
                        {
                            Console.WriteLine("Manufacturer Menu:");
                            Console.WriteLine("1. Add new Manufacturer");
                            Console.WriteLine("2. Get all manufacturers list");
                            Console.WriteLine("3. Search Manufacturer by ID");
                            Console.WriteLine("4. Search Manufacturer by Name");
                            Console.WriteLine("5. Search Manufacturer by EDRPOU");
                            Console.WriteLine("6. Update Manufacturer name");
                            Console.WriteLine("7. Update Manufacturer EDRPOU");
                            Console.WriteLine("8. Delete Manufacturer");
                            Console.WriteLine("9. Exit");
                            Console.Write("Make your choice: ");

                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    await manufacturerFlow.CreateNewManufacturer(connectionString);
                                    break;
                                case "2":
                                    await manufacturerFlow.OutputAllManufacturers(connectionString);
                                    break;
                                case "3":
                                    await manufacturerFlow.GetManufacturerByID(connectionString);
                                    break;
                                case "4":
                                    await manufacturerFlow.GetManufacturerByName(connectionString);
                                    break;
                                case "5":
                                    await manufacturerFlow.GetManufacturerByCode(connectionString);
                                    break;
                                case "6":
                                    await manufacturerFlow.UpdateManufacturerNameByID(connectionString);
                                    break;
                                case "7":
                                    await manufacturerFlow.UpdateManufacturerCodeByID(connectionString);
                                    break;
                                case "8":
                                    await manufacturerFlow.DeleteManufacturerByID(connectionString);
                                    break;
                                case "9":
                                    exit = true;
                                    Console.WriteLine("Exit...");
                                    break;
                                default:
                                    Console.WriteLine("Wrong choice. Try again.");
                                    break;
                            }
                            Console.WriteLine();
                            break;
                        }

                    case "P":
                        {
                            Console.WriteLine("Product Menu:");
                            Console.WriteLine("1. Add new Product");
                            Console.WriteLine("2. Get all products list");
                            Console.WriteLine("3. Search Product by ID");
                            Console.WriteLine("4. Search Product by Name");
                            Console.WriteLine("5. Update Product name");
                            Console.WriteLine("6. Update Product Category");
                            Console.WriteLine("7. Update Product Manufacturer");
                            Console.WriteLine("8. Update Product Supplier");
                            Console.WriteLine("9. Update Product Price");
                            Console.WriteLine("10. Delete Product");
                            Console.WriteLine("11. Exit");
                            Console.Write("Make your choice: ");

                            string choice = Console.ReadLine();

                            switch (choice)
                            {
                                case "1":
                                    await productFlow.CreateNewProduct(connectionString);
                                    break;
                                case "2":
                                    await productFlow.OutputAllProducts(connectionString);
                                    break;
                                case "3":
                                    await productFlow.GetProductByID(connectionString);
                                    break;
                                case "4":
                                    await productFlow.GetProductByName(connectionString);
                                    break;
                                case "5":
                                    await productFlow.UpdateProductNameByID(connectionString);
                                    break;
                                case "6":
                                    await productFlow.UpdateProductCategoryByID(connectionString);
                                    break;
                                case "7":
                                    await productFlow.UpdateProductManufacturerByID(connectionString);
                                    break;
                                case "8":
                                    await productFlow.UpdateProductSupplierByID(connectionString);
                                    break;
                                case "9":
                                    await productFlow.UpdateProductPrice(connectionString);
                                    break;
                                case "10":
                                    await productFlow.DeleteProductByID(connectionString);
                                    break;
                                case "11":
                                    exit = true;
                                    Console.WriteLine("Exit...");
                                    break;
                                default:
                                    Console.WriteLine("Wrong choice. Try again.");
                                    break;
                            }
                            Console.WriteLine();
                            break;
                        }
                    case "DC":
                        outputManager.OutputToConsoleWriteLn("1. Create Discount card");
                        outputManager.OutputToConsoleWriteLn("2. Update Discount card percantage");
                        outputManager.OutputToConsoleWriteLn("3. Get all Discount cards list");
                        outputManager.OutputToConsoleWriteLn("4. Get Discount card by ID");
                        outputManager.OutputToConsoleWriteLn("5. Exit");
                        outputManager.OutputToConsoleWriteLn("");
                        int choiceDC = inputManager.MenuChoice();
                        switch (choiceDC)
                        {
                            case 1:
                                discountCardConsoleFlow.CreateCard(connectionString);
                                break;
                            case 2:
                                discountCardConsoleFlow.updateCardPercantage(connectionString);
                                break;
                            case 3:
                                discountCardConsoleFlow.GetAllDiscountCards(connectionString);
                                break;
                            case 4:
                                discountCardConsoleFlow.GetDiscountCardById(connectionString);
                                break;
                            case 5:
                                outputManager.OutputToConsoleWriteLn("Exit...");
                                break;
                            default:
                                outputManager.OutputToConsoleWriteLn("Wrong choice. Try again.");
                                break;
                        }
                        outputManager.OutputToConsoleWriteLn("");
                        break;
                }
            }
        }
    }
}
