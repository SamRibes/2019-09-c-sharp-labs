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
        }

        public void stuff()
        {
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
                PrintRabbit();
            }

            //new rabbit : wpf textbox01.text ==> use for age , name (2boxes)
            //buttonAdd : run this code

            var newRabbit = new Rabbit() { Age = 0, Name = $"Sam{rabbits.Count + 1}" };

            using (var db = new RabbitDbEntities())
            {
                db.Rabbits.Add(newRabbit);
                db.SaveChanges();
            }


            System.Threading.Thread.Sleep(200);
            Console.ReadLine();

            using (var db = new RabbitDbEntities())
            {
                PrintRabbit();
            }
            Console.ReadLine();
        }

        static void PrintRabbit()
        {
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
                rabbits.ForEach(rabbit => Console.WriteLine($"{rabbit.RabbitID,-5}" + $"{rabbit.Name,-12}{rabbit.Age}"));
            }
            Console.ReadLine();
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
