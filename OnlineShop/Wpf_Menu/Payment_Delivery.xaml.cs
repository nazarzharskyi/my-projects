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

namespace Wpf_Menu
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Page
    {
        private MainWindow mainWindow;

        enum DeliveryStatus
        {
            Not_Shipped,
            On_the_way,
            Delivered
        }

        enum PaymentStatus
        {
            Unpaid,
            Paid
        }

        DeliveryStatus deliveryStatus;

        PaymentStatus paymentStatus;

        public Payment(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            Delivery_Status_combo_box.ItemsSource = Enum.GetValues(typeof(DeliveryStatus)).Cast<DeliveryStatus>();
            Payment_Status_combo_box.ItemsSource = Enum.GetValues(typeof(PaymentStatus)).Cast<PaymentStatus>();
        }

        private void Button_Click_ChangeStatus(object sender, RoutedEventArgs e)
        {
            DeliveryStatus selectedStatusAdd;

            PaymentStatus paymentStatusAdd;


            if (deliveryStatus != null)
            {
                selectedStatusAdd = deliveryStatus;
            }
            else if (paymentStatus != null)
            {
                paymentStatusAdd = paymentStatus;
            }


        }

        private void Button_Click_Back_to_Main_Menu(object sender, RoutedEventArgs e)
        {
            this.mainWindow.NavigateToPage("MainPage");
        }

        private void Button_Click_AddOrder(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_ShowAll(object sender, RoutedEventArgs e)
        {

        }


        private void Delivery_Status_combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deliveryStatus = (DeliveryStatus)Delivery_Status_combo_box.SelectedItem;
        }

        private void Payment_Status_combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            paymentStatus = (PaymentStatus)Payment_Status_combo_box.SelectedItem;
        }
    }
}
