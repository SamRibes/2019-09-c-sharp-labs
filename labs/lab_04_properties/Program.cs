using System;

namespace lab_04_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbit = new Rabbit();
            rabbit.Name = "Cute01";
            rabbit.Age = -10;
            Console.WriteLine(rabbit.Age); //Comes out as 0 (default int value)
        }
    }

    class Rabbit
    {
        private int _bloodType;
        private int _age;
        public string Name { get; set; } 

        public int Age {
            get
            {
                return this._age;
            } 
            set 
            {
                if(value >= 0)
                {
                    this.Age = value;
                }
            }
        }
    }
}
