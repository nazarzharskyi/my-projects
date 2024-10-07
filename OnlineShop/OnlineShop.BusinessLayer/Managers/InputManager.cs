using OnlineShop.BusinessLayer.Validators;

namespace OnlineShop.BusinessLayer.Managers
{
    public class InputManager
    {
        public string InputName(InputValidator inputValidator, string type)
        {
            string? name;
            //Input Name
            do
            {
                Console.Write($"Enter {type} name: ");
                name = Console.ReadLine();
                if (!inputValidator.IsValidDataName(name))
                {
                    Console.WriteLine($"Invalid input. Enter {type} name");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidDataName(name));
            return name;
        }
        public string InputEDRPU(InputValidator inputValidator, string type)
        {
            string? codeEDRPOU;
            //Input codeEDRPOU
            do
            {
                Console.Write($"Enter {type} code EDRPOU (10 digits): ");
                codeEDRPOU = Console.ReadLine();
                if (!inputValidator.IsValidDataEDRPOU(codeEDRPOU))
                {
                    Console.WriteLine($"Invalid input. Enter {type} code EDRPU (10 digits).");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidDataEDRPOU(codeEDRPOU));
            return codeEDRPOU;
        }
        public double InputPrice(InputValidator inputValidator, string type)
        {
            string? price;
            //Input Price
            do
            {
                Console.Write($"Enter {type} price: ");
                price = Console.ReadLine();
                if (!inputValidator.IsValidDataPrice(price))
                {
                    Console.WriteLine($"Invalid input. Enter {type} price.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidDataPrice(price));
            return Double.Parse(price);
        }
        public int InputINN(InputValidator inputValidator, string type)
        {
            string inn;
            do
            {
                Console.Write($"Enter {type} inn: ");
                inn = Console.ReadLine();
                if (!inputValidator.IsValidDataINN(inn))
                {
                    Console.WriteLine($"Invalid input. Enter {type} inn.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidDataINN(inn));
            return int.Parse(inn);
        }
        public int InputID(InputValidator inputValidator, string type)
        {
            string id;
            do
            {
                Console.Write($"Make a chose form {type} list and enter {type} ID: ");
                id = Console.ReadLine();
                if (!inputValidator.IsValidDataID(id))
                {
                    Console.WriteLine($"Invalid input. Enter {type} ID.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidDataID(id));
            return int.Parse(id);
        }
        public int InputAmount(InputValidator inputValidator, string type)
        {
            string amount;
            do
            {
                Console.Write($"Enter {type} amount: ");
                amount = Console.ReadLine();
                if (!inputValidator.IsValidAmount(amount))
                {
                    Console.WriteLine($"Invalid input. Enter {type} amount.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidAmount(amount));
            return Int32.Parse(amount);
        }
        public double InputDiscountPercantage(InputValidator inputValidator, string type)
        {
            string discount;
            do
            {
                Console.Write($"Enter {type} discount: ");
                discount = Console.ReadLine();
                if (!inputValidator.IsValidDiscount(discount))
                {
                    Console.WriteLine($"Invalid input. Enter {type} discount.");
                    Console.WriteLine();
                }
            } while (!inputValidator.IsValidDiscount(discount));
            return Double.Parse(discount);
        }
        public int MenuChoice()
        {
            int choice = 0;
            while (true)
            {
                Console.Write("Make your choice: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (choice > 0)
                    return choice;
            }
        }
    }
}