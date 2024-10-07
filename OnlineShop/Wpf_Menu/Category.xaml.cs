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
using OnlineShop.Entities;

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        private MainWindow mainWindow;

        private int indexer = JsonController<Category>.LoadIndexer();

        public CategoryPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {
            List<Category> categories = JsonController<Category>.ReadFromFile();

            AllListBox.ItemsSource = categories;

        }

        private void Button_Click_AddCategory(object sender, RoutedEventArgs e)
        {
            string name;
            if (!GettingData.GetString(Category_Name, out name)) { return; }


            Category addingCategory = new Category(indexer, name);

            indexer++;
            JsonController<Category>.SaveIndexer(indexer);

            JsonController<Category>.WriteToFile(addingCategory);

            Category_Name.Clear();
        }

        private void Button_Click_ChangeCategoryByID(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }
    }
}
