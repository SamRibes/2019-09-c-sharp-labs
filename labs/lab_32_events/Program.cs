using System;

namespace lab_32_events
{
    class Program
    {
        public delegate void MyDelegate();

        public static event MyDelegate MyEvent;
        static void Main(string[] args)
        {
            MyEvent += MethodA;     //Pointer to a method but dont call the method right now
            MyEvent += MethodB;     //Callback
            MyEvent += MethodC;

            MyEvent();
        }

        static void MethodA() { Console.WriteLine("Method A"); }
        static void MethodB() { Console.WriteLine("Method B"); }
        static void MethodC() { Console.WriteLine("Method C"); }
    }
}
