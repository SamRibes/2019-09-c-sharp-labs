using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace project_1000_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Rabbit> rabbits;
        public MainWindow()
        {
            InitializeComponent();
        }

        void Initialise()
        {
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
                
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var stopwatch = new Stopwatch();
            var noOfRabbitsToCreate = 1000;
            string firstTimeElapsed, secondTimeElapsed;

            stopwatch.Start();
            using (var db = new RabbitDbEntities())
            {
                for (int i = 1; i <= noOfRabbitsToCreate; i++)
                {
                    Console.WriteLine(db.Rabbits.Find(i).RabbitID);
                }
            }

            firstTimeElapsed = stopwatch.Elapsed.ToString();
            stopwatch.Stop();
            stopwatch.Reset();

            stopwatch.Start();
            using (var db = new RabbitDbEntities())
            {
                foreach (var rabbit in db.Rabbits.ToList())
                {
                    Console.WriteLine(rabbit.RabbitID);
                }
            }

            firstTimeElapsed = stopwatch.Elapsed.ToString();
            stopwatch.Stop();
            stopwatch.Reset();


            stopwatch.Start();
            for (int i = 1; i <= noOfRabbitsToCreate; i++)
            {
                using (var db = new RabbitDbEntities())
                {
                    Console.WriteLine(db.Rabbits.Find(i).RabbitID);
                }
            }

            secondTimeElapsed = stopwatch.Elapsed.ToString();
            stopwatch.Stop();
            stopwatch.Reset();
        }
    }
}
