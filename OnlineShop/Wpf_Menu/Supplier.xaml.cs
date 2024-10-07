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
    /// Interaction logic for Supplier.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        private MainWindow mainWindow;

        private int indexer = JsonController<Supplier>.LoadIndexer();

        public SupplierPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click_ShowAllSupplier(object sender, RoutedEventArgs e)
        {
            List<Supplier> suppliers = JsonController<Supplier>.ReadFromFile();

            AllManufacturesListBox.ItemsSource = suppliers;
        }

        private void Button_Click_AddSupplier(object sender, RoutedEventArgs e)
        {

            string name;
            if (!GettingData.GetString(SupplierName, out name)) { return; }

            string edrpou;
            if (!GettingData.GetEDRPOU(SupplierEDRPOU, out edrpou)) { return; }

            Supplier addingSupplier = new Supplier( indexer, name, edrpou );

            indexer++;
            JsonController<Supplier>.SaveIndexer(indexer);

            JsonController<Supplier>.WriteToFile(addingSupplier);

            SupplierName.Clear();
            SupplierEDRPOU.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }
    }
}
