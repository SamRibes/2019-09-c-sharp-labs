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

namespace lab_16_wpf_rabbit_explosion_framework
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
            
        }

        public static void Rabbit_Exponential_Growth(int popLimit = 1000)
        {
            var rabbits = new List<Rabbit>();

            var years = 0;
            var adultAge = 3;


            while (rabbits.Count < popLimit)
            {
                if (rabbits.Count < 1)
                {
                    var initialRabbit = new Rabbit(0);
                    rabbits.Add(initialRabbit);
                    var rabbitImg = new Image();
                }

                var currentPop = rabbits.Count;

                for (var i = 0; i < (currentPop); i++)
                {
                    rabbits[i].Age++;
                    if (rabbits[i].Age >= adultAge)
                    {
                        var newRabbit = new Rabbit(0);
                        rabbits.Add(newRabbit);

                    }

                }
                years++;
            }

        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            Rabbit_Exponential_Growth();
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Rabbit(int age)
        {
            Age = age;
        }
    }
}
