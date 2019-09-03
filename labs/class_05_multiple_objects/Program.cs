using System;
using System.Collections.Generic;

namespace lab_05_multiple_objects
{
    class Program
    {
        static void Main(string[] args)
        {
            var Rabbits = new List<Rabbit>();
            for (int i = 1; i <= 10; i++)
            {
                var rabbit = new Rabbit();

                rabbit.Name = $"Rabbit{i:D2}";

                rabbit.age = i;

                Rabbits.Add(rabbit);
            }

            foreach (var rabbit in Rabbits)
            {
                Console.WriteLine("Name: " + rabbit.Name);
                Console.WriteLine("Age: " + rabbit.age);
                Console.WriteLine();
            }
        }

        class Rabbit
        {
            private int _bloodType;
            public int age;
            public string Name { get; set; }
        }

    }
}
