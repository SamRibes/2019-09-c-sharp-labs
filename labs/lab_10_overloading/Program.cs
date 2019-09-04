using System;

namespace lab_10_overloading
{
    class Program
    {
        static void Main(string[] args)
        {
            Method01();
            Method01(100);
            Method01("Hello");
            Method01(1000, "Wassup");
        }

        static void Method01()
        {
            Console.WriteLine("Blank");
        }

        //static void Method01(int x){ Console.WriteLine(x);}

        static void Method01(int x) 
        {
            Method01(x, "Some Value"); 
        }

        static void Method01(string y)
        {
            Console.WriteLine(y);
        }

        static void Method01(int x, string y)
        {
            Console.WriteLine(x + y);
        }
    }
}
