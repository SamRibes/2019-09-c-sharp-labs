using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1000_console
{
    class Program
    {
        static void Main(string[] args)
        {
            int noOfRabbitsToCreate = 1000;
            Stopwatch stopwatch = new Stopwatch();
            String firstTimeElapsed, secondTimeElapsed;

            //for (int i = 1; i <= noOfRabbitsToCreate; i++)
            //{
            //    using (var db = new RabbitDbEntities())
            //    {
            //        var rabbit = new Rabbit();
            //        db.Rabbits.Add(rabbit);
            //        db.SaveChanges();
            //    }
            //}

            //using (var db = new RabbitDbEntities())
            //{
            //    for (int i = 1; i <= noOfRabbitsToCreate; i++)
            //    {

            //        var rabbit = new Rabbit();
            //        db.Rabbits.Add(rabbit);
            //        db.SaveChanges();
            //    }
            //}



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



            File.WriteAllText("rabbits.csv", "ID,Name,Age");
            File.AppendAllText("rabbits.csv", "\n1, Billy, 12");
            File.AppendAllText("rabbits.csv", "\n2, Bob, 9");
            Process.Start("rabbits.csv");

            //Console.WriteLine($"1 read time elapsed = {firstTimeElapsed}");
            //Console.WriteLine($"1000 read time elapsed = {secondTimeElapsed}");
            Console.ReadLine();
        }
    }
}
