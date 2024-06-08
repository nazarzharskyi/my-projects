namespace OnlineShop
{
    public class OutputManager
    {
       public void Write (string message, string type) 
        {
            Console.WriteLine($"{type} {message}");
            Console.WriteLine(); 
        }
    }
}
