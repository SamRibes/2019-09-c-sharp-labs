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

namespace lab_18_lab_database_CRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Rabbit> rabbits;
        static Rabbit rabbit = new Rabbit();
        public MainWindow()
        {
            InitializeComponent();
            //Start up my own Initialise
            Initialise();
        }

        void Initialise()
        {
            //auto clean up:
            //C# doesn't know when we're done so the using wrap cleans the memory it used once it finishes this section of code
            using(var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }
            //Fancy lamba thingy to loop rabbits and add items to list box
            ListBoxRabbits.ItemsSource = rabbits;

            NameBox.IsReadOnly = true;
            AgeBox.IsReadOnly = true;
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        private void ListBoxRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(rabbit.Name);
            if(ListBoxRabbits.SelectedItem != null)
            {
                rabbit = (Rabbit)ListBoxRabbits.SelectedItem;
                NameBox.Text = rabbit.Name;
                AgeBox.Text = rabbit.Age.ToString();
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
            }
          
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddButton.Content.Equals("Add"))
            {
                AddButton.Content = "Save";
                AddButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#802716"));
                NameBox.IsReadOnly = false;
                AgeBox.IsReadOnly = false;
                NameBox.Text = "";
                AgeBox.Text = "";
                NameBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF8E78"));
                AgeBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF8E78"));
            }
            else
            {
                AddButton.Content = "Add";
                AddButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#80473C"));
                NameBox.IsReadOnly = true;
                AgeBox.IsReadOnly = true;
                NameBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#CC3F23"));
                AgeBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#CC3F23"));

                if (AgeBox.Text.Length > 0 && NameBox.Text.Length > 0 && (NameBox.Text.Length.Equals(null) == false) && (AgeBox.Text.Length.Equals(null) == false))
                {
                    //must have selected a rabbit
                    var rabbitToAdd = new Rabbit();
                    if (rabbit != null)
                    {
                        rabbitToAdd.Name = NameBox.Text;
                        if (int.TryParse(AgeBox.Text, out int age))
                        {
                            rabbitToAdd.Age = age;
                        }

                        //Read rabbit from database by the id 
                        using (var db = new RabbitDbEntities())
                        {
                            //update the rabbit 
                            db.Rabbits.Add(rabbitToAdd);
                            //save the rabbit back to database 
                            db.SaveChanges();
                            //repop the list box
                            ListBoxRabbits.ItemsSource = db.Rabbits.ToList();
                        }
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EditButton.Content.Equals("Edit"))
            {
                EditButton.Content = "Save";
                EditButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#802716"));
                NameBox.IsReadOnly = false;
                AgeBox.IsReadOnly = false;
                NameBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF8E78"));
                AgeBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF8E78"));
            }
            else
            { 
                EditButton.Content = "Edit";
                EditButton.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#80473C"));
                NameBox.IsReadOnly = true;
                AgeBox.IsReadOnly = true;
                NameBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#CC3F23"));
                AgeBox.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#CC3F23"));
                
                if(AgeBox.Text.Length > 0 && NameBox.Text.Length > 0 && (NameBox.Text.Length.Equals(null) == false) && (AgeBox.Text.Length.Equals(null) == false))
                {
                    //must have selected a rabbit
                    if(rabbit != null)
                    {
                        rabbit.Name = NameBox.Text;
                        if(int.TryParse(AgeBox.Text, out int age))
                        {
                            rabbit.Age = age; 
                        }

                        //Read rabbit from database by the id 
                        using (var db = new RabbitDbEntities())
                        {
                            var rabbitToUpdate = db.Rabbits.Find(rabbit.RabbitID);
                            //update the rabbit 
                            rabbitToUpdate.Name = rabbit.Name;
                            rabbitToUpdate.Age = rabbit.Age;
                            //save the rabbit back to database 
                            db.SaveChanges();
                            //repop the list box
                            ListBoxRabbits.ItemsSource = db.Rabbits.ToList();
                        }
                    }
                }
            }

        }
    }
}
