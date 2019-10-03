using external;
using System;

namespace lab_27_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Child c = new Child("Sam Jr", 5);

            Console.WriteLine(c.age);
            c.DoThis();
            Console.WriteLine(c.age);
            c.DoThat();
            Console.WriteLine(c.age);
            c.AlsoDoThis();
            Console.WriteLine(c.age);

        }
    }


    abstract class Parent
    {
        public string name { get; set; }
        public int age { get; set; }
    }
    
    class Child : Parent, IDoThat, IDoThis, IAlsoDoThis
    {
        public Child(string Name, int Age)
        {
            this.name = Name;
            this.age = Age;
        }

        public void DoThat()
        {
            Console.WriteLine("I do that");
            age++;
        }

        public void DoThis()
        {
            Console.WriteLine("I do this");
            age--;
        }

        public void AlsoDoThis()
        {
            Console.WriteLine("I also do this");
            age = 0;
        }
    }

    interface IDoThis
    {
        void DoThis();
    }

    interface IDoThat
    {
        void DoThat();
    }

    
}


namespace external
{
    interface IAlsoDoThis
    {
        void AlsoDoThis();
    }
}