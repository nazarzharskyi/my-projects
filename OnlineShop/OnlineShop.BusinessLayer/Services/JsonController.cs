using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OnlineShop.Constants;
using OnlineShop.Entities;

namespace OnlineShop.EntityServices
{

    public static class JsonController<T>
    {
        public static void WriteToFile(T source)
        {
            List<T> list = ReadFromFile();

            using (FileStream fs = new FileStream($"{typeof(T).Name}.json", FileMode.Create))
            {
                list.Add(source);

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;

                if (source != null)
                {
                    JsonSerializer.SerializeAsync(fs, list, options);
                }

                fs.Close();
            }
        }

        public static List<T> ReadFromFile()
        {
            // Чтение и десериализация файла
            using (FileStream fs = new FileStream($"{typeof(T).Name}.json", FileMode.OpenOrCreate,
                       FileAccess.ReadWrite))
            {
                try
                {
                    List<T> result = JsonSerializer.Deserialize<List<T>>(fs);
                    return result;
                }
                catch (Exception ex)
                {
                    return new List<T>();
                }
            }
        }


        public static int LoadIndexer()
        {
            if (File.Exists($"indexer_of_{typeof(T).Name}.json"))
            {
                string json = File.ReadAllText($"indexer_of_{typeof(T).Name}.json");
                return JsonSerializer.Deserialize<int>(json);
            }

            return 0; // Возвращаем 0, если файл не существует или не удалось загрузить данные
        }


        public static void SaveIndexer(int indexer)
        {
            string json = JsonSerializer.Serialize(indexer);
            File.WriteAllText($"indexer_of_{typeof(T).Name}.json", json);
        }


        public static bool checkId(int enteredId)
        {
            int lastindex = LoadIndexer();
            if (enteredId < lastindex)
            {
                return true;
            }

            return false;
        }
    }
}
