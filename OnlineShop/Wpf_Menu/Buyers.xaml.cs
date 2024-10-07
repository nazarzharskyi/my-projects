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
using System.Net.Mail;
using System.Text.Json;
using System.Threading.Tasks;
using OnlineShop.Data.Entities;
using OnlineShop.EntityServices;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Buyers.xaml
    /// </summary>
    public partial class Buyers : Page
    {


        private MainWindow mainWindow;

        private int indexer = JsonController<Buyer>.LoadIndexer();

        public Buyers(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }

        private void Button_Click_ChangeBuyerByID(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_AddBuyer(object sender, RoutedEventArgs e)
        {


            ulong inn;
            if(!GettingData.GetINN(INN,out inn)) { return; }


            string name;
            if(!GettingData.GetString(Name, out name)){return; }

            string surname;
            if(!GettingData.GetString(Surname,out surname)){return; }

            string phoneNumber;
            if(!GettingData.GetString(PhoneNumber, out phoneNumber)) { return; }

            DateOnly userBirthDate;
            if(!GettingData.GetDataOnly(Date_of_birth,out userBirthDate)) {return;}

            string address;
            if(!GettingData.GetString(Address, out address)) {return;}
            
            string email;
            if (!GettingData.GetEmail(emailtext,out email)) {return;}


            Buyer addingBuyer = new Buyer();

            addingBuyer.BuyerId = indexer;
            indexer++;
            JsonController<Buyer>.SaveIndexer(indexer);
            addingBuyer.INN = inn;
            addingBuyer.Name = name;
            addingBuyer.Surname = surname;
            addingBuyer.PhoneNumber = phoneNumber;  
            addingBuyer.Address = address;
            addingBuyer.BuyerEmail = email;
            addingBuyer.UserBirthDate = userBirthDate;

            JsonController<Buyer>.WriteToFile(addingBuyer);

            INN.Clear();
            Name.Clear();
            Surname.Clear();
            PhoneNumber.Clear();
            Date_of_birth.Clear();
            Address.Clear();
            emailtext.Clear();
        }

        private void Button_Click_ShowAllBuyers(object sender, RoutedEventArgs e)
        {
            //AllBuyersListBox.Items.Clear();

            List<Buyer> list = JsonController<Buyer>.ReadFromFile();

            AllBuyersListBox.ItemsSource = list;

        }
    }
}
