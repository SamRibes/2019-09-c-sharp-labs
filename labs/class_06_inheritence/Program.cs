using System;

namespace lab_06_inheritence
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dog();
            d.Name = "Kiko";

            var mutt1 = new Mutt();
            mutt1.Name = "Sam'sBestFriend";
            mutt1.Age = 3;
        }

        class Dog
        {
            public string Name { get; set; }
        }

        class Mutt : Dog 
        {
            public int Age { get; set; }
        }
    }
}
