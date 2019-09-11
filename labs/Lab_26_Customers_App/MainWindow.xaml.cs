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

namespace Lab_26_Customers_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            //ListBoxCustomers.ItemsSource = customers.ToList().Where(c => c.ContactName.Contains(CustomerSearchBox.Text));
            //ListBoxCustomers.DisplayMemberPath = "ContactName";

            using (var db = new NorthwindEntities())
            {

                ListBoxCustomers.ItemsSource = db.Customers.ToList();
                //ListBoxCustomers.DisplayMemberPath = "ContactName";
            }


        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel01.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Collapsed;
                StackPanel02.Visibility = Visibility.Collapsed;
                StackPanel03.Visibility = Visibility.Visible;
            }
            else if (StackPanel02.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Visible;
                StackPanel02.Visibility = Visibility.Collapsed;
                StackPanel03.Visibility = Visibility.Collapsed;
            }
            else if (StackPanel03.Visibility == Visibility.Visible)
            {
                StackPanel01.Visibility = Visibility.Collapsed;
                StackPanel02.Visibility = Visibility.Visible;
                StackPanel03.Visibility = Visibility.Collapsed;
            }
        }

        private void CustomerSearchBox_KeyUp(object sender, KeyEventArgs e)
        {

            using (var db = new NorthwindEntities())
            {

                ListBoxCustomers.ItemsSource = db.Customers.Where(c => c.ContactName.Contains(CustomerSearchBox.Text)).ToList();
                //ListBoxCustomers.DisplayMemberPath = "ContactName";
            }
        }
        private void CustomerNameFilter_Click(object sender, RoutedEventArgs e)
        {
           
        }

    }
}
