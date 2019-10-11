using System;

namespace lab_just_do_it_18
{
    class Program
    {
        static void Main(string[] args)
        {
            //var guy = new Parent(50, "John");
        }
    }

    abstract class Person
    {
        protected Random _rand;
        public int Age { get; set; }
        public String Name { get; set; }
        protected int NINO;
        public abstract string BirthdayPlan();
    }

    abstract class Parent : Person
    {
        protected Parent(int age, string name)
        {
            Age = age;
            Name = name;
            NINO = _rand.Next(5000);
        }
        protected Parent(int age, string name, int nino)
        {
            Age = age;
            Name = name;
            NINO = nino;
        }
    }
    
    abstract class Child : Person
    {
        private Random _rand;
        public int Age { get; set; }
        public String Name { get; set; }
        private int NINO;

        public Child(int age, string name)
        {
            age = Age;
            name = Name;
            NINO = _rand.Next(5000);
        }
        
        public Child(int age, string name, int nino)
        {
            Age = age;
            Name = name;
            NINO = nino;
        }

        //public abstract string BirthdayPlan();
    }
    
}