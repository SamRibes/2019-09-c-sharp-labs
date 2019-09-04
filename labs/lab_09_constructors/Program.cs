using System;

namespace lab_09_constructors
{
    class Program
    {
        static void Main()
        {
            var merc01 = new Mercades("CHASSIS1234ID", "red", 2500);
            var merc02 = new Mercades();
            var aClass = new AClass("CHASSIS123ID", "blue", 3000);

            var a104 = new AClass("CHASSIS12ID", "silver", 2000);
        }
    }

    class Mercades
    {
        protected string _engineChassisID;
        public string Colour { get; set; }
        public int Length{ get; set; }

        public Mercades() { }               //this is the default constructor
        public Mercades(string engineChassisID, string colour, int  length)
        {
            this._engineChassisID = engineChassisID;
            this.Colour = colour;
            this.Length = length;
        }
    }

    class AClass : Mercades
    {
        public AClass(){ }

        public AClass(string engineChassisID, string colour, int length) 
        {
            this._engineChassisID = engineChassisID;
            this.Length = length;
            this.Colour = colour;
        }
    }

    class A104 : AClass
    {
        //Different constructor > calling parent constructor

        public A104(string engineChassisID, string colour, int length) : 
            base(engineChassisID, colour, length)
        {

        }


    }

}
