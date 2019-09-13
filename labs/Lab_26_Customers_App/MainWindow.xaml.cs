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
        static bool whatSearch;
        static List<Customer> customers;
        static List<Order> orders;
        static List<Order_Detail> order_Details;

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            //ListBoxCustomers.ItemsSource = customers.ToList().Where(c => c.ContactName.Contains(CustomerSearchBox.Text));
            //ListBoxCustomers.DisplayMemberPath = "ContactName";
            goToStack02();
            using (var db = new NorthwindEntities())
            {
                ListBoxCustomers.ItemsSource = db.Customers.ToList();
                ListBoxOrders.ItemsSource = db.Orders.ToList();
            }

            CustomerNameFilter.IsEnabled = false;
            CustomerCityFilter.IsEnabled = true;
            whatSearch = false;
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
                orders = db.Orders.ToList();

                ListBoxCustomers.ItemsSource = customers;
            }

        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel01.Visibility == Visibility.Visible)
            {
                goToStack03();
            }
            else if (StackPanel02.Visibility == Visibility.Visible)
            {
                goToStack01();
            }
            else if (StackPanel03.Visibility == Visibility.Visible)
            {
                goToStack02();
            }
        }
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanel01.Visibility == Visibility.Visible)
            {
                goToStack02();
                using (var db = new NorthwindEntities())
                {
                    ListBoxOrders.ItemsSource = db.Orders.ToList();
                }
            }
            else if (StackPanel02.Visibility == Visibility.Visible)
            {
                goToStack03();
            }
            else if (StackPanel03.Visibility == Visibility.Visible)
            {
                goToStack01();
            }
        }

        private void CustomerSearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            using (var db = new NorthwindEntities())
            {
                if (whatSearch == false)
                {
                    ListBoxCustomers.ItemsSource = db.Customers.Where(c => c.ContactName.Contains(CustomerSearchBox.Text)).ToList();
                }
                else
                {
                    ListBoxCustomers.ItemsSource = db.Customers.Where(c => c.City.Contains(CustomerSearchBox.Text)).ToList();
                }
            }
        }
        private void CustomerNameFilter_Click(object sender, RoutedEventArgs e)
        {
            CustomerNameFilter.IsEnabled = false;
            CustomerCityFilter.IsEnabled = true;
            whatSearch = false;
        }
        private void CustomerCityFilter_Click(object sender, RoutedEventArgs e)
        {
            CustomerNameFilter.IsEnabled = true;
            CustomerCityFilter.IsEnabled = false;
            whatSearch = true;
        }

        private void ListBoxCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            using (var db = new NorthwindEntities())
            {
                orders = db.Orders.ToList();
                customers = db.Customers.ToList();

                Customer previouslySelected = (Customer)ListBoxCustomers.SelectedItem;

                searchOrders(previouslySelected.ContactName.ToString());
            }
        }

       
        
        private void ListBoxCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        void searchOrders(string orderToSearch)
        {
            using(var db = new NorthwindEntities())
            { 
                ListBoxOrders.ItemsSource = db.Orders.Where(o => o.Customer.ContactName.Contains(orderToSearch)).ToList();
            }
        }

        void goToStack01()
        {
            StackPanel01.Visibility = Visibility.Visible;
            StackPanel02.Visibility = Visibility.Collapsed;
            StackPanel03.Visibility = Visibility.Collapsed;
        }
        void goToStack02()
        {
            StackPanel01.Visibility = Visibility.Collapsed;
            StackPanel02.Visibility = Visibility.Visible;
            StackPanel03.Visibility = Visibility.Collapsed;
        }
        void goToStack03()
        {
            StackPanel01.Visibility = Visibility.Collapsed;
            StackPanel02.Visibility = Visibility.Collapsed;
            StackPanel03.Visibility = Visibility.Visible;
        }
    }
}
