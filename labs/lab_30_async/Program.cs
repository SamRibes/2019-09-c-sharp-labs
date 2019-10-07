using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace lab_30_async
{
    class Program
    {
        static List<string> lines = new List<string>();
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                File.AppendAllText("data.txt", $"Adding line {i} at {DateTime.Now}\n]");
            }

            //Console.WriteLine(stopwatch.Elapsed);

            //stopwatch.Stop();


            //DoThisLongThing();
            DoThisLongThingAsync();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
        }

        static void DoThisLongThing()
        {
            Thread.Sleep(3000);
        }

        async static void DoThisLongThingAsync()
        {
            var stopwatch = new Stopwatch();
            //Stream in the lines using stream reader. Used when we don't know how long the data were pulling in is.
            using (var reader = new StreamReader("data.txt"))
            {
                stopwatch.Start();
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if(line == null)
                    {
                        break;
                    }
                    lines.Add(line);
                }
                stopwatch.Stop();

                Console.WriteLine(stopwatch.Elapsed);
                FileInfo fileInfo = new FileInfo("data.txt");
                Console.WriteLine($"Finished reading {lines.Count} lines.");
                Console.WriteLine(fileInfo.Length/1024);
            }
        }
    }
}
