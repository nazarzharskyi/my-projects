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
using System.Linq;
using OnlineShop.Entities;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class OrderPage : Page
    {

        private MainWindow mainWindow;

        private int indexer = JsonController<Order>.LoadIndexer();

        public OrderPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            //Payment_type_combo_box.ItemsSource = PaymentTypeController.ReadFromFile();

        }

        

        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }



        private void Button_Click_AddOrder(object sender, RoutedEventArgs e)
        {

            int orderId = indexer;
            indexer++;
            JsonController<Order>.SaveIndexer(indexer);

            int supplierId;
            if (!GettingData.GetIdNumber(SupplierIdTextBox, out supplierId)) { return; }
            else if (!JsonController<Supplier>.checkId(supplierId)) { MessageBox.Show("Нет такого Supplier Id  в базе"); return; }

            int productId;
            if (!GettingData.GetIdNumber(ProductIdTextBox, out productId)) { return; }
            else if (!JsonController<Product>.checkId(productId)) { MessageBox.Show("Нет такого Product Id  в базе"); return; }

            int employeeId;
            if (!GettingData.GetIdNumber(EmployeeIdTextBox, out employeeId)) { return; }
            else if (!JsonController<Employee>.checkId(employeeId)) { MessageBox.Show("Нет такого Manager Id  в базе"); return; }

            decimal productAmount;
            if (!GettingData.GetAmountDecimal(ProductAmountTextBox, out productAmount)) { return; }

            Order order = new Order(orderId, supplierId, productId, employeeId, productAmount, DateTime.Now);

            JsonController<Order>.WriteToFile(order);

            SupplierIdTextBox.Clear();
            ProductIdTextBox.Clear();
            ProductAmountTextBox.Clear();
            EmployeeIdTextBox.Clear();

        }

        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {
            List<Order> orders = JsonController<Order>.ReadFromFile();

            ProductsListBox.ItemsSource = orders;
        }



        private void Button_Click_Show_products(object sender, RoutedEventArgs e)
        {
            List<Product> products  = JsonController<Product>.ReadFromFile();

            Dictionary<int, string> result = (from product in products select new {product.ProductID, product.ProductName}).ToDictionary(p => p.ProductID, p => p.ProductName);

            ProductsListBox.ItemsSource = result;
        }



    }
}
