using System;

namespace lab_11_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var parent = new Parent("Dad", 40);
            var child = new Child("Me", 23);
            Console.WriteLine($"{parent.Name}'s age is {parent.Age}. {child.Name}'s age is {child.Age}.");
            Console.WriteLine(child.Age);
            for (int i = 0; i < 10; i++)
            {
                parent.HaveABrithday();
                child.HaveABrithday();
                Console.WriteLine($"{parent.Name}'s age is {parent.Age}. {child.Name}'s age is {child.Age}.");
            }

        }


        class Parent
        {
            public string Name { get; set; }
            public int Age { get; set; }


            public Parent(string name, int age)
            {
                Name = name;
                Age = age;
            }
            public Parent()
            {

            }

            public void SetAge(int age)
            {
                Age = age;
            }

            public virtual void HaveABrithday() { Age++; }

        }
        class Child : Parent
        {

            public Child(string name, int age = 0) : 
                base(name, age)
            {

            }
            public override void HaveABrithday() 
            {
                Age += 2; 
            }
         }

    }
}
