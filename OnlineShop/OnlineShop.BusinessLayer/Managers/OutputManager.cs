namespace OnlineShop.BusinessLayer.Managers
{
    public class OutputManager
    {
        public void OutputToConsole(string message, string type)
        {
            Console.WriteLine($"{type} {message}");
            Console.WriteLine();
        }
        public void OutputToConsoleWrite(string message)
        {
            Console.Write($"{message}");
        }
        public void OutputToConsoleWriteLn(string message)
        {
            Console.WriteLine($"{message}");
        }
        public void OutputDBException(Exception ex)
        {
            Console.WriteLine($"Something went wrong with the database"); //зробити запис в лог
            Console.WriteLine($"Error: {ex.Message}");
        }

        public void OutputException(Exception ex)
        {
            Console.WriteLine($"Something went wrong");
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
