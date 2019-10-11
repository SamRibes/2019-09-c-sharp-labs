using System;

namespace lab_33_oop_events
{
    class Program
    {
        static void Main(string[] args)
        {
            var Sam = new Child();

            Sam.Name = "Sam";
            for (int i = 0; i < 10; i++)
            {
                Sam.Grow();
            }
        }
    }

    class Child
    {
        public delegate void BirthdayDelegate(string TypeOfParty);

        public event BirthdayDelegate HaveABirthday;

        public string Name { get; set; }

        public int Age { get; set; }

        public Child()
        {
            this.Age = 0;
            Console.WriteLine("Congrats! Beautiful baby :)");
            /*HaveABirthday += Celebrate;*/
        }

        int Celebrate()
        {
            Age++;
            Console.WriteLine($"Celebrating another brithday: Age is {this.Age}");
            return Age;
        }

        public void Grow()
        {
            /*int ageNow = HaveABirthday();*/
        }
    }
}
