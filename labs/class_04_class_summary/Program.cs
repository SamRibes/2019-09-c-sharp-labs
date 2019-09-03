using System;
using System.Windows;

namespace class_04_class_summary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to add a person to a list (Y/N)");
            string input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                var person01 = new Person();
                Console.WriteLine("Please enter the name of a person to add:");
                person01.name = Console.ReadLine();

                Console.WriteLine($"Please enter {person01.name}'s NINo:");
                person01.SetNINo(Console.ReadLine());

                Console.WriteLine($"Please enter {person01.name}'s age:");
                person01.age = Int32.Parse(Console.ReadLine());
            }
            else
            {
                Environment.Exit(1);
            }

        }
        class Person
        {
            private string NINo;
            public string name;
            public int age;


            public string GetNINo() 
            { return NINo; }

            public void SetNINo(string newNino) 
            { this.NINo = newNino; }

        }
    }
}
