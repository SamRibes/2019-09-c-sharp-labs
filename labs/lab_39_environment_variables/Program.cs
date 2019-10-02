using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_39_environment_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = Environment.GetEnvironmentVariables();
            foreach(DictionaryEntry item in collection)
            {
                Console.WriteLine(item.Value);
            }

            Console.WriteLine(Environment.GetEnvironmentVariable("WinDir"));

            Environment.SetEnvironmentVariable("Secret Password", "123");

            Console.WriteLine(Environment.GetEnvironmentVariable("Secret Password"));

        }
    }
}
