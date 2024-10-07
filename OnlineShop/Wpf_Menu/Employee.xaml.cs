using OnlineShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OnlineShop.Entities;
using OnlineShop.EntityServices;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        private MainWindow mainWindow;

        private int indexer = JsonController<Employee>.LoadIndexer();

        public EmployeePage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }

        private void Button_Click_ChangeByID(object sender, RoutedEventArgs e)
        {

        }

    //    public Employee(int employeeId, string position, DateOnly hiredate, uint salary, ulong inn, string name, string surname, string phoneNumber, DateOnly userBirthDate, string address)
    //: base(inn, name, surname, phoneNumber, userBirthDate, address)

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            int employeeId = indexer;
            indexer++;

            JsonController<Employee>.SaveIndexer(indexer);

            string position;
            if (!GettingData.GetString(positionTextBox, out position)) { return; }

            DateOnly hiredate;
            if(!GettingData.GetDataOnly(hire_date_Text_box, out hiredate)) { return; }

            uint salary;
            if(!GettingData.GetPrice(salaryTextBox, out salary)) { return; }

            ulong inn;
            if(!GettingData.GetINN(INN, out inn)) {  return; }

            string name;
            if(!GettingData.GetString(Name, out name)) { return; }

            string surname;
            if (!GettingData.GetString(Surname, out surname)) { return; }

            string phoneNumber;
            if (!GettingData.GetString(PhoneNumber, out phoneNumber)) { return; }

            DateOnly userbirthday;
            if(!GettingData.GetDataOnly(Date_of_birth, out userbirthday)) {  return; }

            string adress;
            if(!GettingData.GetString(Address, out adress)) { return; }


            Employee addingEmployee = new Employee(employeeId, position, hiredate,salary,inn,name,surname,phoneNumber,userbirthday,adress);

            JsonController<Employee>.WriteToFile(addingEmployee);

            positionTextBox.Clear();
            hire_date_Text_box.Clear();
            salaryTextBox.Clear();
            INN.Clear();
            Name.Clear();
            Surname.Clear();
            PhoneNumber.Clear();
            Date_of_birth.Clear();
            Address.Clear();

        }

        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {
            List<Employee> employees = JsonController<Employee>.ReadFromFile();

            AllListBox.ItemsSource = employees;
        }
    }
}
