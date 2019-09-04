using System;

namespace lab_09_constructors
{
    class Program
    {
        static void Main()
        {
            var merc01 = new Mercades("CHASSIS1234ID", "red", 2500);
            var merc02 = new Mercades();
        }
    }

    class Mercades
    {
        private string _engineChassisID;
        public string Colour { get; set; }
        public int Length{ get; set; }

        public Mercades() { }
        public Mercades(string engineChassisID, string colour, int  length)
        {
            this._engineChassisID = engineChassisID;
            this.Colour = colour;
            this.Length = length;
        }
    }

    class AClass : Mercades
    {
        public AClass() 
        {

        }
    }

    class A104 : AClass
    {

    }

}
