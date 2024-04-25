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
                            if (TrueFalse)
                            {
                                Console.WriteLine("1. Продивитись розклад");
                                Console.WriteLine("2. Редагувати розклад");
                                Console.WriteLine("3. Вихід");
                                choice = 0;
                                try
                                {
                                    choice = Convert.ToInt32(Console.ReadLine());
                                }
                                catch(Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }
                                switch (choice)
                                {
                                    case 1:
                                        ShowTimetable();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Студента не знайдено");
                                Console.WriteLine("Натисніть \'Enter\'");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Бази данних не існує");
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
            while (true)
            {
                Console.WriteLine("1. Обрати день тижня");
                Console.WriteLine("2. Вихід");
                int choice = 0;
                string day = "", time = "", lesson_ = "";
                DoublePeriods doublePer = new DoublePeriods(day, time, lesson_);
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (choice == 1)
                {
                    Console.WriteLine("1. Понеділок\n2. Вівторок\n3. Середа\n4. Четвер\n5. П'ятниця\n6. Субота");
                    Console.Write("Введіть цифру для обрання дня: ");
                    choice = 0;
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    switch (choice)
                    {
                        case 1:
                            day = "Понеділок";
                            Console.WriteLine("1. 8:30\n2. 10:30\n3. 12:30\n4. 14:30\n5. 16:25\n6. 17:15");
                            Console.Write("Введіть цифру для обрання часу: ");
                            choice = 0;
                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            switch (choice)
                            {
                                case 1:
                                    time = "8:30 ";
                                    choice = 0;
                                    for (int i = 0; i < lessons.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {lessons[i]}");
                                    }
                                    Console.WriteLine("Введіть цифру для додання предмету:");
                                    try
                                    {
                                        choice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    switch (choice)
                                    {
                                        case 1:
                                            lesson_ = lesson[0];
                                            break;
                                        case 2:
                                            lesson_ = lesson[1];
                                            break;
                                        case 3:
                                            lesson_ = lesson[2];
                                            break;
                                        case 4:
                                            lesson_ = lesson[3];
                                            break;
                                        case 5:
                                            lesson_ = lesson[4];
                                            break;
                                        default:
                                            Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                            break;
                                    }
                                    break;
                                case 2:
                                    time = "10:30 ";
                                    choice = 0;
                                    for (int i = 0; i < lessons.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {lessons[i]}");
                                    }
                                    Console.WriteLine("Введіть цифру для додання предмету:");
                                    try
                                    {
                                        choice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    switch (choice)
                                    {
                                        case 1:
                                            lesson_ = lesson[0];
                                            break;
                                        case 2:
                                            lesson_ = lesson[1];
                                            break;
                                        case 3:
                                            lesson_ = lesson[2];
                                            break;
                                        case 4:
                                            lesson_ = lesson[3];
                                            break;
                                        case 5:
                                            lesson_ = lesson[4];
                                            break;
                                        default:
                                            Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                            break;
                                    }
                                    break;
                                case 3:
                                    time = "12:30 ";
                                    choice = 0;
                                    for (int i = 0; i < lessons.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {lessons[i]}");
                                    }
                                    Console.WriteLine("Введіть цифру для додання предмету:");
                                    try
                                    {
                                        choice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    switch (choice)
                                    {
                                        case 1:
                                            lesson_ = lesson[0];
                                            break;
                                        case 2:
                                            lesson_ = lesson[1];
                                            break;
                                        case 3:
                                            lesson_ = lesson[2];
                                            break;
                                        case 4:
                                            lesson_ = lesson[3];
                                            break;
                                        case 5:
                                            lesson_ = lesson[4];
                                            break;
                                        default:
                                            Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                            break;
                                    }
                                    break;
                                case 4:
                                    time = "14:30 ";
                                    choice = 0;
                                    for (int i = 0; i < lessons.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {lessons[i]}");
                                    }
                                    Console.WriteLine("Введіть цифру для додання предмету:");
                                    try
                                    {
                                        choice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    switch (choice)
                                    {
                                        case 1:
                                            lesson_ = lesson[0];
                                            break;
                                        case 2:
                                            lesson_ = lesson[1];
                                            break;
                                        case 3:
                                            lesson_ = lesson[2];
                                            break;
                                        case 4:
                                            lesson_ = lesson[3];
                                            break;
                                        case 5:
                                            lesson_ = lesson[4];
                                            break;
                                        default:
                                            Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                            break;
                                    }
                                    break;
                                case 5:
                                    time = "16:25 ";
                                    choice = 0;
                                    for (int i = 0; i < lessons.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {lessons[i]}");
                                    }
                                    Console.WriteLine("Введіть цифру для додання предмету:");
                                    try
                                    {
                                        choice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    switch (choice)
                                    {
                                        case 1:
                                            lesson_ = lesson[0];
                                            break;
                                        case 2:
                                            lesson_ = lesson[1];
                                            break;
                                        case 3:
                                            lesson_ = lesson[2];
                                            break;
                                        case 4:
                                            lesson_ = lesson[3];
                                            break;
                                        case 5:
                                            lesson_ = lesson[4];
                                            break;
                                        default:
                                            Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                            break;
                                    }
                                    break;
                                case 6:
                                    time = "17:15 ";
                                    choice = 0;
                                    for (int i = 0; i < lessons.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {lessons[i]}");
                                    }
                                    Console.WriteLine("Введіть цифру для додання предмету:");
                                    try
                                    {
                                        choice = Convert.ToInt32(Console.ReadLine());
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    switch (choice)
                                    {
                                        case 1:
                                            lesson_ = lesson[0];
                                            break;
                                        case 2:
                                            lesson_ = lesson[1];
                                            break;
                                        case 3:
                                            lesson_ = lesson[2];
                                            break;
                                        case 4:
                                            lesson_ = lesson[3];
                                            break;
                                        case 5:
                                            lesson_ = lesson[4];
                                            break;
                                        default:
                                            Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                            break;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                    break;

                            }
                            break;
                        default:
                            Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                            break;
                    }

                }
                else if (choice == 2)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                    Console.WriteLine("Натисніть \'Enter\'");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

        }
        static string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        static void TimeAndLesson(string day_)
        {
            List<string> lessons = new List<string>();
            List<string> lesson = new List<string>();
            lessons = ["Лінійна алгебра", "Програмування", "Фізична культура", "Математичний аналіз", "Алгоритмічні мови"];
            int choice = 0;
            string day = "", time = "", lesson_ = "";
            for (int j = 0; j < 1; j++)
            {
                
                Console.WriteLine("1. 8:30\n2. 10:30\n3. 12:30\n4. 14:30\n5. 16:25\n6. 17:15");
                Console.Write("Введіть цифру для обрання часу: ");
                choice = 0;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                switch (choice)
                {
                    case 1:
                        time = "8:30 ";
                        choice = 0;
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {lessons[i]}");
                        }
                        Console.WriteLine("Введіть цифру для додання предмету:");
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        switch (choice)
                        {
                            case 1:
                                lesson_ = lesson[0];
                                break;
                            case 2:
                                lesson_ = lesson[1];
                                break;
                            case 3:
                                lesson_ = lesson[2];
                                break;
                            case 4:
                                lesson_ = lesson[3];
                                break;
                            case 5:
                                lesson_ = lesson[4];
                                break;
                            default:
                                Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                break;
                        }
                        break;
                    case 2:
                        time = "10:30 ";
                        choice = 0;
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {lessons[i]}");
                        }
                        Console.WriteLine("Введіть цифру для додання предмету:");
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        switch (choice)
                        {
                            case 1:
                                lesson_ = lesson[0];
                                break;
                            case 2:
                                lesson_ = lesson[1];
                                break;
                            case 3:
                                lesson_ = lesson[2];
                                break;
                            case 4:
                                lesson_ = lesson[3];
                                break;
                            case 5:
                                lesson_ = lesson[4];
                                break;
                            default:
                                Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                break;
                        }
                        break;
                    case 3:
                        time = "12:30 ";
                        choice = 0;
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {lessons[i]}");
                        }
                        Console.WriteLine("Введіть цифру для додання предмету:");
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        switch (choice)
                        {
                            case 1:
                                lesson_ = lesson[0];
                                break;
                            case 2:
                                lesson_ = lesson[1];
                                break;
                            case 3:
                                lesson_ = lesson[2];
                                break;
                            case 4:
                                lesson_ = lesson[3];
                                break;
                            case 5:
                                lesson_ = lesson[4];
                                break;
                            default:
                                Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                break;
                        }
                        break;
                    case 4:
                        time = "14:30 ";
                        choice = 0;
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {lessons[i]}");
                        }
                        Console.WriteLine("Введіть цифру для додання предмету:");
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        switch (choice)
                        {
                            case 1:
                                lesson_ = lesson[0];
                                break;
                            case 2:
                                lesson_ = lesson[1];
                                break;
                            case 3:
                                lesson_ = lesson[2];
                                break;
                            case 4:
                                lesson_ = lesson[3];
                                break;
                            case 5:
                                lesson_ = lesson[4];
                                break;
                            default:
                                Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                break;
                        }
                        break;
                    case 5:
                        time = "16:25 ";
                        choice = 0;
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {lessons[i]}");
                        }
                        Console.WriteLine("Введіть цифру для додання предмету:");
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        switch (choice)
                        {
                            case 1:
                                lesson_ = lesson[0];
                                break;
                            case 2:
                                lesson_ = lesson[1];
                                break;
                            case 3:
                                lesson_ = lesson[2];
                                break;
                            case 4:
                                lesson_ = lesson[3];
                                break;
                            case 5:
                                lesson_ = lesson[4];
                                break;
                            default:
                                Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                break;
                        }
                        break;
                    case 6:
                        time = "17:15 ";
                        choice = 0;
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {lessons[i]}");
                        }
                        Console.WriteLine("Введіть цифру для додання предмету:");
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        switch (choice)
                        {
                            case 1:
                                lesson_ = lesson[0];
                                break;
                            case 2:
                                lesson_ = lesson[1];
                                break;
                            case 3:
                                lesson_ = lesson[2];
                                break;
                            case 4:
                                lesson_ = lesson[3];
                                break;
                            case 5:
                                lesson_ = lesson[4];
                                break;
                            default:
                                Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Ви ввели щось не так, спробуйте ще раз");
                        break;

                }
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

