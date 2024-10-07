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

    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
 namespace Wpf_Menu
    {
        public partial class MainPage : Page
        {
            readonly MainWindow mainWindow;

            public MainPage(MainWindow mainWindow)
            {
                InitializeComponent();
                this.mainWindow = mainWindow;
            }

            private void Button_Click_Suppliers(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Supplier");
            }

            private void Button_Click_Manufacturer(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Manufacturer");
            }

            private void Button_Click_Category(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Category");
            }

            private void Button_Click_Products(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Product");
            }

            private void Button_Click_Orders(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Order");
            }

            private void Button_Click_Employees(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Employee");
            }

            private void Button_Click_Buyers(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Buyers");
            }

            private void Button_Click_Cards(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Card");
            }

            private void Button_Click_Payment(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Payment");
            }

            private void Button_Click_Stock(object sender, RoutedEventArgs e)
            {
                mainWindow.NavigateToPage("Stock");
            }
        }

    }