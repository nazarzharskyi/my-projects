using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using OnlineShop;
using OnlineShop.Entities;
using OnlineShop.EntityServices;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Manufacturer.xaml
    /// </summary>
    public partial class ManufacturerPage : Page
    {

        private MainWindow mainWindow;

        private int indexer = JsonController<Manufacturer>.LoadIndexer();

        public ManufacturerPage (MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click_AddManuracturer(object sender, RoutedEventArgs e)
        {


            string name;
            if (!GettingData.GetString(ManufacturerName, out name)) { return; }

            string edrpou;
            if (!GettingData.GetEDRPOU(ManufacturerEDRPOU, out edrpou)) { return; }


            Manufacturer addingManufacturer = new Manufacturer(indexer, name, edrpou);
            indexer++;
            JsonController<Manufacturer>.SaveIndexer(indexer);

            JsonController<Manufacturer>.WriteToFile(addingManufacturer);

            ManufacturerName.Clear();
            ManufacturerEDRPOU.Clear();

        }

        private void Button_Click_ShowAllManufacturer(object sender, RoutedEventArgs e)
        {
            List<Manufacturer> list = JsonController<Manufacturer>.ReadFromFile();

            AllManufacturesListBox.ItemsSource = list;
        }

        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }
    }
}
