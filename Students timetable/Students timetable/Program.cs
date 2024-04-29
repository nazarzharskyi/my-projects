using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
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
                        Console.Clear();
                        if (File.Exists(filePath))
                        {
                            string textFromFile = ReadFile(filePath);
                            bool TrueFalse= FindStudent(name, surname, group, textFromFile);
                            if (TrueFalse)
                            {
                                Console.WriteLine("1. Продивитись розклад");
                                Console.WriteLine("2. Редагувати розклад");
                                Console.WriteLine("3. Вихід");
                                string StudentTextFile = $"{name} {surname} {group}";
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
                                        ShowTimetable(StudentTextFile);
                                        break;
                                    case 2:
                                        while (true)
                                        {
                                            Console.WriteLine("1. Понеділок\n2. Вівторок\n3. Середа\n4. Четвер\n5. П'ятниця\n6. Субота\n0. Вихід");
                                            Console.Write("Введіть цифру для обрання дня: ");
                                            choice = 0;
                                            try
                                            {
                                                choice = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                                break;
                                            }
                                            if (choice >= 0 && choice < 7)
                                            {
                                                string dayFor = "";
                                                switch (choice)
                                                {
                                                    case 1:
                                                        dayFor = "Понеділок";
                                                        break;
                                                    case 2:
                                                        dayFor = "Вівторок";
                                                        break;
                                                    case 3:
                                                        dayFor = "Середа";
                                                        break;
                                                    case 4:
                                                        dayFor = "Четвер";
                                                        break;
                                                    case 5:
                                                        dayFor = "П'ятниця";
                                                        break;
                                                    case 6:
                                                        dayFor = "Субота";
                                                        break;
                                                    case 0:
                                                        Console.WriteLine("Для вихода натисніть \'Enter\'");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        return;
                                                }
                                                TimeAndLesson(dayFor, StudentTextFile);
                                            }
                                        }
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
        private static void ShowTimetable(string txtName)
        {
            string _path = "";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            _path = Path.Combine(desktopPath, $"{txtName}.txt");
            string[] textFromFile = { };
            try
            {
                textFromFile = File.ReadAllLines(_path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            foreach (string line in textFromFile)
            {
                Console.WriteLine(line);   
            }
            Console.WriteLine("Натисніть \'Enter\' для виходу");
            Console.ReadLine();
            Console.Clear();
            return;
        }
        static string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
        static void TimeAndLesson(string day_, string txtName)
        {
            string day = "";
            day = day_;
            int choice = 0;
            string _path = "";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            _path = Path.Combine(desktopPath, $"{txtName}.txt");


            string[] Monday = new string[7];
            string[] Tuesday = new string[7];
            string[] Wednesday = new string[7];
            string[] Thursday = new string[7];
            string[] Friday = new string[7];
            string[] Saturday = new string[7];
            List<string> Times = new List<string>();
            Times = ["8:30", "10:30", "12:30", "14:30", "16:25", "17:15"];


            try
            {
                if (!File.Exists(_path))
                {
                    using (FileStream fs = File.Create(_path)) { }


                    Monday = ["Понеділок", "8:30 - Нема нічого", "10:30 - Нема нічого", "12:30 - Нема нічого", "14:30 - Нема нічого", "16:25 - Нема нічого", "17:15 - Нема нічого"];

                    Tuesday = ["Вівторок", "8:30 - Нема нічого", "10:30 - Нема нічого", "12:30 - Нема нічого", "14:30 - Нема нічого", "16:25 - Нема нічого", "17:15 - Нема нічого"];

                    Wednesday = ["Середа", "8:30 - Нема нічого", "10:30 - Нема нічого", "12:30 - Нема нічого", "14:30 - Нема нічого", "16:25 - Нема нічого", "17:15 - Нема нічого"];

                    Thursday = ["Четвер", "8:30 - Нема нічого", "10:30 - Нема нічого", "12:30 - Нема нічого", "14:30 - Нема нічого", "16:25 - Нема нічого", "17:15 - Нема нічого"];

                    Friday = ["П'тяниця", "8:30 - Нема нічого", "10:30 - Нема нічого", "12:30 - Нема нічого", "14:30 - Нема нічого", "16:25 - Нема нічого", "17:15 - Нема нічого"];

                    Saturday = ["Субота", "8:30 - Нема нічого", "10:30 - Нема нічого", "12:30 - Нема нічого", "14:30 - Нема нічого", "16:25 - Нема нічого", "17:15 - Нема нічого"];
                    string _text = "";
                    foreach (string s in Monday) 
                    { 
                        _text += $"{s}\n";
                    }
                    foreach (string s in Tuesday)
                    {
                        _text += $"{s}\n";
                    }
                    foreach (string s in Wednesday)
                    {
                        _text += $"{s}\n";
                    }
                    foreach (string s in Thursday)
                    {
                        _text += $"{s}\n";
                    }
                    foreach (string s in Friday)
                    {
                        _text += $"{s}\n";
                    }
                    foreach (string s in Saturday)
                    {
                        _text += $"{s}\n";
                    }
                    using (StreamWriter writer = new StreamWriter(_path, true, Encoding.Unicode))
                    {
                        writer.WriteLine(_text);
                    }
                    Console.WriteLine("Файл не було знайдено та було створено, настисніть \'Enter\'");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
                else
                {
                    string[] textFromFile={};
                    try
                    {
                        textFromFile = File.ReadAllLines(_path);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    int i = 0;
                    foreach (string line in textFromFile)
                    {
                        if (i >= 0 && i < 7)
                        {
                            Monday[i] = line;
                        }
                        else if (i >= 7 && i < 14)
                        {
                            Tuesday[i-7] = line;
                        }
                        else if (i >= 14 && i < 21)
                        {
                            Wednesday[i-14] = line;
                        }
                        else if (i >= 21 && i < 28)
                        {
                            Thursday[i-21] = line;
                        }
                        else if (i >= 28 && i < 35)
                        {
                            Friday[i-28] = line;
                        }
                        else if (i >= 35 && i < 42)
                        {
                            Saturday[i-35] = line;
                        }
                        i++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Сталася помикла: " + e.Message);
            }

            List<string> lessons = new List<string>();
            lessons = ["Видалити предмет", "Лінійна алгебра", "Програмування", "Фізична культура", "Математичний аналіз", "Алгоритмічні мови"];
            while (true)
            {
                string time = "", lesson = "";
                switch (day)
                {
                    case "Понеділок":
                        Console.WriteLine("1. 8:30\n2. 10:30\n3. 12:30\n4. 14:30\n5. 16:25\n6. 17:15");
                        Console.Write("Введіть цифру для обрання часу: ");
                        int choiceTime = 0;
                        try
                        {
                            choiceTime = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceTime > 0 && choiceTime < 7)
                        {
                            time = Times[choiceTime-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + lessons[i]);
                        }
                        Console.Write("Введіть цифру для обрання предмету: ");
                        int choiceOfLesson = 0;
                        try
                        {
                            choiceOfLesson = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceOfLesson == 1)
                        {
                            lesson = "Нема нічого";
                        }
                        else if (choiceOfLesson > 1 && choiceOfLesson < 7)
                        {
                            lesson = lessons[choiceOfLesson-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        Monday[choiceTime] = $"{time} - {lesson}";
                        break;

                    case "Вівторок":
                        Console.WriteLine("1. 8:30\n2. 10:30\n3. 12:30\n4. 14:30\n5. 16:25\n6. 17:15");
                        Console.Write("Введіть цифру для обрання часу: ");
                        choiceTime = 0;
                        try
                        {
                            choiceTime = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceTime > 0 && choiceTime < 7)
                        {
                            time = Times[choiceTime-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + lessons[i]);
                        }
                        Console.Write("Введіть цифру для обрання предмету: ");
                        choiceOfLesson = 0;
                        try
                        {
                            choiceOfLesson = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceOfLesson == 1)
                        {
                            lesson = "Нема нічого";
                        }
                        else if (choiceOfLesson > 1 && choiceOfLesson < 7)
                        {
                            lesson = lessons[choiceOfLesson-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        Tuesday[choiceTime] = $"{time} - {lesson}";
                        break;


                    case "Середа":
                        Console.WriteLine("1. 8:30\n2. 10:30\n3. 12:30\n4. 14:30\n5. 16:25\n6. 17:15");
                        Console.Write("Введіть цифру для обрання часу: ");
                        choiceTime = 0;
                        try
                        {
                            choiceTime = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceTime > 0 && choiceTime < 7)
                        {
                            time = Times[choiceTime-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + lessons[i]);
                        }
                        Console.Write("Введіть цифру для обрання предмету: ");
                        choiceOfLesson = 0;
                        try
                        {
                            choiceOfLesson = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceOfLesson == 1)
                        {
                            lesson = "Нема нічого";
                        }
                        else if (choiceOfLesson > 1 && choiceOfLesson < 7)
                        {
                            lesson = lessons[choiceOfLesson-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        Wednesday[choiceTime] = $"{time} - {lesson}";
                        break;
                    case "Четвер":
                        Console.WriteLine("1. 8:30\n2. 10:30\n3. 12:30\n4. 14:30\n5. 16:25\n6. 17:15");
                        Console.Write("Введіть цифру для обрання часу: ");
                        choiceTime = 0;
                        try
                        {
                            choiceTime = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceTime > 0 && choiceTime < 7)
                        {
                            time = Times[choiceTime-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + lessons[i]);
                        }
                        Console.Write("Введіть цифру для обрання предмету: ");
                        choiceOfLesson = 0;
                        try
                        {
                            choiceOfLesson = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceOfLesson == 1)
                        {
                            lesson = "Нема нічого";
                        }
                        else if (choiceOfLesson > 1 && choiceOfLesson < 7)
                        {
                            lesson = lessons[choiceOfLesson-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        Thursday[choiceTime] = $"{time} - {lesson}";
                        break;
                    case "П'ятниця":
                        Console.WriteLine("1. 8:30\n2. 10:30\n3. 12:30\n4. 14:30\n5. 16:25\n6. 17:15");
                        Console.Write("Введіть цифру для обрання часу: ");
                        choiceTime = 0;
                        try
                        {
                            choiceTime = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceTime > 0 && choiceTime < 7)
                        {
                            time = Times[choiceTime-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + lessons[i]);
                        }
                        Console.Write("Введіть цифру для обрання предмету: ");
                        choiceOfLesson = 0;
                        try
                        {
                            choiceOfLesson = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceOfLesson == 1)
                        {
                            lesson = "Нема нічого";
                        }
                        else if (choiceOfLesson > 1 && choiceOfLesson < 7)
                        {
                            lesson = lessons[choiceOfLesson-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        Friday[choiceTime] = $"{time} - {lesson}";
                        break;
                    case "Субота":
                        Console.WriteLine("1. 8:30\n2. 10:30\n3. 12:30\n4. 14:30\n5. 16:25\n6. 17:15");
                        Console.Write("Введіть цифру для обрання часу: ");
                        choiceTime = 0;
                        try
                        {
                            choiceTime = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceTime > 0 && choiceTime < 7)
                        {
                            time = Times[choiceTime-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        for (int i = 0; i < lessons.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + lessons[i]);
                        }
                        Console.Write("Введіть цифру для обрання предмету: ");
                        choiceOfLesson = 0;
                        try
                        {
                            choiceOfLesson = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (choiceOfLesson == 1)
                        {
                            lesson = "Нема нічого";
                        }
                        else if (choiceOfLesson > 1 && choiceOfLesson < 7)
                        {
                            lesson = lessons[choiceOfLesson-1];
                        }
                        else
                        {
                            Console.WriteLine("Ви ввели щось не так, настисніть \'Enter\'");
                            Console.ReadLine();
                            Console.Clear();
                            return;
                        }
                        Saturday[choiceTime] = $"{time} - {lesson}";
                        break;
                }
                DoublePeriods doublePeriods = new DoublePeriods(day, time, lesson);
                Console.WriteLine("1. Зберегти файл");
                Console.WriteLine("2. Продовжити оновлювати розклад");
                Console.WriteLine("3. Вийти");
                choice = 0;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
                switch(choice) 
                {
                    case 1:
                        string _textToSave = "";
                        foreach(string les in Monday)
                        {
                            _textToSave += ($"{les}\n");
                        }
                        foreach (string les in Tuesday)
                        {
                            _textToSave += ($"{les}\n");
                        }
                        foreach (string les in Wednesday)
                        {
                            _textToSave += ($"{les}\n");
                        }
                        foreach (string les in Thursday)
                        {
                            _textToSave += ($"{les}\n");
                        }
                        foreach (string les in Friday)
                        {
                            _textToSave += ($"{les}\n");
                        }
                        foreach (string les in Saturday)
                        {
                            _textToSave += ($"{les}\n");
                        }
                        using (StreamWriter sw = new StreamWriter(_path))//очищаю файл, щоб не залишалось старої версії розкладу
                        {
                            sw.Write("");
                        }
                        SaveAll(_path, _textToSave);
                        Console.Clear();
                        return;
                    case 2:
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Настисніть \'Enter\'");
                        Console.ReadLine();
                        Console.Clear();
                        return;
                }
            }
        }
        static bool FindStudent(string name, string surname, string group, string text)
        {
            string Find = $"{name} {surname} {group}";
            Match match = Regex.Match(text, Find);
            return match.Success;
        }
    }
}

