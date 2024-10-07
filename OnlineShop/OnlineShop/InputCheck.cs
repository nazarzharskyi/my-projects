using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public static class InputCheck
    {
        public static Action<string>? ShowError { get; set; }

        public static uint GetPriceUint(string textbox)
        {
            uint result = 0;

            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные цены отсутствуют");
                result = 0;
            }
            else if (textbox.Length > 4)
            {
                ShowError.Invoke("Ошибка формата данных цены");
                result = 0;
            }

             if(!uint.TryParse(textbox, out result))
            {
                ShowError.Invoke("Ошибка формата данных цены");
            }

             return result;

        }

        public static decimal GetAmountDecimal(string textbox)
        {
            decimal result = 0;

            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные количества товара отсутствуют");
                result = 0;
            }
            else if (textbox.Length > 4)
            {
                ShowError.Invoke("Ошибка формата данных количества товара");
                result = 0;
            }

            if( decimal.TryParse(textbox, out result))
            {
                ShowError.Invoke("Ошибка формата данных количества товара");
            }
            return result;

        }

        public static ulong GetINN(string textbox)
        {
            ulong result = 0;

            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные ИНН отсутствуют");
            }
            else if (textbox.Length != 10)
            {
                ShowError.Invoke("Ошибка формата данных ИНН");
            }

            else if (Regex.IsMatch(textbox, @"^\d{10}$"))
            {
                result = ulong.Parse(textbox);
            }

            return result;
        }

        public static int GetIdNumber(string textbox)
        {
            int result = 0;

            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные Id отсутствуют");
                result = 0;
            }
            else if (textbox.Length > 5)
            {
                ShowError.Invoke("Ошибка формата данных Id");
                result = 0;
            }

            return result;
        }

        public static string GetEDRPOU(string textbox)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(textbox))
            {
                ShowError.Invoke("Данные ЕДРПОУ отсутствуют");
            }
            else if (textbox.Length != 8)
            {
                ShowError.Invoke("Ошибка формата данных ЕДРПОУ");
            }

            else if (Regex.IsMatch(textbox, @"^\d{8}$"))
            {
                result = textbox;
            }
            return result;
        }

        public static string GetString(string textbox)
        {
            string result = string.Empty;

            if (textbox == null)
            {
                ShowError.Invoke("Ошибка при получении текста");
                return result;
            }

            result = textbox.Trim();

            return result;
        }

        public static DateOnly GetDataOnly(string textbox)
        {

            DateOnly result = DateOnly.MinValue;


            if (string.IsNullOrWhiteSpace(textbox))
            {
                ShowError.Invoke("Ошибка, данные даты не заполнены");
                return result;
            }

            else if (!DateOnly.TryParse(textbox.Trim(), out result))
            {
                ShowError.Invoke("Ошибка при преобразовании текста в дату");
            }

            return result;

        }

        public static string GetEmail(string textbox)
        {
            string result = string.Empty;   
            try
            {
                if (Regex.IsMatch(textbox.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    result = textbox;
                }

                throw new FormatException();
            }
            catch (FormatException)
            {
                ShowError.Invoke("Неверный формат email.");
                result = string.Empty;
            }

            return result;
        }

        public static string GetPhoneNumber(string textbox)
        {
            string result = string.Empty;
            
            Regex regex2 = new Regex("@\"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$\"");

            // Проверка соответствия текста регулярному выражению
            if (regex2.IsMatch(textbox))
            {
                result = textbox;
            }

            else
            {
                ShowError.Invoke("Неверный формат email.");
                result = string.Empty;
            }
            return result;
        }
    }
}
