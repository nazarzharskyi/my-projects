using System.Text;
namespace Students_timetable
{
    internal class Program
    {
        static List<DoublePeriods> doublePeriods = new List<DoublePeriods>();

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            
            ShowUI();
        }

        private static void ShowUI()
        {
            while (true)
            {
                Console.WriteLine("1. Оберіть студента");
                Console.WriteLine("2. Додайте студента");
                Console.WriteLine("3. Вихід");

                Console.Write("Введіть цифру для вибору дії: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 3) 
                { 
                    break;
                }
                switch (choice)
                {
                    case 1:
                            Console.Write("Введіть ім'я студента: ");
                            string name = "", surname = "", group = "";
                            try
                            {
                                name = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.Write("Введіть прізвище студента: ");
                            try
                            {
                                surname = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.Write("Введіть групу студента: ");
                            try
                            {
                                group = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        return;
                        case 2:
                            Console.InputEncoding = Encoding.UTF8;
                            Console.OutputEncoding = Encoding.UTF8;
                            string _name = "", _surname = "", _group = "";
                            Console.Write("Введіть ім'я студента: ");
                            try
                            {
                                _name = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.Write("Введіть прізвище студента: ");
                            try
                            {
                                _surname = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Console.Write("Введіть групу студента: ");
                            try
                            {
                                _group = Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Student student = new Student(_name, _surname, _group);
                            Console.WriteLine("1. Зберегти");
                            Console.WriteLine("2. Вийти без збереження");
                            choice = int.Parse(Console.ReadLine());
                            if (choice == 1)
                            {
                                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                                var filePath = Path.Combine(desktopPath, "students.txt");
                                string textToSave = "";
                                textToSave = $"{_name} {_surname} {_group}";
                                Console.WriteLine(textToSave);
                                SaveAll(filePath, textToSave);
                                Console.WriteLine("Збережено, натисніть \'Enter\'");
                                Console.ReadLine();
                                Console.Clear();
                            break;
                            }
                            else if (choice == 2)
                            {
                                _name = ""; _surname = ""; _group = "";
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Ви ввели щось не так, натисніть \'Enter\'");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        return;
                        default:
                        
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                        return;
                }
            }
        }
        private static void SaveAll(string _path, string _text)
        {
            try
            {
                if (!File.Exists(_path))
                {   
                    using (FileStream fs = File.Create(_path)){}
                }
                using (StreamWriter writer=new StreamWriter(_path, true, Encoding.UTF8))
                {
                    writer.WriteLine(_text);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Сталася помикла: " + e.Message);
            }
        }
        private static void ShowTimetable()
        {
            
        }
        private static void DayTimetableDo()
        {
            Console.WriteLine("1. Додати пару");
            Console.WriteLine("2. Видалити пару");
            Console.WriteLine("3. Редагувати пару");
            Console.Write("Введіть цифру для вибору дії: ");
            int choice1 = int.Parse(Console.ReadLine());
            if (choice1 == 1)
            {
                AddDoublePeriod();
            }
            else if (choice1 == 2)
            {
                DeleteDoublepriod();
            }
            else
            {
                Console.WriteLine("Некоректний вибір. Спробуйте ще");
                Console.Clear();
                return;
            }
        }
       
        private static void AddDoublePeriod()
        {
            List<string> lessons = new List<string>();
            List<string> lesson = new List<string>();
            lessons = ["Лінійна алгебра", "Програмування", "Фізична культура", "Математичний аналіз", "Алгоритмічні мови"];
            Console.WriteLine("1. Оберіть предмет");
            Console.WriteLine("2. Вихід");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                for (int i = 0; i < lessons.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {lessons[i]}");
                }
                Console.WriteLine();
                choice = int.Parse(Console.ReadLine());
                if (choice > 0 && choice < 6)
                {
                    {

                    }
                    for (int i = 0; i < lessons.Count; i++)
                    {
                        if (choice == i - 1)
                        {
                            lesson.Add(lessons[i]);
                        }
                    }
                }
            }
            else if (choice == 2)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Ви ввели щось не так, натисніть \'Enter\'");
                Console.ReadLine();
                Console.Clear();
            }

        }
        private static void DeleteDoublepriod()
        {

        }
    }
}

