using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_17_rabbit_database_explosion
{
    class Program
    {
        static List<Rabbit> rabbits;
        static void Main(string[] args)
        {
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
                PrintRabbit();
            }

            //new rabbit : wpf textbox01.text ==> use for age , name (2boxes)
            //buttonAdd : run this code

            var newRabbit = new Rabbit(){Age = 0, Name = $"Sam{rabbits.Count + 1}" };

            using(var db = new RabbitDbEntities())
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

    }
}