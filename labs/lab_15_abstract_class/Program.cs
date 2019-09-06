using System;

namespace lab_15_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        abstract public class Holiday
        {
            public abstract void TravelPlans();
            public void PlacesToVisit() 
            {
                Console.WriteLine("Visiting Vienna, Salzburg");
            }
            public void Activities() 
            { 
                Console.WriteLine("Skiing, Walking, Fishing");
            }
        }

        public class HolidayWithTravel : Holiday
        {
            public override void TravelPlans() { Console.WriteLine("By train eurostar, then plane, then car"); }
        }
    }
}
