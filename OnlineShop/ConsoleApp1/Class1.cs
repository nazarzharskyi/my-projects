using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class JsonController<T>
    {


        public static void WriteToFile(T source)
        {
            using (FileStream fs = new FileStream($"mytest{typeof(T).Name}.json", FileMode.OpenOrCreate))
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;

                if (source != null)
                {
                    JsonSerializer.Serialize<T>(fs, source, options);
                }

                fs.Close();
            }
        }

        public static List<T> ReadFromFile()
        {

            string fileName = $"mytest.json";

            // Проверка существования файла
            if (!File.Exists(fileName))
            {
                // Возвращаем пустой список, если файл не существует
                return new List<T>();
            }

            try
            {
                // Чтение и десериализация файла
                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    // Проверка, что файл не пустой
                    if (fs.Length == 0)
                    {
                        return new List<T>();
                    }

                    return JsonSerializer.Deserialize<List<T>>(fs) ?? new List<T>();
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Ошибка при чтении из файла {fileName}: {ex.Message}");
                // Возвращаем пустой список в случае ошибки
                return new List<T>();
            }
        }
    }
}
