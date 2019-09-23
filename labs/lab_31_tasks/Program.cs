using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace lab_31_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var task01 = new Task(() => 
            { 
                Console.WriteLine("Running task01."); 
            });
            task01.Start();

            //Delegate is a PLACEHOLDER FOR ONE OR MORE METHODS
            //simplest DELEGATE is called action
            //ACTION    void DoThis         //no parameters in, void output
            var taskOld = new Task(DoThis);
            taskOld.Start();

            var task02 = new Task(() =>
            {
                Console.WriteLine("Running task02.");
            });

            task02.Start();

            var taskArray = new Task[10];

            taskArray[0] = Task.Run(() => { Console.WriteLine("Task Array 01"); });
            taskArray[1] = Task.Run(() => { Console.WriteLine("Task Array 02"); });
            taskArray[2] = Task.Run(() => { Console.WriteLine("Task Array 03"); });

            var c = 3;
            for (int i = 3; i < 10; i++)
            {
                c++;
                taskArray[i] = Task.Run(() => { Console.WriteLine($"TaskArray {c}"); });
                System.Threading.Thread.Sleep(100);
            }

            Task.WaitAll(taskArray);
            Console.ReadLine();

            //Paraller ForEach
            //Stopwatch stopwatch = new Stopwatch(); 
            var myList = new List<string> { "a", "b", "c", "c", "c", "c", "c", "c", "c", "c", "c", "c", "c" };
            long time1, time2;
            for (int i = 0; i < 1000; i++)
            {
                myList.Add(i.ToString());
            }

            //stopwatch.Start();
            //myList.ForEach( (s) => 
            //{ 
            //    Console.WriteLine($"Item is {s}");
            //});

            //time1 = stopwatch.ElapsedMilliseconds;
            //stopwatch.Restart();

            //Parallel.ForEach(myList, (s) =>
            //{
            //    Console.WriteLine($"Parallel Item is {s}");
            //});

            //time2 = stopwatch.ElapsedMilliseconds;

            //Console.WriteLine((float)time2 + (float)time1 * 100f);
            //stopwatch.Stop();


            //PLINQ Parallel LINQ
            var outputAsParallel = (
                from item in myList
                select item).AsParallel().ToList();


            //Getting data back from a task
            // var t = Task.Run(() => {);});
            // var t = Task<T>.Run(() => {);});     RETURN data of Type T

            var taskWithResult = Task<int>.Run(() =>
            {
                return 100;
            });
            taskWithResult.Wait();
            Console.WriteLine($"Result of our task is {taskWithResult.Result}");
        }


        static void DoThis() => System.Console.WriteLine("I am doing something.");
    }
}
