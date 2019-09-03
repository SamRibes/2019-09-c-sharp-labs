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
        }

        static void DoThisToo()
        {
            Console.WriteLine("I am doing a thing too");
        }


        static void MulitplyNumbers(int y, int x = 100)
        {
            Console.WriteLine(x*y);
        }
    }
}
