using System.Text.RegularExpressions;

namespace OnlineShop
{
    public class InputValidator
    {
        public bool IsValidDataName(string name)
        {
            // regular expression that checks whether the entered name contains letters, digits and simbols: -_.@
            // length required from 3 to 25
            string pattern = @"^[A-Za-z0-9\-_.@]{3,25}$";

            // Validate input using a regular expression
            return Regex.IsMatch(name, pattern);
        }

        public bool IsValidDataEDRPOU(string codeEDRPOU)
        {
            // regular expression that checks whether the entered name contains only ten digits
            string pattern = @"^\d{10}$";

            // Validate input using a regular expression
            return Regex.IsMatch(codeEDRPOU, pattern);
        }
        public bool IsValidDataPrice(string price)
        {
            // regular expression that checks whether the entered name contains only ten digits
            string pattern = @"^\d+(\.\d{1,2})?$";

            // Validate input using a regular expression
            return Regex.IsMatch(price, pattern);
        }
    }
}
