using System;

namespace lab_02_class
{
    class Program
    {
        static void Main()
        {
            var dog1 = new Dog();           //This is an instance of a class

            dog1.Age = 10;
            dog1.Height = 50;
            dog1.Name = "Bob";

            //Console.WriteLine("Hello World!");
            Console.WriteLine($"The dog's name is {dog1.Name}, is {dog1.Age} years old and is {dog1.Height}cm tall.");
            Console.ReadLine();
            dog1.Grow();
            Console.WriteLine($"{dog1.Name} is now {dog1.Age} years old and is {dog1.Height}cm tall.");
        }
    }

    class Dog
    {
        public string Name;
        public int Age, Height;

        public void Grow()
        {
            this.Age++;
            this.Height += 10;
        }
    }
}
