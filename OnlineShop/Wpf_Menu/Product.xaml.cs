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
using OnlineShop.EntityServices;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Product.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private MainWindow mainWindow;

        private int indexer = JsonController<Product>.LoadIndexer();

        public ProductPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {
            List<Product> products = JsonController<Product>.ReadFromFile();

            ProductsListBox.ItemsSource = products;
        }

        private void Button_Click_AddProduct(object sender, RoutedEventArgs e)
        {
            int categoryId;
            if(!GettingData.GetIdNumber(CategoryIdTextBox, out categoryId)) { return; }
            else if (!JsonController<Category>.checkId(categoryId)){ MessageBox.Show("Нет такого Category Id  в базе"); return; }

            int manufacturerId;
            if (!GettingData.GetIdNumber(ManufacturerTextBox, out manufacturerId)) { return; }
            else if (!JsonController<Manufacturer>.checkId(manufacturerId)) { MessageBox.Show("Нет такого Manufacturer Id  в базе"); return; }

            int supplierId;
            if (!GettingData.GetIdNumber(SupplierTextBox, out supplierId)) { return; }
            else if (!JsonController<Supplier>.checkId(supplierId)) { MessageBox.Show("Нет такого Supplier Id  в базе"); return; }

            string name;
            if (!GettingData.GetString(ProductNameTextBox, out name)) { return; }

            uint price;
            if(!GettingData.GetPrice(ProductPriceTextBox, out price)) {  return; }



            Product addingProduct = new Product(indexer, name, categoryId, manufacturerId, supplierId, price);

            indexer++;
            JsonController<Product>.SaveIndexer(indexer);

            JsonController<Product>.WriteToFile(addingProduct);

            CategoryIdTextBox.Clear();
            ManufacturerTextBox.Clear();
            SupplierTextBox.Clear();
            ProductNameTextBox.Clear();
            ProductPriceTextBox.Clear();

        }


        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }
    }
}
