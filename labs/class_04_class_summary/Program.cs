using System;
using System.Collections;
using System.Collections.Generic;

namespace class_04_class_summary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you want to add a person to a list (Y/N)");
            string input = Console.ReadLine();
            var People = new List<Person>();
            if (input.ToUpper() == "Y")
            {
                var person = new Person();
                Console.WriteLine("Please enter the name of a person to add:");
                person.name = Console.ReadLine();

                Console.WriteLine($"Please enter {person.name}'s NINo:");
                person.SetNINo(Console.ReadLine());

                Console.WriteLine($"Please enter {person.name}'s age:");
                person.age = Int32.Parse(Console.ReadLine());

                People.Add(person);
            }
            else
            {
                foreach (var person in People)
                {
                    Console.WriteLine("Name: " + person.name);
                    Console.WriteLine("NINo: " + person.GetNINo());
                    Console.WriteLine("Age: " + person.age);
                }
                Console.ReadLine();
                Environment.Exit(1);
            }

            Console.WriteLine("Do you want to add another person to the list (Y/N)");
            input = Console.ReadLine();
            while (input.ToUpper() == "Y")
            {
                var person = new Person();
                Console.WriteLine("Please enter the name of a person to add:");
                person.name = Console.ReadLine();

                Console.WriteLine($"Please enter {person.name}'s NINo:");
                person.SetNINo(Console.ReadLine());

                Console.WriteLine($"Please enter {person.name}'s age:");
                person.age = Int32.Parse(Console.ReadLine());

                People.Add(person);

                Console.WriteLine("Do you want to add another person to the list (Y/N)");
                input = Console.ReadLine();
            }

            foreach (var person in People)
            {
                Console.WriteLine("Name: " + person.name);
                Console.WriteLine("NINo: " + person.GetNINo());
                Console.WriteLine("Age: " + person.age);
            }
            Console.ReadLine();
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
