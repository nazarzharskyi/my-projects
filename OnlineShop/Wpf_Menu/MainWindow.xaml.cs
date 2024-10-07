using System.Runtime.CompilerServices;
using System.Text;
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
using Wpf_Menu;

namespace Wpf_Menu
{
    public partial class MainWindow : Window
    {
        public Dictionary<string, Page> pages;

        public MainWindow()
        {
            InitializeComponent();

            this.pages = new Dictionary<string, Page>();

            this.pages.Add("MainPage", new MainPage(this));
            this.pages.Add("Buyers", new Buyers(this));
            this.pages.Add("Card", new Card(this));
            this.pages.Add("Category", new CategoryPage(this));
            this.pages.Add("Employee", new EmployeePage(this));
            this.pages.Add("Manufacturer", new ManufacturerPage(this));
            this.pages.Add("Order", new OrderPage(this));
            this.pages.Add("Payment", new Payment(this));
            this.pages.Add("Product", new ProductPage(this));
            this.pages.Add("Stock", new Stock(this));
            this.pages.Add("Supplier", new SupplierPage(this));

            // Установка начальной страницы
            NavigateToPage("MainPage");
        }

        public void NavigateToPage(string pageKey)
        {
            if (this.pages.ContainsKey(pageKey))
            {
                MainFrame.Navigate(this.pages[pageKey]);
            }
            else
            {
                MessageBox.Show("Страница не найдена.");
            }
        }

        public void MessageAlert (string message)
        {
            MessageBox.Show(message); 
        }

    }
}