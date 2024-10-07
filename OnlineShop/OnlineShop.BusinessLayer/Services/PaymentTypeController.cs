using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{
    public static class PaymentTypeController
    {

        //public static void AddPaymentType( string name)
        //{
        //    List<PaymentType> list = ReadFromFile();

        //    list.Add(new PaymentType(name));

        //    WriteToFile(list);
        //}


        //public static List<PaymentType> ShowAll()
        //{
        //    List<PaymentType> resutl = ReadFromFile();
        //    return resutl;
        //}



        //public static void WriteToFile(List<PaymentType> list)
        //{
        //    using (FileStream fs = new FileStream("PaymentType.json", FileMode.OpenOrCreate))
        //    {

        //        JsonSerializer.Serialize(fs, list);
        //    }
        //}

        //public static List<PaymentType> ReadFromFile()
        //{
        //    using (FileStream fs = new FileStream("PaymentType.json", FileMode.Open))
        //    {
        //        List<PaymentType> result = JsonSerializer.Deserialize<List<PaymentType>>(fs);
        //        return result;
        //    }
        //}
    }
}
