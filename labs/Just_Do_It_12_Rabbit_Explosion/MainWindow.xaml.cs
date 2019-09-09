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

namespace Just_Do_It_12_Rabbit_Explosion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Rabbit> rabbits;
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }
        public void Initialise()
        {
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }
        }

        void PrintRabbitToBlock()
        {
            var db = new RabbitDbEntities();
            rabbits = db.Rabbits.ToList();
            RabbitGrid.ItemsSource = rabbits;
            //rabbits.ForEach(rabbit => DataBlock.Text.Append($"{rabbit.RabbitID,-5}" + $"{rabbit.Name,-12}{rabbit.Age}");

            Console.ReadLine();
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            var newRabbit = new Rabbit() 
            { 
                Age = Int32.Parse(AgeBox.Text), 
                Name = NameBox.Text
            };

            using (var db = new RabbitDbEntities())
            {
                db.Rabbits.Add(newRabbit);
                db.SaveChanges();
            }
            System.Threading.Thread.Sleep(200);

            PrintRabbitToBlock();
        }


    }
}
