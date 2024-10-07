using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop.EntityServices
{
    public static class OrderController
    {

        public static void AddOrder()
        {
            
        }


        public static List<PaymentType> ShowAll()
        {
            List<PaymentType> resutl = ReadFromFile();
            return resutl;
        }



        public static void WriteToFile(List<PaymentType> list)
        {
            using (FileStream fs = new FileStream("PaymentType.json", FileMode.OpenOrCreate))
            {

                JsonSerializer.Serialize(fs, list);
            }
        }

        public static List<PaymentType> ReadFromFile()
        {
            using (FileStream fs = new FileStream("Order.json", FileMode.Open))
            {
                List<PaymentType> result = JsonSerializer.Deserialize<List<PaymentType>>(fs);
                return result;
            }
        }
    }
}
