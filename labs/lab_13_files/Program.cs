using System;
using System.IO;
using System.Linq;

namespace lab_13_files
{
    class Program
    {
        static void Main(string[] args)
        {
            //if(File.Exists("myFile.txt"))
            //{
            //    var string1 = File.ReadAllText("myFile.txt");
            //    Console.WriteLine(string1);
            //}
            //File.WriteAllText($"output-{DateTime.Now.Millisecond}.txt", "some stuff to go in a file");
            //Console.WriteLine("Saving arrays to multiple lines");


            //string[] myarray = new string[] { "some", "data", "in", "an", "array"};
            //File.WriteAllLines("multiLines.txt", myarray);


            //var output = File.ReadAllLines("multiLines.txt");
            //Array.ForEach(output, item => Console.WriteLine(item));

            File.WriteAllText("multipleLines.txt", "some" + Environment.NewLine + "text" + Environment.NewLine + "here\n");

            //Logging

            Console.WriteLine("\n===Logging===\n");

            for(int i = 0; i < 10; i++)
            {
                File.AppendAllText("myLogFile.log", $"Event happened at time {DateTime.Now}" + Environment.NewLine);
            }
            
        }
    }
}
