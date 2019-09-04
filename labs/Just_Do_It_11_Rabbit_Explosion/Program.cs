using System;
using System.Collections.Generic;
using System.Threading;

namespace Just_Do_It_11_Rabbit_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            /*List<Rabbit> rabbits = new List<Rabbit>();

            int popLimit = 50;

            while (rabbits.Count < popLimit)
            {
                var rabbit = new Rabbit();
                rabbits.Add(rabbit);
                Thread.Sleep(200);

                Console.WriteLine($"Rabbit added. Current population is {rabbits.Count}.");
            }*/

            /*List<Rabbit> rabbits = new List<Rabbit>();
            var initialRabbit = new Rabbit();
            rabbits.Add(initialRabbit);

            int popLimit = 50;

            Console.WriteLine($"Rabbit added. Current population is {rabbits.Count}.");

            while (rabbits.Count < popLimit)
            {
                var rabbit = new Rabbit();

                int currentPop = rabbits.Count;

                for (int i = 0; i < (currentPop);i++)
                {
                    rabbits.Add(rabbit);
                }

                Thread.Sleep(200);

                Console.WriteLine($"Rabbit added. Current population is {rabbits.Count}.");
            }*/

            var rabbits = new List<Rabbit>();

            var popLimit = 100;
            var years = 0;
            var adultAge = 3;

            Console.WriteLine($"Current population is {rabbits.Count}.");

            while (rabbits.Count < popLimit)
            {
                if(rabbits.Count < 1)
                {
                    var initialRabbit = new Rabbit(0);
                    rabbits.Add(initialRabbit);
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

                Console.WriteLine($"Current population is {rabbits.Count}.");
            }
            Console.WriteLine($"Took {years} years to exceed the population limit. Finished with {rabbits.Count} rabbits.");
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Rabbit (int age){
            Age = age;
        }
    }

}
