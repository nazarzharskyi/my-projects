using System.Text.RegularExpressions;

namespace OnlineShop.BusinessLayer.Validators
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
        public bool IsValidDataINN(string inn)
        {
            string pattern = @"^[0-9]{3,10}$";

            return Regex.IsMatch(inn, pattern);
        }
        public bool IsValidDataID(string id)
        {
            string pattern = @"^[0-9]{1,20}$";
            // string pattern = @"^\d{1,5}$";

            return Regex.IsMatch(id, pattern);
        }

        public bool IsValidAmount(string amount)
        {
            string pattern = @"^[1-9]\d*$";

            return Regex.IsMatch(amount, pattern);
        }
        public bool IsValidDiscount(string percentage)
        {
            string pattern = @"^(100(\.0{1,2})?|[0-9]?[0-9](\.[0-9]{1,2})?)$";
            return Regex.IsMatch(percentage, pattern);
        }
    }
}
