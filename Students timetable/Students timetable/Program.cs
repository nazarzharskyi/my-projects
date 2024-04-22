using System.Text;
using System.Text.RegularExpressions;
namespace Students_timetable
{
    internal class Program
    {
        static List<DoublePeriods> doublePeriods = new List<DoublePeriods>();

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
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
                int choice = 0;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (choice == 3)
                {
                    break;
                }
                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть ім'я студента: ");
                        string name = "", surname = "", group = "";
                        name = Console.ReadLine();
                        Console.Write("Введіть прізвище студента: ");
                        surname = Console.ReadLine();
                        Console.Write("Введіть групу студента: ");
                        group = Console.ReadLine();
                        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                        var filePath = Path.Combine(desktopPath, "students.txt");
                        if (File.Exists(filePath))
                        {
                            string textFromFile = ReadFile(filePath);
                            bool TrueFalse= FindStudent(name, surname, group, textFromFile);
                            Console.WriteLine(TrueFalse);
                            Console.WriteLine("Натисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("You don`t have a database of students");
                            Console.WriteLine("Натисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                            break;
                    case 2:
                        string _name = "", _surname = "", _group = "";
                        Console.Write("Введіть ім'я студента: ");
                        _name = Console.ReadLine();
                        Console.Write("Введіть прізвище студента: ");
                        _surname = Console.ReadLine();
                        Console.Write("Введіть групу студента: ");
                        _group = Console.ReadLine();
                        Student student = new Student(_name, _surname, _group);
                        Console.WriteLine("1. Зберегти");
                        Console.WriteLine("2. Вийти без збереження");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                            filePath = Path.Combine(desktopPath, "students.txt");
                            string textToSave = "";
                            //textToSave = $"{_name} {_surname} {_group}";
                            textToSave=$"{student.Id} {student.Name} {student.Surname} {student.Group}";
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
                    case 3:
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
                    using (FileStream fs = File.Create(_path)) { }
                }
                using (StreamWriter writer = new StreamWriter(_path, true, Encoding.Unicode))
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
        static string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
        static bool FindStudent(string name, string surname, string group, string text)
        {
            string Find = $"{name} {surname} {group}";
            Match match = Regex.Match(text, Find);
            return match.Success;
        }
        private static void DeleteDoublepriod()
        {

        }
    }
}

