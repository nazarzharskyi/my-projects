namespace OnlineShop
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
    }
}

