using System;

namespace lab_07_methods
{
    class Program
    {
        static void Main()
        {
            //method INSIDE method
            void DoThis()
            {
                Console.WriteLine("I am doing a thing");
            }

            //to call the method
            DoThis();
            DoThisToo();


            MulitplyNumbers(5);        //gives 500
            MulitplyNumbers(5, 1000);  //gives 5000

            OutParameters(2, 5, out int a);         //a = 2 * 5

            var output = Tuple();
            //Console.WriteLine(output.x, output.y, output.z);
        }

        static void DoThisToo()
        {
            Console.WriteLine("I am doing a thing too");
        }


        static void MulitplyNumbers(int y, int x = 100)
        {
            Console.WriteLine(x*y);
        }

        static void OutParameters(int x, int y, out int z)
        {
            z = x * y;
        }

        static (int x, string y, bool z) Tuple()
        {
            return (2, "Yo", true);
        }
    }
}
